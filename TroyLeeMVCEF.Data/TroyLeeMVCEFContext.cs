namespace TroyLeeMVCEF.Data
{
    using System.Data.Entity;

    using TroyLeeMVCEF.Data.Configurations;
    using TroyLeeMVCEF.Model.Entities;

    public class TroyLeeMVCEFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

    }
}
