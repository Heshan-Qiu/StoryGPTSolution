using Microsoft.EntityFrameworkCore;
using StoryGPTProducer.Helpers;
using StoryGPTProducer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddHostedService<AIBotService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

app.Logger.LogInformation("Starting up");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.Logger.LogInformation("In Development environment");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.Logger.LogInformation("In Production environment");
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapGet("/", (DatabaseContext context) =>
{
    return context.Stories.Include(s => s.MetaData).OrderByDescending(s => s.Id).Take(10)
        .Select(s => new StoryContent(s.StoryText, s.MetaData.DateCreated)).ToArray();
});

app.Run();

record StoryContent(string Content, DateTime DateCreated);