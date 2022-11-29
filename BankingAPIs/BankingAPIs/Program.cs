using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using BankingAPIs.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add automappeerr
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped <ISignUp, Signup>();
builder.Services.AddScoped<ICustomerAccount, AccountRepo>();
var connectionString = builder.Configuration.GetConnectionString(name: "DefaultConnections");
//var cc = builder.Configuration.GetSection("DefaultConnections");
var b = Environment.GetEnvironmentVariable("DefaultConnections");

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBank>(opt =>
{ 

    //opt.UseMySql(b)
    opt.UseMySql(b, ServerVersion.AutoDetect(b));
    //opt.UseMySql(Environment.GetEnvironmentVariable("Connectionstring"))connectionString
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

app.UseAuthorization();

app.MapControllers();

app.Run();
