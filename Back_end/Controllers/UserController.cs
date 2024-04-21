using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Back_end.Data;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {   
        private readonly LiveMusicDbContext _context;
        public UserController(LiveMusicDbContext context)
        {
            _context = context;
        }
        
        //Crud
        [HttpGet]
        public ActionResult<List<UserModel>> AllUsers()
        {
            if (AllUsers() == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Users.ToList();
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
        }
        
        [HttpPost]
        public ActionResult<UserModel> AddUser(UserModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new {id = user.IdUser}, user);
        }
        
        [HttpPut("{id}")]
        public ActionResult<UserModel> UpdateUser (int id, UserModel user)
        {
            if (id != user.IdUser)
            {
                return BadRequest();
            }else if (!_context.Users.Any(u => u.IdUser == id))
            {
                return NotFound();
            }
            
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<UserModel> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound(id);
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
    
}