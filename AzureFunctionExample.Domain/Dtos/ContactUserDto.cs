using AzureFunctionExample.Domain.Enums;
using System.Text.Json.Serialization;

namespace AzureFunctionExample.Domain.Dtos
{
    public class ContactUserDto
    {
        protected ContactUserDto(
            string address, 
            TypeContact typeContact,
            string email, 
            string phone)
        {
            Address = address;
            TypeContact = typeContact;
            Email = email;
            Phone = phone;
        }

        [JsonPropertyName("address")]
        public string Address { get; protected set; }

        [JsonPropertyName("type")]
        public TypeContact TypeContact { get; protected set; }

        [JsonPropertyName("email")]
        public string Email { get; protected set; }

        [JsonPropertyName("phone")]
        public string Phone { get; protected set; }

        public static ContactUserDto CreateContactUserDto(
            string address,
            TypeContact typeContact,
            string email,
            string phone)
        {
            return new ContactUserDto(address, typeContact, email, phone);
        }
    }
}