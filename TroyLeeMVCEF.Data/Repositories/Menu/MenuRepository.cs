namespace TroyLeeMVCEF.Data.Repositories.Menu
{
    using TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory;
    using TroyLeeMVCEF.Data.Infrastructure.Repository;
    using TroyLeeMVCEF.Model.Entities;

    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
