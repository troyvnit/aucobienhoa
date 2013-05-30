namespace TroyLeeMVCEF.Data.Repositories.Article
{
    using TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory;
    using TroyLeeMVCEF.Data.Infrastructure.Repository;
    using TroyLeeMVCEF.Model.Entities;

    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
