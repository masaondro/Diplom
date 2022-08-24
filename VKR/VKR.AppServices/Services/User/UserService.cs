using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKR.AppServices.Services.JWT;
using VKR.AppServices.Services.UserProfile;
using VKR.Contracts.User;
using VKR.Contracts.UserProfile;
using VKR.Domain.Entities;
using VKR.Infrastructure;

namespace VKR.AppServices.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IUserProfileService _userProfileService;

        public UserService(IConfiguration config, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IEmailService emailService,
            IUserProfileService userProfileService)
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _emailService = emailService;
            _userProfileService = userProfileService;
        }

        public async Task Register(RegisterUserDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) != null)
            {
                throw new Exception($"Адрес электронной почты уже занят");
            }

            var user = _mapper.Map<ApplicationUser>(dto);
            await _userManager.CreateAsync(user, dto.Password);
            
            if (!await _roleManager.RoleExistsAsync(Roles.AdminRoleName))
                await _roleManager.CreateAsync(new IdentityRole(Roles.AdminRoleName));
            if (!await _roleManager.RoleExistsAsync(Roles.UserRoleName))
                await _roleManager.CreateAsync(new IdentityRole(Roles.UserRoleName));
            if (await _roleManager.RoleExistsAsync(Roles.UserRoleName)) 
                await _userManager.AddToRoleAsync(user, Roles.UserRoleName);
            
            //создать профиль нового пользователя
            var userProfile = new UserProfileDto();
            userProfile.Id = Guid.NewGuid();
            userProfile.User = user;
            userProfile.Rating = 0;
            userProfile.Section = new List<Section>();
            userProfile.Mission = new List<Mission>();

            await _userProfileService.AddAsync(userProfile);

            //var emailConfirmationToken = _userManager.GenerateEmailConfirmationTokenAsync(user);

            //TODO: тут ссылка на UI
            //var body = $"https://localhost:5001/account/confirmemail?token={emailConfirmationToken}&userId={user.Id}";
            //await _emailService.SendEmail(user.Email, "Подтвердите email", body);
        }

        public async Task ConfirmEmail([FromQuery] ConfirmEmailDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
            {
                throw new Exception("Пользователь не существует");
            }

            var confirmEmailResult = await _userManager.ConfirmEmailAsync(user, dto.Token);
            if (!confirmEmailResult.Succeeded)
            {
                throw new Exception(string.Join(",",confirmEmailResult.Errors));
            }
        }
        public async Task<LoginResponceDto> Login(LoginDto dto)
        {
            if(dto == null)
            {
                throw new Exception("Неверные данные для входа.");
            }

            var user = await _userManager.FindByNameAsync(dto.UserName);
            if(user == null)
            {
                throw new Exception("Неверные данные для входа");
            }

            if(!await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                throw new Exception("Неверный пароль");
            }
            
            //TODO: Подтверждение email
            //if (!user.EmailConfirmed)
            //{
                //throw new Exception("Email не подтвержден");
            //}

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, dto.UserName),
                new Claim("UserId", user.Id)
            };


            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
            
            //var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Secret:key"]));
            var authSigningKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);

            return new LoginResponceDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.ToArray(),
                Token = handler.WriteToken(token)
            };
        }

        public async Task CreateModerator(CreateModeratorDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.CurrentUserId);

            if (!await _userManager.IsInRoleAsync(user,Roles.AdminRoleName))
            {
                throw new Exception("Только админы могут создавать модераторов");
            }
            if (await _userManager.FindByNameAsync(dto.Login) != null)
            {
                throw new Exception("Модератор с таким логином уже существет");
            }
            //TODO: В автомапер внести нужную Dto
            var moderator = _mapper.Map<ApplicationUser>(dto);
            await _userManager.CreateAsync(moderator, dto.Password);
            await _userManager.AddToRoleAsync(moderator, Roles.ModeratorRoleName);
        }
    }
}