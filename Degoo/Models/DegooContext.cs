using Degoo.EntityConfigurations;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Degoo.Models
{
    public class DegooContext : DbContext
    {

        public DegooContext() : base("DegooContext")
        {
        }

        public DbSet<Link> Links {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LinkConfiguration());
        }

        [DbFunction("SqlServer", "SOUNDEX")]
        public static string SoundsLike(string keyword)
        {
            throw new NotImplementedException();
        }

    }
}