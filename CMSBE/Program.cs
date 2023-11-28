using DomainLayer.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.ICouponRepository;
using RepositoryLayer.CouponRepository;
using DomainLayer.Model;
using ServicesLayer.IServicesLayer;
using ServicesLayer.ServicesLayer;

var builder = WebApplication.CreateBuilder(args);

// Add SQL to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repository to the container
builder.Services.AddScoped(typeof(ICouponRepo<>), typeof(CouponRepo<>));

// Add services to the container.
builder.Services.AddScoped<ICouponServices<Coupon>, CouponServices>();

// Add CORS to allow requests from any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();

    });
});

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

// Use CORS before UseAuthorization and UseEndpoints
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
