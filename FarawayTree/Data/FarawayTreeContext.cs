using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FarawayTree.Models;

namespace FarawayTree.Data
{
    public class FarawayTreeContext : DbContext
    {
        public FarawayTreeContext (DbContextOptions<FarawayTreeContext> options)
            : base(options)
        {
        }

        public DbSet<FarawayTree.Models.BucketListItem> BucketListItem { get; set; } = default!;

        public DbSet<FarawayTree.Models.WatchList> WatchList { get; set; } = default!;
    }
}
