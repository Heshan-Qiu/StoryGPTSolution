using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGPTProducer.Models
{
    public class Story
    {
        public long Id { get; set; }
        public long GeneratedId { get; set; }
        public string StoryText { get; set; } = null!;

        // navigation properties
        public MetaData MetaData { get; set; } = null!;
    }
}