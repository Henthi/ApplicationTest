using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class ApplicationContext: DbContext
    {

        public virtual DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }

    }
}
