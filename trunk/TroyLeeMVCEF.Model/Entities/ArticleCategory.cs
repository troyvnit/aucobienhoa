namespace TroyLeeMVCEF.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArticleCategory
    {
        public ArticleCategory()
        {
            ArticleCategoryID = Guid.NewGuid();
        }
        [Key]
        public Guid ArticleCategoryID { get; set; }
        [Required]
        public string ArticleCategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int MenuID { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
