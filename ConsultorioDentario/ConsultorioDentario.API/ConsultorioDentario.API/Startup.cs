using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioDentario.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsultorioDentario.API
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
            services.AddDbContext<DataContext>(
            x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddControllers();
            services.AddScoped<IRepository, Repository>();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // var cors = require('cors');
            // app.use(cors({origin:true,credentials: true}));

            // app.use(function (req, res, next) {
            //      res.header('Access-Control-Allow-Credentials', true);
            //      res.header('Access-Control-Allow-Origin', req.headers.origin);
            //      res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
            //      res.header('Access-Control-Allow-Headers', 'Origin, Accept, Accept-Version, Content-Length, Content-MD5, Content-Type, Date, X-Api-Version, X-Response-Time, X-PINGOTHER, X-CSRF-Token,Authorization');
            //      if (req.method === "OPTIONS") {
            //          return res.status(200).end();
            //      } else {
            //          next();
            //      }
            // });
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
