﻿using TestProducts2.Entities;
using TestProducts2.Models;

namespace TestProducts2.Dtos
{
    public class MarketSegmentDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}