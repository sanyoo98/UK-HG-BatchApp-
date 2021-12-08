using BatchApp.Data;
using BatchApp.IRepository;
using BatchApp.IService;
using BatchApp.Repository;
using BatchApp.Service;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BatchApp
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBatchRepository, BatchRepository>();

            //services.AddScoped<IUserService, UserService>();

            //services.AddVersionedApiExplorer(
            //    c =>
            //    {
            //        c.GroupNameFormat = "'v'VVV";
            //        c.SubstituteApiVersionInUrl = true;
            //        c.AssumeDefaultVersionWhenUnspecified = true;
            //        c.DefaultApiVersion = new ApiVersion(1, 0);
            //    });

            //services.AddApiVersioning(
            //    c =>
            //    {
            //        c.ReportApiVersions = true;
            //        c.AssumeDefaultVersionWhenUnspecified = true;
            //        c.DefaultApiVersion = new ApiVersion(1, 0);
            //    }
            //    );
            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();


                options.SwaggerDoc("BatchAppAPI",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Batch API",
                        Version = "1.0",
                    });

            //    options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "basic",
            //        In = ParameterLocation.Header,
            //        Description = "Basic Auth Header"
            //    });

            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "basic"
            //                }
            //            },
            //            new string[] { }
            //        }
            //    });
            });

            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddControllers();
            services.AddRouting();

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/BatchAppAPI/swagger.json", "Batch API");
                options.RoutePrefix = "";
            });

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

