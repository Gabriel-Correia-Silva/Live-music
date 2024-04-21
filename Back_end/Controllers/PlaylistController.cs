using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly LiveMusicDbContext _context;
        public PlaylistController(LiveMusicDbContext context)
        {
            _context = context;
        }

        //Crud
        [HttpGet]
        public ActionResult<List<PlaylistModel>> AllPlaylists()
        {
            var playlists = _context.Playlists.ToList();
            if (playlists == null || !playlists.Any())
            {
                return NotFound();
            }
            else
            {
                return playlists;
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<PlaylistModel> GetPlaylist(int id)
        {
            var playlist = _context.Playlists.Find(id);
            if (playlist == null)
            {
                return NotFound();
            }
            else
            {
                return playlist;
            }
        }
        
        [HttpPost]
        public ActionResult<PlaylistModel> AddPlaylist(PlaylistModel playlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPlaylist), new {id = playlist.IdPlaylist}, playlist);
        }
        
        [HttpPut("{id}")]
        public ActionResult<PlaylistModel> UpdatePlaylist(int id, PlaylistModel playlist)
        {
            if (id != playlist.IdPlaylist)
            {
                return BadRequest();
            }
            _context.Entry(playlist).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public ActionResult<PlaylistModel> DeletePlaylist(int id)
        {
            var playlist = _context.Playlists.Find(id);
            if (playlist == null)
            {
                return NotFound();
            }
            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
            return playlist;
        }
    }
}