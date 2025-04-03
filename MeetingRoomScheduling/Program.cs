
using MeetingRoomScheduling.Application.Commands.User;
using MeetingRoomScheduling.Application.Interfaces;
using MeetingRoomScheduling.Application.UseCases.User;
using MeetingRoomScheduling.Domain.Interfaces;
using MeetingRoomScheduling.Infrastructure.Context;
using MeetingRoomScheduling.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add Mediator DI
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(
                    typeof(CreateUserCommand).Assembly,
                    typeof(CreateUserUseCase).Assembly
                ));

            // UseCase DI
            builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();

            // Repository DI
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
