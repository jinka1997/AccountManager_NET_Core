using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api31.Models
{
    [Table("m_user_account")]
    public partial class UserAccount : Entity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }

        public void CreateUser(string email, string password)
        {

        }
    }
}
