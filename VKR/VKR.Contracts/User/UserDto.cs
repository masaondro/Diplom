using System;

namespace VKR.Contracts.User
{
    public class UserDto : DtoBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}