using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

namespace MultiShop.Order.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.RequireHttpsMetadata = false; //appsettings.json içerisinde http verdiðimiz için false dedik
                opt.Audience = "ResourceOrder"; // Bizim config tarafýnda dinleyici olan keyimiz

            });

            builder.Services.AddDbContext<OrderContext>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddApplicationService(builder.Configuration);

            builder.Services.AddScoped<GetAddressByIdQueryHandler>();
            builder.Services.AddScoped<GetAddressQueryHandler>();
            builder.Services.AddScoped<CreateAddressCommandHandler>();
            builder.Services.AddScoped<UpdateAddressCommandHandler>();
            builder.Services.AddScoped<RemoveAddressCommandHandler>();

            builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
            builder.Services.AddScoped<GetOrderDetailQueryHandler>();
            builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
            builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
            builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();

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
