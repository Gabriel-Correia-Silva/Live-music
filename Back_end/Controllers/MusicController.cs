using Back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicContext _context;

        public MusicController(MusicContext context)
        {
            _context = context;
        }

        public IActionResult UploadMusic(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                byte[] musicData;
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    musicData = binaryReader.ReadBytes((int)file.Length);
                }
                // qual o erro aqui?
                var music = new MusicModel()
                {
                    Name = file.FileName,
                    MusicData = musicData
                };

                _context.Musics.Add(music);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
