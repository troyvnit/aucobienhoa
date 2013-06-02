namespace TroyLeeMVCEF.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Menu
    {
        public Menu()
        {
            MenuID = Guid.NewGuid();
        }
        [Key]
        public Guid MenuID { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ParentID { get; set; }
    }
}
