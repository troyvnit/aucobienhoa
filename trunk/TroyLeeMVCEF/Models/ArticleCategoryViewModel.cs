namespace TroyLeeMVCEF.Models
{
    using System;

    using Newtonsoft.Json;

    public class ArticleCategoryViewModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid ArticleCategoryID { get; set; }
        public string ArticleCategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}