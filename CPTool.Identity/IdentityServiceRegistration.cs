


using Microsoft.Extensions.Configuration;

namespace CPTool.Identity
{
    public static class IdentityServiceRegistration
    {

        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {


                services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

                services.AddDbContext<TableContextIdentity>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(TableContextIdentity).Assembly.FullName)));


                services.AddIdentity<ApplicationUser, IdentiyRole>()
                    .AddEntityFrameworkStores<TableContextIdentity>().AddDefaultTokenProviders();


                services.AddTransient<IAuthService, AuthService>();

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };

                });


            }
            catch (Exception ex)
            {
                string exm = ex.Message;
            }


            return services;
        }

    }
}
