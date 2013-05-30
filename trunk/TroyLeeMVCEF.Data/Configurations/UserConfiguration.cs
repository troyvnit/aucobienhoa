namespace TroyLeeMVCEF.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TroyLeeMVCEF.Model.Entities;

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(c => c.UserName).IsRequired();
        }
    }
}
