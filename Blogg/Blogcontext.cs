using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blogg
{
    public class Blogcontext : DbContext
    {
        public DbSet<category> categories { get; set; }
        public DbSet<post> posts { get; set; }
    }
}