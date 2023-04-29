using System;
namespace Authentication.ApplicationCore.Models
{
    public class AccountRequestModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string HashPassword { get; set; }
        public string Salt { get; set; }
    }
}

