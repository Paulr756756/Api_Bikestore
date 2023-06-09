using AutoMapper;
using BusinessLayer_PaulBikeStore.Business.Services.Implementations;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Application;
using BusinessLayer_PaulBikeStore.Business.Services.Interfaces.Repository;
using BusinessLayer_PaulBikeStore.Helpers;
using BusinessLayer_PaulBikeStore.Repository.Implementations;
using BusinessLayer_PaulBikeStore.Repository.Interfaces;
using DataAccessLayer_PaulBikeStore.Repository.Implementations;
using DataAccessLayer_PaulBikeStore.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

namespace API_PaulBikeStore.Utilities
{
    public static class DependencyExtension
    {
        public static void RegisterBusinessDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.TryAddTransient<IBikeService, BikeService>();
            builder.Services.TryAddTransient<IBikeRepository, BikeRepository>();
            builder.Services.TryAddTransient<ISqlHelper, SqlHelper>();
            builder.Services.TryAddTransient<BaseRepository<BikeRepository>>();
            builder.Services.TryAddTransient<ICategoryService, CategoryService>();
            builder.Services.TryAddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.TryAddTransient<BaseRepository<CategoryRepository>>();
            builder.Services.TryAddTransient<BaseRepository<ProfitRepository>>();
            builder.Services.TryAddTransient<IProfitRepository, ProfitRepository>();
            builder.Services.TryAddTransient<IProfitsService, ProfitsService>();
            builder.Services.TryAddTransient<IOrderService, OrderService>();
            builder.Services.TryAddTransient<IOrdersRepository, OrdersRepository>();
            builder.Services.TryAddTransient<BaseRepository<OrdersRepository>>();
            builder.Services.TryAddTransient<BaseRepository<EmployeeRepository>>();
            builder.Services.TryAddTransient<IEmployeeRepository,EmployeeRepository>();
            builder.Services.TryAddTransient<IEmployeeService,EmployeeService>();
        }
        public static void RegisterStandardDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaulBikeStore", Version = "v1" });
            });
        }

        public static void RegisterAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfiles());
                mc.AllowNullDestinationValues = true;
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void UseDefaultBuilderMethods(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName.Equals("Local"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            //Middleware pipeline order always goes like this 

            // First of all we set the Cross Origin Policy
            app.UseCors(x => x.
            AllowAnyMethod().
            AllowAnyHeader().
            SetIsOriginAllowed(origin => true).
            AllowCredentials()
            );
            // Then we set the Use Https redirection
            app.UseHttpsRedirection();
            // Then we set the Routing
            app.UseRouting();
            // Then we set the Use Authentication
            app.UseAuthentication();
            // Then we set the Authorization Middleware
            app.UseAuthorization();
            // Then we set the Map controllers Middleware inside the pipeline
            app.MapControllers();
        }
    }
}
