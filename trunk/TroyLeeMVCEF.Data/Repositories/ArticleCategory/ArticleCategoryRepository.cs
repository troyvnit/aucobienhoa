namespace TroyLeeMVCEF.Data.Repositories.ArticleCategory
{
    using TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory;
    using TroyLeeMVCEF.Data.Infrastructure.Repository;
    using TroyLeeMVCEF.Model.Entities;

    public class ArticleCategoryRepository: RepositoryBase<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
