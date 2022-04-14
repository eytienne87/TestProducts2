using AutoMapper;
using TestProducts2.Profiles;
using TestProducts2.Common;

namespace TestProducts2.Entities
{
    public class DescriptionResolver<TSourceMember, TDestinationMember> : IValueResolver<object, object, ICollection<TDestinationMember>>
        where TDestinationMember : class
        where TSourceMember : class
    {
        private readonly IMapper _mapper;


        public DescriptionResolver()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProductsProfile>()).CreateMapper();
        }

        public DescriptionResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ICollection<TDestinationMember> Resolve(object source, object destination, ICollection<TDestinationMember> descriptions, ResolutionContext context)
        {
            var resultDescriptions = (ICollection<TSourceMember>?)Helper.GetDynamicValue(source, "Descriptions");

            if (context.Options.Items.TryGetValue("lang", out object? lang) && lang != null)
            {
                resultDescriptions = resultDescriptions != null ? (ICollection<TSourceMember>)resultDescriptions.Where(q => (LanguageClass?)Helper.GetDynamicValue(q, "Language") == (LanguageClass)lang).ToHashSet() : null;
            }
            resultDescriptions = resultDescriptions != null ? (ICollection<TSourceMember>)resultDescriptions.OrderBy(q => (LanguageClass?)Helper.GetDynamicValue(q, "Language")).ToHashSet() : null;

            return _mapper.Map(resultDescriptions, descriptions);
        }
    }
}
