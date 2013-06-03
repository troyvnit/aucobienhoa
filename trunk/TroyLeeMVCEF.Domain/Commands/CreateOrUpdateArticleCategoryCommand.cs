using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using System;

namespace TroyLeeMVCEF.Domain.Commands
{
    public class CreateOrUpdateArticleCategoryCommand : ICommand
    {
        public CreateOrUpdateArticleCategoryCommand(Guid ArticleCategoryId, string ArticleCategoryName, string Description, string ImageUrl, Guid ForumID)
        {
            this.ArticleCategoryId = ArticleCategoryId;
            this.ArticleCategoryName = ArticleCategoryName;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
            this.ForumID = ForumID;
        }
        public Guid ArticleCategoryId { get; set; }
        public string ArticleCategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid ForumID { get; set; }
    }
}
