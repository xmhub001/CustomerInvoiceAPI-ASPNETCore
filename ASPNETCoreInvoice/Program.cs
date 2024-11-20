using ASPNETCoreInvoice.Repositories;
using ASPNETCoreInvoice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace ASPNETCoreInvoice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //AddDbContext
            builder.Services.AddDbContext<CustomerDbContext>(
                options => options.UseInMemoryDatabase("CustomerDb")
                );

            //AddCors - For Angular
            builder.Services.AddCors(options =>
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") //localhost:7086
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                })
            );

            //AddScoped
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
            builder.Services.AddScoped<IRepository<Bill>, BillRepository>();

            //AddControllers
            builder.Services.AddControllers();

            //Swagger: AddEndpointsApiExplorer and AddSwaggerGen
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Swagger: If Env IsDev then UseSwagger etc
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            //UseCors
            app.UseCors("MyCors");

            // Use MapControllers instead
            //app.MapGet("/", () => "Hello World!");
            app.MapControllers();

            app.Run();
        }
    }
}
