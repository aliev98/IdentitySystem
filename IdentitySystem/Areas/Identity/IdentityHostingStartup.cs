using IdentitySystem.Areas.Identity.Data;
using IdentitySystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentitySystem.Areas.Identity.IdentityHostingStartup))]

namespace IdentitySystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdDbContextConnection")));

                services.AddDefaultIdentity<IdentitySystemUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<IdDbContext>();
            });
        }
    }
}