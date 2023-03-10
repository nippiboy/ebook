using System.ComponentModel.DataAnnotations;

namespace ebook_server.Entitys
{
    public class Genre
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
