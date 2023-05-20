using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using GUVENYOLDAS.Data.DBName;
using GUVENYOLDAS.Infrastructure.DBName.Services;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces;
using GUVENYOLDAS.Infrastructure.DBName.Repositories;
using InterfaceDBName = GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;
using RepositoryDBName = GUVENYOLDAS.Infrastructure.DBName.Repositories.Base;

namespace GUVENYOLDAS.API.ExampleProject
{
    public class Startup
    {
        readonly string AllowAllOrigins = "AllowAllOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddDbContext<DBNameDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("YourDbConnection")));
            services.AddScoped<DbContext, DBNameDbContext>();
            services.AddTransient<InterfaceDBName.IUnitOfWork, RepositoryDBName.UnitOfWorkRepository>();



            #region |       ADD REPOSITORIES        |

            services.AddTransient<IProc, ProcRepository>();
            services.AddTransient<IQuery, QueryRepository>();
            services.AddTransient<ITable, TableRepository>();
            #endregion

            #region |       ADD SERVICES        |

            services.AddTransient<ProcService>();
            services.AddTransient<QueryService>();
            services.AddTransient<TableService>();

            #endregion


            services.AddCors(options =>
            {
                options.AddPolicy(AllowAllOrigins,
                    builder =>
                    {
                        builder
                        //.WithOrigins(new[] { "http://localhost:5173", "http://127.0.0.1:5173" })
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                      //  .AllowCredentials()
                      ;
                    });
            });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowAllOrigins);
            app.UseRouting();

            app.UseAuthorization();
            //app.UseMiddleware<LogMiddleware>();
            //app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
