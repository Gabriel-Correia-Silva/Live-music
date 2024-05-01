using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using System.Linq;
using Back_end.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly LiveMusicDbContext _context;

        public PlaylistController(LiveMusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Playlist
        [HttpGet]
        public ActionResult<IEnumerable<PlaylistModel>> GetPlaylists()
        {
            return _context.Playlists.ToList();
        }

        // GET: api/Playlist/5
        [HttpGet("{id}")]
        public ActionResult<PlaylistModel> GetPlaylist(int id)
        {
            var playlist = _context.Playlists.Find(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return playlist;
        }

        // POST: api/Playlist
        [HttpPost]
        public ActionResult<PlaylistModel> PostPlaylist(PlaylistModel playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPlaylist), new { id = playlist.IdPlaylist }, playlist);
        }

        // PUT: api/Playlist/5
        [HttpPut("{id}")]
        public IActionResult PutPlaylist(int id, PlaylistModel playlist)
        {
            if (id != playlist.IdPlaylist)
            {
                return BadRequest();
            }

            _context.Entry(playlist).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Playlist/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlaylist(int id)
        {
            var playlist = _context.Playlists.Find(id);

            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
