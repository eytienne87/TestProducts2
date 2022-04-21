﻿using Domain.Shared;


namespace API.Dtos.Read
{
    public class MarketSegmentDescriptionReadDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}