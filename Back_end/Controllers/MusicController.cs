using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly LiveMusicDbContext _context;

        public MusicController(LiveMusicDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<MusicModel>> PostMusic(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo não selecionado");
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var music = new MusicModel
            {
                Name = file.FileName,
                MusicData = memoryStream.ToArray()
            };

            _context.Musics.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusic", new { id = music.Id }, music);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicModel>> GetMusic(int id)
        {
            var music = await _context.Musics.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }

            return music;
        }
        
        [HttpGet("play/{id}")]
        public async Task<IActionResult> PlayMusic(int id)
        {
            var music = await _context.Musics.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }

            return File(music.MusicData, "audio/mpeg");
        }
    }
    
}