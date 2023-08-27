using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Dtos
{
    public class StoryDTO
    {
        public int Id { get; set; }
        public string StoryText { get; set; } = null!;
        public MetaDataDTO MetaData { get; set; } = null!;
    }
}