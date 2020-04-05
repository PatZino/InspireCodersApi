using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using InspireCodersApi.Models;
using InspireCodersApi.Models.Applications;
using InspireCodersApi.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InspireCodersApi.Data
{
    public class applicationDbContext: DbContext
    {
       

        public applicationDbContext(DbContextOptions<applicationDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
