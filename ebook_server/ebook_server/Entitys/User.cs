using System.ComponentModel.DataAnnotations;

namespace ebook_server.Entitys
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int CreditAmount { get; set; }


        public User() { }
    }
}
