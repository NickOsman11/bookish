using System.Text.Json.Serialization;
using Bookish.Repositories;
using Bookish.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookish
{
    public class Program 
    {
        public static void Main(string[] args) {
            
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
                {
                    options.AddPolicy(
                    name: "AllowAnyOriginPolicy",
                    builder =>
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });

            builder.Services.AddDbContext<BookishContext>();

            builder.Services.AddTransient<IAuthorRepo, AuthorRepo>();
            builder.Services.AddTransient<IBookRepo, BookRepo>();

            builder.Services.AddTransient<IAuthorService, AuthorService>();
            builder.Services.AddTransient<IBookService, BookService>();

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
                
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

            app.UseCors("AllowAnyOriginPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
