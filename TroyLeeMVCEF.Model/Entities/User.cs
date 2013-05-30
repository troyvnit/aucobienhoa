namespace TroyLeeMVCEF.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TroyLeeMVCEF.Core.Functions;

    public class User
    {
        public User()
        {
            CreateOn = DateTime.Now;
        }

        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PasswordHashed { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public string Password
        {
            set { PasswordHashed = CommonFunctions.MD5EncryptPassword(value); }
        }
        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
