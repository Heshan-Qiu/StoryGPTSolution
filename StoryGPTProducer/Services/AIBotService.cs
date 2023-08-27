using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Microsoft.EntityFrameworkCore;
using StoryGPTProducer.Models;
using StoryGPTProducer.Helpers;
using IdGen;
using System.Text.Json;

namespace StoryGPTProducer.Services
{
    public class AIBotService : BackgroundService
    {
        private readonly ILogger<AIBotService> _logger;
        private readonly IConfiguration _configuration;

        private DatabaseContext _context;
        private string _apiKey;
        private string _model;
        private string _prompt;
        private string _author;
        private int _delay;

        public AIBotService(IConfiguration configuration, ILogger<AIBotService> logger)
        {
            _configuration = configuration;
            _logger = logger;

            _context = new DatabaseContext(_configuration);

            var section = _configuration.GetSection("AIBot");
            _apiKey = section.GetValue<string>("APIKey");
            _model = section.GetValue<string>("Model");
            _prompt = section.GetValue<string>("Prompt");
            _author = section.GetValue<string>("Author");
            _delay = _configuration.GetValue<int>("Delay");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SaveStory(GenerateStory(await GenerateContext()));
                await Task.Delay(_delay);
            }
        }

        private async Task<string> GenerateContext()
        {
            _logger.LogDebug($"Generating context with API key: {_apiKey}, model: {_model}, prompt: {_prompt} ...");
            var client = new OpenAIClient(_apiKey);
            var response = await client.GetCompletionsAsync(_model, _prompt);
            var context = string.Concat(response.Value.Choices.Select(c => c.Text));
            _logger.LogDebug($"Return context: {context}");
            return context;
        }

        private Story GenerateStory(string storyText)
        {
            var id = new IdGenerator(0).CreateId();

            return new Story
            {
                GeneratedId = id,
                StoryText = storyText,
                MetaData = new MetaData
                {
                    Author = _author,
                    Model = _model,
                    Prompt = _prompt,
                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                }
            };
        }

        private async Task SaveStory(Story story)
        {
            _logger.LogDebug($"Saving story: {JsonSerializer.Serialize(story)} ...");
            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();
            _logger.LogDebug($"Saving story complete.");
        }
    }
}