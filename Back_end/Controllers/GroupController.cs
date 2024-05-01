
using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using System.Linq;
using Back_end.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly LiveMusicDbContext _context;
        public GroupController(LiveMusicDbContext context)
        {
            _context = context;
        }
        
        //Crud
        [HttpGet]
        public ActionResult<List<GroupModel>> AllGroups()
        {
            if (AllGroups() == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Groups.ToList();
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<GroupModel> GetGroup(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
            {
                return NotFound();
            }
            else
            {
                return group;
            }
        }
        
        [HttpPost]
        public ActionResult<GroupModel> AddGroup(GroupModel group)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Groups.Add(group);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGroup), new {id = group.IdGroup}, group);
        }
        
        [HttpPut("{id}")]
        public ActionResult<GroupModel> UpdateGroup (int id, GroupModel group)
        {
            if (id != group.IdGroup)
            {
                return BadRequest();
            }
            _context.Entry(group).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public ActionResult<GroupModel> DeleteGroup(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return group;
        }
    }
}