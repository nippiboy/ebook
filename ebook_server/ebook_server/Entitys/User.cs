using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ebook_server.Entitys
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }

        [NotMapped]
        [Required]
        public string UserPassword { get; set; }

        public int password { set;  get; }

        public int CreditAmount { get; set; }


        public User() {
        }

        public void GenereateHashPassword()
        {
            password = UserPassword.GetHashCode();
        }
    }
}
