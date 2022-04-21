using API.Common;
using API.Dtos.Profiles;
using AutoMapper;
using Domain.Shared;

namespace API.Dtos.Resolvers
{
    public class DescriptionResolver<TSourceMember, TDestinationMember> : IValueResolver<object, object, ICollection<TDestinationMember>>
        where TDestinationMember : class
        where TSourceMember : class
    {
        private readonly IMapper _mapper;
        private readonly string _language;


        public DescriptionResolver()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProductsProfile>()).CreateMapper();
            var contextAccessor = new HttpContextAccessor();
            if (contextAccessor != null && contextAccessor.HttpContext != null)
            {
                _language = contextAccessor.HttpContext.Request.Headers["Accept-Language"];
            }
            else
            {
                _language = "en";
            }
        }

        public DescriptionResolver(IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            if (contextAccessor != null && contextAccessor.HttpContext != null)
            {
                _language = contextAccessor.HttpContext.Request.Headers["Accept-Language"];
            }
            else
            {
                _language = "en";
            }
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
