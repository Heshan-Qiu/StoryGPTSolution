using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryGPTWebAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

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

app.Logger.LogInformation("StoryGPT Web API starting up");

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

app.MapGet("/api/story/random", (DatabaseContext dbContext, HttpContext httpContext) =>
{
    var queryParameters = httpContext.Request.Query;
    if (queryParameters.ContainsKey("ids"))
    {
        var ids = queryParameters["ids"].ToString().Split(',');
        app.Logger.LogInformation("Querying for specific IDs:");
        app.Logger.LogInformation(queryParameters["ids"].ToString());
        foreach (var id in ids)
        {
            app.Logger.LogInformation(id);
        }
        return dbContext.Stories.AsEnumerable().Where(s => !ids.Contains(s.GeneratedId.ToString()))
                        .OrderBy(s => new Random().Next()).Take(1).Select(
                            s => new StoryContent(s.GeneratedId, s.StoryText));
    }
    else
    {
        return dbContext.Stories.AsEnumerable().OrderBy(s => new Random().Next()).Take(1)
                        .Select(s => new StoryContent(s.GeneratedId, s.StoryText));
    }
});

app.MapGet("/api/story/random3", (DatabaseContext context) =>
{
    return context.Stories.AsEnumerable().OrderBy(s => new Random().Next()).Take(3).Select(s => new StoryContent(s.GeneratedId, s.StoryText)).ToArray();
});

app.MapGet("/api/story/last10", (DatabaseContext context) =>
{
    return context.Stories.Include(s => s.MetaData).OrderByDescending(s => s.Id).Take(10)
                          .Select(s => new StoryContentAndDateCreated(s.GeneratedId, s.StoryText,
                          s.MetaData.DateCreated)).ToArray();
});

app.Run();

record StoryContent(long Id, string Content);
record StoryContentAndDateCreated(long Id, string Content, DateTime DateCreated);