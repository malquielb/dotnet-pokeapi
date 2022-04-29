using Poke.Services.Clients;
using Poke.Services.Services;
using Poke.Persistence.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddHttpClient<IPokemonService, PokemonService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddDbContext<FavoriteDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddCors(options =>
//     options.AddPolicy(name: MyAllowSpecificOrigins, builder  =>
//         builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
//         .AllowAnyHeader().AllowAnyMethod()
// ));

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
  builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
