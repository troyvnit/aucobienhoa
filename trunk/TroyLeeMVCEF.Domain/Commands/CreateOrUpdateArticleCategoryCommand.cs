using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using System;

namespace TroyLeeMVCEF.Domain.Commands
{
    public class CreateOrUpdateArticleCategoryCommand : ICommand
    {
        public CreateOrUpdateArticleCategoryCommand(Guid ArticleCategoryId, string ArticleCategoryName, string Description, string ImageUrl, int MenuID)
        {
            this.ArticleCategoryId = ArticleCategoryId;
            this.ArticleCategoryName = ArticleCategoryName;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
            this.MenuID = MenuID;
        }
        public Guid ArticleCategoryId { get; set; }
        public string ArticleCategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int MenuID { get; set; }
    }
}
