namespace TroyLeeMVCEF.Data.Repositories.User
{
    using TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory;
    using TroyLeeMVCEF.Data.Infrastructure.Repository;
    using TroyLeeMVCEF.Model.Entities;

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
