using AutoMapper;
using IdGen;
using StoryGPTEntityAPI.Db;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Helpers;
using StoryGPTEntityAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("StoryGPT") ?? "Data Source=StoriesGPT.db";
builder.Services.AddSqlite<StoryGPTDbContext>(connectionString);
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapGet("/api/story", (StoryGPTDbContext context, IMapper mapper, long id) =>
{
    var story = context.Story.FirstOrDefault(s => s.Id == id);
    return Results.Ok(mapper.Map<StoryDto>(story));
}).WithName("GetStory");

app.MapPost("/api/story", async (StoryGPTDbContext context, IMapper mapper, StoryDto story) =>
{
    long id = new IdGenerator(0).CreateId();
    story.Id = id;
    await context.Story.AddAsync(mapper.Map<Story>(story));
    await context.SaveChangesAsync();
    return Results.Ok(new { Id = id });
}).WithName("CreateStory");

app.Run();