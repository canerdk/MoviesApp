using Microsoft.EntityFrameworkCore;
using Movie.DataAccess;
using Movie.Business.DependencyResolver;
using Movie.Business.Workers;
using Movie.Business.Abstract;
using Movie.Business.Concrete;
using EventBus.Extension;
using Movie.Business.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMasstransitWithRabbitMQ(builder.Configuration);

builder.Services.AddHttpClient<IMovieManager, MovieManager>();

builder.Services.AddHostedService<MovieWorker>();

builder.Services.AddBusinessService();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var connect = appDbContext.Database.CanConnect();
        if (connect)
        {
            appDbContext.Database.Migrate();
        }
    }
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
