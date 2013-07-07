using AutoMapper;
namespace TroyLeeMVCEF.Mappers
{
    using TroyLeeMVCEF.Model.Entities;
    using TroyLeeMVCEF.Models;

    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<Article, ArticleViewModel>();
            Mapper.CreateMap<ArticleCategory, ArticleCategoryViewModel>();
            Mapper.CreateMap<Comment, CommentViewModel>();
            Mapper.CreateMap<Menu, MenuViewModel>();
        }
    }
}