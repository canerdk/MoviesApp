using Microsoft.EntityFrameworkCore;
using Movie.DataAccess;
using Movie.Business.DependencyResolver;
using Movie.Business.Workers;
using Movie.Business.Abstract;
using Movie.Business.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IMovieManager, MovieManager>();

builder.Services.AddHostedService<MovieWorker>();

builder.Services.AddBusinessService();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        opt.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
