using Lab2_24.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2_24.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext>options) : base(options)
            {
            }
        public DbSet<Student> Students {  get; set; } 
    }
}
