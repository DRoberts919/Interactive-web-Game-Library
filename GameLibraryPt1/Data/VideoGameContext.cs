using GameLibraryPt1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryPt1.Data
{
    public class VideoGameContext : DbContext
    {


        public VideoGameContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Game> Games { get; set; }


    }
}
