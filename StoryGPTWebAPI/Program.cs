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

app.MapGet("/api/story/random", (DatabaseContext context) =>
{
    return context.Stories.AsEnumerable().OrderBy(s => new Random().Next()).Take(1).Select(s => new StoryContext(s.GeneratedId, s.StoryText));
});

app.MapGet("/api/story/random3", (DatabaseContext context) =>
{
    return context.Stories.AsEnumerable().OrderBy(s => new Random().Next()).Take(3).Select(s => new StoryContext(s.GeneratedId, s.StoryText)).ToArray();
});

app.Run();

record StoryContext(long Id, string Context);