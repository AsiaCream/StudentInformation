using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StudentInformation.Models
{
    public class StudentContext:IdentityDbContext<User>
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>(e =>
            {
                //建立索引，为以后添加学号以及年龄进行升降序功能预留
                e.Index(x => x.Id);
                e.Index(x => x.Age);
            });
        }
    }
}
