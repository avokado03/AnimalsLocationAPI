using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class AnimalsLocationDbContext : DbContext
    {


        public AnimalsLocationDbContext(DbContextOptions<AnimalsLocationDbContext> options)
            : base(options)
        {
        }
    }
}
