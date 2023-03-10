using ebook_server.DTOs;
using ebook_server.Entitys;
using System.Text;

namespace ebook_server.Helper
{
    public class GenreConverter
    {
        public Genre CreateGenreFromDTO(GenreDTO dto) 
        {
            return new Genre() { ID = dto.Id, Name = dto.Name };
        }

        public GenreDTO CreateDTOFromGenre(Genre genre)
        {
            return new GenreDTO() { Id = genre.ID, Name = genre.Name };
        }

        public Genre CreateGenreFromCreation(GenreCreationDTO dto)
        {
            string[] temp = new string[2];
            temp[0] = dto.name.Substring(0, 1).ToUpper();
            temp[1] = dto.name.Substring(1, dto.name.Length-1).ToLower();
            return new Genre() {Name = temp[0] + temp[1] };
        }
    }
}
