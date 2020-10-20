using AzureFunctionExample.Domain.Dtos;
using AzureFunctionExample.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunctionExample.DataBase
{
    public static class Db
    {
        private static readonly List<UserDto> users = new List<UserDto>()
        {
            UserDto.CreateUserDto(
                "Fernando",
                "Concepción Gutiérrez",
                new DateTimeOffset(1986, 1, 11, 0, 0, 0, new TimeSpan()),
                new List<ContactUserDto>()
                {
                    ContactUserDto.CreateContactUserDto("Viseo Consulting", TypeContact.Work, "f.c@viseo.com", "915151383"),
                    ContactUserDto.CreateContactUserDto("My house", TypeContact.Personal, "f.c@house.com", "666999666"),
                }),
            UserDto.CreateUserDto(
                "Sergio",
                "Viseo",
                new DateTimeOffset(1987, 3, 1, 0, 0, 0, new TimeSpan()),
                new List<ContactUserDto>()
                {
                    ContactUserDto.CreateContactUserDto("Viseo Consulting", TypeContact.Work, "s.v@viseo.com", "915151383"),
                    ContactUserDto.CreateContactUserDto("My house", TypeContact.Personal, "s.v@house.com", "666999666"),
                })
        };

        public static IEnumerable<UserDto> GetUsers()
        {
            return users.AsEnumerable();
        }

        public static UserDto GetUserById(Guid id)
        {
            return users.Find(u => u.Id == id);
        }

        public static UserDto CreateUser(
            string name,
            string surname,
            DateTimeOffset birthday)
        {
            var user = UserDto.CreateUserDto(name, surname, birthday, new List<ContactUserDto>());

            users.Add(user);

            return user;
        }
    }
}
