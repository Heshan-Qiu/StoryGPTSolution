using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Dtos
{
    public class StoryDto
    {
        public long Id { get; set; }
        public string StoryText { get; set; } = null!;
        public MetaDataDto MetaData { get; set; } = null!;
    }
}