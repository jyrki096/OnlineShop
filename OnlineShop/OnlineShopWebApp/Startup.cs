using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories;
using OnlineShopWebApp.Helpers;
using Serilog;
using System;

namespace OnlineShopWebApp
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var connection = Configuration.GetConnectionString("PianoShop");

			services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));
			services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.LoginPath = "/Auth/Enter";
                options.LogoutPath = "//Auth/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            services.AddSingleton<IdentityErrorDescriber, RussianIdentityErrorDescriber>();
            services.AddTransient<IProductStorage, ProductDbRepository>();
			services.AddTransient<IBasketStorage, BasketDbRepository>();
			services.AddTransient<ICompareStorage, CompareDbRepository>();
			services.AddTransient<IFavoriteStorage, FavoriteDbRepository>();
			services.AddTransient<IOrderStorage, OrderDbRepository>();
			services.AddMemoryCache();
			services.AddTransient<ProductCache>();
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			
			app.UseSerilogRequestLogging();
			app.UseHttpsRedirection();

			app.UseStaticFiles(new StaticFileOptions()
			{
				OnPrepareResponse = ctx => 
				{
					ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
				}
			});

			app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
			{
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
