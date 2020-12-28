using AcmeCorporation.API.Shared.Enums;

namespace AcmeCorporation.API.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public int ContactNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}