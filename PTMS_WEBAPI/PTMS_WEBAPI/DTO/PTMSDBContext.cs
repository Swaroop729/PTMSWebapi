using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTMS_WEBAPI.DTO
{
    public class PTMSDBContext : DbContext
    {
        public PTMSDBContext(DbContextOptions<PTMSDBContext> options)  : base(options)
        {
        }

        public DbSet<Incidents> Incidents { get; set; }
    }
}
