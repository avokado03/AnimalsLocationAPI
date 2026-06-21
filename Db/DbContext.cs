using Microsoft.EntityFrameworkCore;
using AnimalsLocationAPI.Domain;

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
