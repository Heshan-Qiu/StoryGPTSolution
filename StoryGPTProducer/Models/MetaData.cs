using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGPTProducer.Models
{
    public class MetaData
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Prompt { get; set; } = null!;

        // foreign key
        public long StoryId { get; set; }
        // navigation properties
        public Story Story { get; set; } = null!;
    }
}