using AutoMapper;

namespace TestProducts2.Entities
{
    public class DescriptionResolver<TSourceMember, TDestinationMember> : IValueResolver<object, object, ICollection<TDestinationMember>>
        where TDestinationMember : class
        where TSourceMember : class
    {
        private readonly IMapper _mapper;

        public DescriptionResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ICollection<TDestinationMember> Resolve(object source, object destination, ICollection<TDestinationMember> descriptions, ResolutionContext context)
        {
            var filteredDescriptions = (HashSet<TSourceMember>)source.GetType().GetProperty("Descriptions").GetValue(source, null);   

            if(context.Items["lang"] != null)
            {
                filteredDescriptions = filteredDescriptions.Where(q => (LanguageClass)q.GetType().GetProperty("Language").GetValue(q, null) == (LanguageClass)context.Items["lang"]).ToHashSet();
            }

            return _mapper.Map(filteredDescriptions, descriptions);
        }

    }
}
