/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using VKR.AppServices.Services;
using VKR.DataAccess;
using VKR.Domain.Entities;
using VKR.Infrastructure.Repository;
using VKR.Mapper.Mapping;

namespace VKR
{
    public class Startup
    {
        private readonly int _maxRequestLimit = int.MaxValue;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            //services.AddSingleton<IMissionService, MissionService>();

            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));
            services.AddScoped<DbContext>(s => s.GetRequiredService<BaseDbContext>());
            // конфигурация автомаппера
            services.AddAutoMapper(typeof(ApplicationMapperProfile));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddUserStore<BaseDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IMissionService, MissionService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IUserService, UserService>();
            
            
            services.AddControllers();
            
            
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Secret:Key"])),
                };
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "VKR", Version = "v1"}); 
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);                
                c.IncludeXmlComments(xmlPath); 
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VKR v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
//using VKR.AppServices.Hubs;
//using VKR.AppServices.Options;
using VKR.AppServices.Services;
using VKR.Contracts;
using VKR.DataAccess;
using VKR.Domain.Entities;
using VKR.Infrastructure.Repository;
using VKR.Mapper.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
//using MassTransit;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Http.Features;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;
using VKR.AppServices.Services.JWT;
using VKR.AppServices.Services.UserProfile;
using VKR.Infrastructure;
using VKR.Migrations;

//using StackExchange.Redis;
//using RedLockNet;
//using RedLockNet.SERedis.Configuration;
//using RedLockNet.SERedis;

namespace VKR
{
    public class Startup
    {
        private readonly int _maxRequestLimit = int.MaxValue;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            //services.AddCors();

            services.AddOptions();
            
            //services.Configure<FileSaveOptions>(Configuration.GetSection("Files"));
            //services.Configure<RedisOptions>(Configuration.GetSection("RedisOptions"));
            
            services.AddDbContext<BaseDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));
            
            services.AddScoped<DbContext>(s => s.GetRequiredService<BaseDbContext>());
            // конфигурация автомаппера
            services.AddAutoMapper(typeof(ApplicationMapperProfile));
            //services.AddAutoMapper(typeof(FileMapperProfile));
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IMissionService, MissionService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            
            //services.AddTransient<IFileService, FileService>();
            //services.AddScoped<IFileRepository, FileRepository>();
            //services.AddSingleton<IStorageManager, RedisStorageManager>();
            //services.AddSingleton(builder => Configuration.GetSection(nameof(RedisOptions)).Get<RedisOptions>());

            //services.AddSingleton<ConnectionMultiplexer>(sp =>
            //{
               // return ConnectionMultiplexer.Connect(sp.GetRequiredService<RedisOptions>().ConnectionString);
            //});
            services.AddSingleton<IDistributedLockFactory>(sp =>
             {
                 var connection = sp.GetRequiredService<ConnectionMultiplexer>();
                 var multiplexers = new List<RedLockMultiplexer>
                    {
                        connection
                    };
                 return RedLockFactory.Create(multiplexers);
             });
            //services.AddSingleton<ICacheService, CacheService>();

            //services.AddHttpClient<IYandexDiskApiClient, YandexDiskApiClient>(options =>
            //{
                //options.BaseAddress = new Uri("https://cloud-api.yandex.net/v1/disk/");
                //options.Timeout = TimeSpan.FromSeconds(20);
            //});
            
            services.AddControllers();
            //services.AddMvc()
                //.AddFluentValidation(v=>v.RegisterValidatorsFromAssemblyContaining<PostDtoValidator>());

            // https://masstransit-project.com/usage/configuration.html#asp-net-core
            /*services.AddMassTransit(
                conf =>
                {
                    conf.UsingRabbitMq(
                        (context, c) =>
                        {
                            c.Host("localhost", 5772, "My_Vhost",
                                host =>
                                {
                                    host.Username("solar_academy_user");
                                    host.Password("hkNwX7v4FTyqtacEHFs2r");
                                    host.UseCluster(cls =>
                                        {
                                            cls.Node("localhost:5772");
                                            cls.Node("localhost:5773");
                                            cls.Node("localhost:5774");
                                        }
                                    );
                                }
                            );
                        }
                    );
                }
            );*/

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BaseDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddCors(options =>
            {
                options.AddPolicy("AnotherPolicy",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    /*ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Secret:Key"])),*/
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidIssuer = AuthOptions.ISSUER,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
                };
            });

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VKR.Api", Version = "v1" });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);                
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = _maxRequestLimit;
            });
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = _maxRequestLimit;
                x.MultipartBodyLengthLimit = _maxRequestLimit;
                x.MultipartHeadersLengthLimit = _maxRequestLimit;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoApi.Api v1"));
            //}
            
            
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            app.UseAuthorization();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHub<MessageHub>("/message");
                //endpoints.MapHub<DrawHub>("/draw");
            });
            
            
            
        }
    }
}