using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Ukim.MusicAPI.Data;
using Ukim.MusicAPI.Models;

namespace Ukim.MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public AuthorsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthor()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/1/details
        [HttpGet("{id}/details")]
        public async Task<ActionResult<Author>> GetAuthorDetails(int id)
        {
            var album = await _context.Authors
                .FirstOrDefaultAsync(c => c.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // GET: api/Authors/1/fb-posts
        [HttpGet("{id}/fb-posts")]
        public async Task<ActionResult<Author>> GetAuthorFbPosts(int id)
        {
            var album = await _context.Authors
                .Include(a => a.FbPosts)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }
    }
}
