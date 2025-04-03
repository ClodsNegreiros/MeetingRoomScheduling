
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

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

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication();


            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Meeting Room Scheduling API",
                    Version = "v1",
                    Description = "API para gerenciamento de reservas de salas de reunião"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT no formato: Bearer {seu_token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            var app = builder.Build();

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
