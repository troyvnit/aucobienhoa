using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using System;
using System.Collections.Generic;

namespace TroyLeeMVCEF.Domain.Commands
{
    public class CreateOrUpdateArticleCommand : ICommand
    {
        public CreateOrUpdateArticleCommand(Guid ArticleID, string Title, string Description, string Author,
            string Content, string ImageUrl, bool IsPublished, bool IsNew, List<Guid> ArticleCategoryIDs,
            int OrderID, int MenuID)
        {
            this.ArticleID = ArticleID;
            this.Content = Content;
            this.Description = Description;
            this.Author = Author;
            this.ImageUrl = ImageUrl;
            this.IsNew = IsNew;
            this.IsPublished = IsPublished;
            this.Title = Title;
            this.ArticleCategoryIDs = ArticleCategoryIDs;
            this.OrderID = OrderID;
            this.MenuID = MenuID;
        }
        public Guid ArticleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int OrderID { get; set; }
        public int MenuID { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public List<Guid> ArticleCategoryIDs { get; set; }
    }
}
