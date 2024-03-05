using EOD_Service_Layer.Implementation;
using EOD_Service_Layer.Interface;
using EOD_Db_Layer.Interface;
using EOD_Db_Layer.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EODDatabaseSettings>(
                builder.Configuration.GetSection(nameof(EODDatabaseSettings)));

builder.Services.AddScoped<IEODDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<EODDatabaseSettings>>().Value);

builder.Services.AddScoped<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("eoddatabasesettings:connectionstring")));

builder.Services.AddScoped<IEODDatabaseSettings, EODDatabaseSettings>();
builder.Services.AddScoped<IEodService, EodService>();
builder.Services.AddScoped<IWorkTypeService, WorkTypeService>();
builder.Services.AddScoped<INonEODService, NonEODService>();




builder.Services.AddControllers().AddJsonOptions(options =>
                                                     options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
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

app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.Run();
