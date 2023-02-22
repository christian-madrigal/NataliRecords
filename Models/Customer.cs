using Microsoft.AspNetCore.Identity;
namespace NataliRecords.Models
{
    public class Customer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
