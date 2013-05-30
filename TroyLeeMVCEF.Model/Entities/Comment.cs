namespace TroyLeeMVCEF.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            CommentID = Guid.NewGuid();
        }
        [Key]
        public Guid CommentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ArticleID { get; set; }
        public virtual Article Article { get; set; }
    }
}
