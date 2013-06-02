using AutoMapper;
namespace TroyLeeMVCEF.Mappers
{
    using TroyLeeMVCEF.Controllers;
    using TroyLeeMVCEF.Domain.Commands;
    using TroyLeeMVCEF.Model.Entities;
    using TroyLeeMVCEF.Models;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<ArticleCategoryViewModel, CreateOrUpdateArticleCategoryCommand>();
            Mapper.CreateMap<ArticleCategoryViewModel, DeleteArticleCategoryCommand>();
            Mapper.CreateMap<ArticleViewModel, CreateOrUpdateArticleCommand>();
            Mapper.CreateMap<DeleteArticle, DeleteArticleCommand>();
            Mapper.CreateMap<Menu, CreateOrUpdateMenuCommand>();
        }
    }
}