using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AzureFunctionExample.Domain.Dtos
{
    public class UserDto
    {
        protected UserDto(
            string name,
            string surname,
            DateTimeOffset birthday,
            IEnumerable<ContactUserDto> contactData)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Birthday = birthday;
            ContactData = contactData;
        }

        [JsonPropertyName("id")]
        public Guid Id { get; protected set; }

        [JsonPropertyName("name")]
        public string Name { get; protected set; }

        [JsonPropertyName("surname")]
        public string Surname { get; protected set; }

        [JsonPropertyName("birthday")]
        public DateTimeOffset Birthday { get; protected set; }

        [JsonPropertyName("contact")]
        public IEnumerable<ContactUserDto> ContactData {get; protected set; }

        public void AddContactInformation(IEnumerable<ContactUserDto> contactData)
        {
            ContactData = (new List<ContactUserDto>(ContactData)).Concat(contactData);
        }

        public void AddContactInformation(ContactUserDto contactInformation)
        {
            AddContactInformation(new List<ContactUserDto>() { contactInformation });
        }

        public static UserDto CreateUserDto(
            string name,
            string surname,
            DateTimeOffset birthday,
            IEnumerable<ContactUserDto> contactData)
        {
            return new UserDto(name, surname, birthday, contactData);
        }
    }
}
