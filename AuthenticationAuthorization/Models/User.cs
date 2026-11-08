using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAuthorization.Models
{
    public enum UserRole
    {
        Admin,
        Guru,
        Siswa
    }

    public class User
    {
        //Fields
        public User(string username, string email, string fullName, UserRole role)
        {
            this.username = username;
            this.email = email;
            this.fullName = fullName;
            this.role = role;
        }

        private long id;
        private string username;
        private string email;
        private string fullName;
        private UserRole role;
        private bool isActive = true;

        [DisplayName("User ID")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        [StringLength(150, ErrorMessage = "Email must not exceed 150 characters")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 150 characters")]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        [DisplayName("Role")]
        public UserRole Role
        {
            get { return role; }
            set { role = value; }
        }

        [DisplayName("Active")]
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
