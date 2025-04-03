
using MeetingRoomScheduling.Application.Commands.User;
using MeetingRoomScheduling.Application.Dtos.Auth;
using MeetingRoomScheduling.Application.Interfaces;
using MeetingRoomScheduling.Application.Interfaces.Auth;
using MeetingRoomScheduling.Application.UseCases.Auth;
using MeetingRoomScheduling.Application.UseCases.User;
using MeetingRoomScheduling.Application.Utils.Auth;
using MeetingRoomScheduling.Domain.Interfaces;
using MeetingRoomScheduling.Infrastructure.Context;
using MeetingRoomScheduling.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MeetingRoomScheduling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Meeting Room Scheduling API",
                    Version = "v1",
                    Description = "API para gerenciamento de reservas de salas de reunião"
                });
            });
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
            builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();

            builder.Services.AddScoped<TokenGenerator>();

            builder.Services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();

            // Repository DI
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));


            var jwtSettings = new JwtSettings();
            builder.Configuration.GetSection("Jwt").Bind(jwtSettings);
            builder.Services.AddSingleton(jwtSettings);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meeting Room Scheduling API v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
