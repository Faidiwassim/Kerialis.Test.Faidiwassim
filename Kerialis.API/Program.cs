using Kerialis.Datas.DbContexts;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Kerialis.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Enable CORS POLICY
builder.Services.AddCors(c =>
{
    c.AddPolicy("KerialisPolicies", options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

builder.Services.AddDbContext<KerialisContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Kerialis"));
});

// inject extensions 
builder.Services.AddRepositories();
builder.Services.AddServices();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
    o.ReportApiVersions = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
        options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api Kerialis",
        Description = "An ASP.NET Core Web API for managing Kerialis Test Project",
    });
});

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Create Database
    var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<KerialisContext>();
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

    });
}

app.UseCors("KerialisPolicies");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
