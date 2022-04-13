using AutoMapper;
using TestProducts2.Profiles;

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

        public ICollection<TDestinationMember> Resolve(object source, object destination, ICollection<TDestinationMember> descriptions, ResolutionContext? context)
        {
            var filteredDescriptions = (HashSet<TSourceMember>)source.GetType().GetProperty("Descriptions").GetValue(source, null);   

            if(context.Items.TryGetValue("lang", out object lang))
            {
                filteredDescriptions = filteredDescriptions.Where(q => (LanguageClass)q.GetType().GetProperty("Language").GetValue(q, null) == (LanguageClass)context.Items["lang"]).ToHashSet();
            }
                filteredDescriptions = filteredDescriptions.OrderBy(q => (LanguageClass)q.GetType().GetProperty("Language").GetValue(q, null)).ToHashSet();

            return _mapper.Map(filteredDescriptions, descriptions);
        }

    }
}
