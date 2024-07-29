using E_CommerceProject0.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication10
{
    public class Startup
    {
        private readonly string _MyCors = "MyCors";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSingleton<E_CommerceContext>();
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(o =>
            o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddCors(options => options.AddDefaultPolicy(
            //    builder => builder.AllowAnyOrigin()
            //                 .AllowAnyHeader()
            //               .AllowAnyMethod()


            //    )

            //);
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("p1",
            //        policy =>
            //        {
            //            policy.WithOrigins("https://localhost:44376");

            //        });

            //    options.AddPolicy("AnotherPolicy",
            //        policy =>
            //        {
            //            policy.WithOrigins("https://localhost:44376")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});



            services.AddCors(Options =>
            {
                Options.AddPolicy(name: _MyCors, builder =>
                {
                    //builder.WithOrigins("https://localhost")
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader().AllowAnyMethod();
                });
            });




        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                      Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            });


            app.UseSwagger();
            app.UseSwaggerUI();
            //app.UseCors();
            //app.UseCors(_MyCors);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}