using API.Common;
using API.Dtos.Profiles;
using AutoMapper;
using Domain.Shared;
using System.Reflection;

namespace API.Dtos.Resolvers
{
    public class DescriptionResolver<TSourceMember, TDestinationMember> : IValueResolver<object, object, ICollection<TDestinationMember>>
        where TDestinationMember : class
        where TSourceMember : class
    {
        private readonly IMapper _mapper;
        private readonly LanguageClass? _language = null;


        public DescriptionResolver()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.Load("API"));
            }).CreateMapper();

            var contextAccessor = new HttpContextAccessor();
            if (contextAccessor != null && contextAccessor.HttpContext != null)
            {
                _language = GetLanguage(contextAccessor.HttpContext.Request.Headers["Accept-Language"]);
            }
        }

        public DescriptionResolver(IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            if (contextAccessor != null && contextAccessor.HttpContext != null)
            {
                _language = GetLanguage(contextAccessor.HttpContext.Request.Headers["Accept-Language"]);
            }
        }

        public ICollection<TDestinationMember> Resolve(object source, object destination, ICollection<TDestinationMember> descriptions, ResolutionContext context)
        {
            var resultDescriptions = (ICollection<TSourceMember>?)Helper.GetDynamicValue(source, "Descriptions");

            //if (context.Options.Items.TryGetValue("lang", out object? lang) && lang != null)
            if (_language != null)
            {
                resultDescriptions = resultDescriptions != null ? (ICollection<TSourceMember>)resultDescriptions.Where(q => (LanguageClass?)Helper.GetDynamicValue(q, "Language") == _language).ToHashSet() : null;
            }
            resultDescriptions = resultDescriptions != null ? (ICollection<TSourceMember>)resultDescriptions.OrderBy(q => (LanguageClass?)Helper.GetDynamicValue(q, "Language")).ToHashSet() : null;

            return _mapper.Map(resultDescriptions, descriptions);
        }
        private LanguageClass? GetLanguage(string language)
        {
            if (language == null)
            {
                return null;
            }
            
            if (language.ToLower().Contains("fr") && language.ToLower().Contains("en"))
            {
                return null;
            }
            if (language.ToLower().Contains("en"))
            {
                return LanguageClass.en;
            }
            if (language.ToLower().Contains("fr"))
            {
                return LanguageClass.fr;
            }
            return null;
        }
    }
}
