using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;

namespace MultiShop.Cargo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.RequireHttpsMetadata = false; //appsettings.json i�erisinde http verdi�imiz i�in false dedik
                opt.Audience = "ResourceCargo"; // Bizim config taraf�nda dinleyici olan keyimiz

            });

            builder.Services.AddDbContext<CargoContext>();
            builder.Services.AddScoped<ICargoCompanyDal, EFCargoCompanyDal>();
            builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();

            builder.Services.AddScoped<ICargoCustomerDal, EFCargoCustomerDal>();
            builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();

            builder.Services.AddScoped<ICargoDetailDal, EFCargoDetailDal>();
            builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();

            builder.Services.AddScoped<ICargoOperationDal, EFCargoOperationDal>();
            builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();

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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
