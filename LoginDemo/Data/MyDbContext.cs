using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoginDemo.Data
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : IdentityDbContext (options)
    {

    }
}
