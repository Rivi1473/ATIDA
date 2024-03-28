using HMO_Corona.API.Mapping;
using HMO_Corona.Core.Mapping;
using HMO_Corona.Core.Repositories;
using HMO_Corona.Core.Services;
using HMO_Corona.Data;
using HMO_Corona.Data.Repositories;
using HMO_Corona.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<ICoronaDetailsService, CoronaDetailsService>();
builder.Services.AddScoped<IPersonalDetailsService, PersonalDetailsService>();
builder.Services.AddScoped<IPersonalDetailsRepository, PersonalDetailsRepository>();
builder.Services.AddScoped<ICoronaDetailsRepository, CoronaDetailsRepository>();
builder.Services.AddAutoMapper(typeof(ApiMappingProfile),typeof(DtoMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(p => p
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
