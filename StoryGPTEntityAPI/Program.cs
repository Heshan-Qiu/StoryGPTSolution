using AutoMapper;
using StoryGPTEntityAPI.Data;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Helpers;
using StoryGPTEntityAPI.Models;
using StoryGPTEntityAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoryGPTDbContext>();
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
    var story = StoryServiceImplement.Instance.GetStoryById(context, id);
    return Results.Ok(mapper.Map<StoryDTO>(story));
}).WithName("GetStory");

app.MapPost("/api/story", async (StoryGPTDbContext context, IMapper mapper, StoryDTO story) =>
{
    long id = await StoryServiceImplement.Instance.CreateStoryAsync(context, mapper.Map<Story>(story));
    return Results.Ok(new { Id = id });
}).WithName("CreateStory");

app.Run();