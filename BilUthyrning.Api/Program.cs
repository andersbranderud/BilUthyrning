using BilUthyrning.Api.Services.Interfaces;
using Uthyrning.BusinessLayer;
using Uthyrning.DataAccessLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// Register the UthyrningService and IUthyrningBL
builder.Services.AddScoped<IUthyrningService, UthyrningsService>();
builder.Services.AddScoped<IUthyrningBL, UthyrningBL>();
// Register the data access layer
builder.Services.AddScoped<IUthyrningsDal, UthyrningsDal>();

app.Run();