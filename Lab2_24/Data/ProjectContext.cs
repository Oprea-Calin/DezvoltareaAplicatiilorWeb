using Microsoft.EntityFrameworkCore;

namespace Lab2_24.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext>options) : base(options)
            {
            }

    }
}
