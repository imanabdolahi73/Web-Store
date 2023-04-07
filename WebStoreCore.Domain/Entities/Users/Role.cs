using WebStoreCore.Domain.Entities.Commons;

namespace WebStoreCore.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }

    }
}
