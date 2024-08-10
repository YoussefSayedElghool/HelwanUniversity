
using EmployeeUnitOfWorkVersion.Business.Repository;
using HelwanUniversity.Core.Contracts.Repositories;
using HelwanUniversity.Core.Contracts.UnitOfWork;
using HelwanUniversity.Infrastructure.Caching;
using HelwanUniversity.Infrastructure.Data.EFCore;
using HelwanUniversity.Infrastructure.Query;
using HelwanUniversity.Infrastructure.Repositories;
using HelwanUniversity.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HelwanUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(optionBuilder =>
            {

                optionBuilder.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddMemoryCache();

            //builder.Services.AddScoped<IBaseRepository, BaseRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            builder.Services.AddMediatR(typeof(GetAllStudentsQuery).Assembly);

            builder.Services.Decorate<IStudentRepository, StudentRepositoryCachingDecorator>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
