using Domain.Models;
using Domain.Shared;
using System.Collections.Generic;

namespace NUnitTests.TestsHelper
{
    public static class DataInitializer
    {
        public static List<Benefit> CreateRandomBenefits()
        {
            var benefits = new List<Benefit>();
            benefits.Add(new Benefit()
            {
                Id = 1,
                Descriptions = new HashSet<BenefitDescription>()
                {
                    new BenefitDescription() { BenefitId = 1, Language = LanguageClass.fr, Description = "Pratique"},
                    new BenefitDescription() { BenefitId = 1, Language = LanguageClass.en, Description = "Convenient"}
                }
            });
            benefits.Add(new Benefit()
            {
                Id = 2,
                Descriptions = new HashSet<BenefitDescription>()
                {
                    new BenefitDescription() { BenefitId = 2, Language = LanguageClass.fr, Description = "plaisant"},
                    new BenefitDescription() { BenefitId = 2, Language = LanguageClass.en, Description = "cool"}
                }
            });
            return benefits;
        }
    }
}
