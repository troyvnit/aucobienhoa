namespace TroyLeeMVCEF.Models
{
    using System;
    using System.Collections.Generic;

    public class ArticleViewModel
    {
        public Guid ArticleID { get; set; }
        public int ActicleNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int OrderID { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsNew { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public int MenuID { get; set; }
        public List<Guid> ArticleCategoryIDs { get; set; }
        public List<CommentViewModel> Comments { get; set; } 
    }
}