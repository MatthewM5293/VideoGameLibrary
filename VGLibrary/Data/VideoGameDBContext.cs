using Microsoft.EntityFrameworkCore;
using VGLibrary.Models;

namespace VGLibrary.Data
{
    public class VideoGameDBContext : DbContext
    {
        public VideoGameDBContext(DbContextOptions options) : base(options) 
        {

        }

        //will Create Games Table in database using Game.cs model
        public DbSet<Game> Games { get; set; } //table for db
    }
}
