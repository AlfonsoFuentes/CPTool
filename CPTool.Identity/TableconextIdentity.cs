


using CPTool.Identity.Models;

namespace CPTool.Identity
{
    public class TableContextIdentity : IdentityDbContext<ApplicationUser>
    {
        public TableContextIdentity(
            DbContextOptions<TableContextIdentity> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
