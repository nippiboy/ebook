using ebook_server.DTOs;
using ebook_server.Entitys;
using ebook_server.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace ebook_server.Controllers
{
    [ApiController]
    [Route("genre")]
    public class GenreController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly GenreConverter converter;

        public GenreController(ApplicationDbContext context) 
        {
            this.context = context;
            this.converter = new GenreConverter();
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> getAllGencres()
        {
            List<Genre> genres = new List<Genre>();
            try
            {
                genres = await context.Genres.ToListAsync();
            }
            catch (Exception ex) { return Problem();  }



            List<GenreDTO> genreDTOs = new List<GenreDTO>();
            genres.ForEach(genre =>
            {
                genreDTOs.Add(converter.CreateDTOFromGenre(genre));
            });

            return genreDTOs;
        }

        [HttpPost]
        public async Task<ActionResult> PostGenre([FromBody] GenreCreationDTO dto)
        {
            Genre genre = converter.CreateGenreFromCreation(dto);
            context.Genres.Add(genre);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (SqlException ex) { return Problem(ex.Message); }

            return NoContent();
        }

        [HttpDelete ("delete/{id:int}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            Console.WriteLine("TÖRLÉS");
            var genre = await context.Genres.AnyAsync(g => g.ID == id);

            if(!genre)
            {
                return NotFound();
            }

            context.Remove(new Genre() { ID = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
