using back_cooking.data;
using back_cooking.IService;
using back_cooking.Models;
using back_cooking.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DBSettings>(
    builder.Configuration.GetSection(nameof(DBSettings)));

builder.Services.AddSingleton<IDBSettings>(sp =>
    sp.GetRequiredService<IOptions<DBSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("DBSettings:ConnectionString")));

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ISportService, SportService>();
builder.Services.AddScoped<IPersonSportService, PersonSportService>();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddCors(options =>
        options.AddPolicy(name: "AllowSpecific", p => p.WithOrigins("http://localhost:4200")
                                                  .AllowAnyMethod()
                                                  .AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowSpecific");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.Run();
