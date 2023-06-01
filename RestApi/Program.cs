using Microsoft.EntityFrameworkCore;
using RestApi;
using RestApi.DataLayer;
using RestApi.Repository;
using RestApi.BusinessLayer;
using RestApi.Repository.IRepository;





var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddDbContext<FruitviceApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IFruitviceRepository, FruitviceRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers();


builder.Services.AddHttpClient<IFruitServices, FruitServices>();
builder.Services.AddScoped<IFruitServices, FruitServices>();


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
