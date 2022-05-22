using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.Repository;
using BackEndAprovacao.RepositoryFolder;
using BackEndAprovacao.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace BackEndAprovacao
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
            services.AddDbContext<IAprovacaoContext, AprovacaoContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(Configuration
            .GetConnectionString("ConectionString")));

            InjetarRepositorys(services);
            InjetarServices(services);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEndAprovacao", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void InjetarRepositorys(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEscritorioRepository, EscritorioRepository>();
            services.AddScoped<IReclamanteRepository, ReclamanteRepository>();
            services.AddScoped<IProcessoRepository, ProcessoRepository>();
        }

        private static void InjetarServices(IServiceCollection services)
        {
            services.AddScoped<IServices<Escritorio>, EscritorioService>();
            services.AddScoped<IServices<Reclamante>, ReclamanteService>();
            services.AddScoped<IServices<Processo>, ProcessoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEndAprovacao v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(c =>
                    c
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}