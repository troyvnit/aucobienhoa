namespace TroyLeeMVCEF.Models
{
    using System;

    public class CommentViewModel
    {
        public Guid CommentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}