using System;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Ukim.MusicAPI.Data;
using Ukim.MusicAPI.Models;

namespace Ukim.MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public AlbumsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        // GET: api/Albums/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albums
                .Include(a => a.Authors)
                .Include(a => a.Contributors)
                .Include(a => a.Category)
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }
    }
}
