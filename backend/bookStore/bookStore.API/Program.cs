using bookStore.DataAcess;
using bookStore.DataAcess.Repository;
using BookStore.Aplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace bookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<BookStoreDbContext>(options =>
            
            options.UseNpgsql("Server=localhost;Username=postgres;Password=Miku_1Love;Database=postgres"));

            builder.Services.AddScoped<IBooksServices,BooksServices>();
            builder.Services.AddScoped<IBookReposytory,BookReposytory>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Books API", Version = "v1" });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.MapControllers();
            app.UseCors(
                x => 
                {
                    x.WithHeaders().AllowAnyOrigin();
                    x.WithOrigins("http://localhost:3000");
                    x.WithMethods().AllowAnyMethod();
                });
            app.Run();
        }
    }
}
