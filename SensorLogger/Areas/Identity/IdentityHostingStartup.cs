using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SensorLogger.Models;

[assembly: HostingStartup(typeof(SensorLogger.Areas.Identity.IdentityHostingStartup))]
namespace SensorLogger.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SensorLoggerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SensorLoggerContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<SensorLoggerContext>();
            });
        }
    }
}