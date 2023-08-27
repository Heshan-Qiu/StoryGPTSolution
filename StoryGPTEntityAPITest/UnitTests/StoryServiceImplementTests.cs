using StoryGPTEntityAPI.Data;
using StoryGPTEntityAPI.Models;
using StoryGPTEntityAPI.Services;

namespace StoryGPTEntityAPITest.UnitTests
{
    public class StoryServiceImplementTests
    {
        [Fact]
        public Story GetStoryByIdTest()
        {
            // Arrange
            var storyId = 1;

            // Act
            var story = StoryServiceImplement.Instance.GetStoryById(context, storyId);

            // Assert
            Assert.Equal(storyId, story.Id);
            return story;
        }
    }
}