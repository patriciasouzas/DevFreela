using DevFreela.API.Filters;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Validators;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DevFreela.API
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
			var connectionString = Configuration.GetConnectionString("DevFreelaCs");
			services.AddDbContext<DevFreelaDbContext>(options =>
			{
				options.UseMySql(connectionString, new MySqlServerVersion(new System.Version(5, 7)));
			});

			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ISkillRepository, SkillRepository>();

			services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

			services.AddFluentValidationAutoValidation();
			services.AddFluentValidationClientsideAdapters();
			services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

			services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));

			//services.AddMediatR(typeof(CreateProjectCommand));

			services.AddRazorPages();
			services.AddMvcCore().AddApiExplorer();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto DevFreela v1");
			});

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
