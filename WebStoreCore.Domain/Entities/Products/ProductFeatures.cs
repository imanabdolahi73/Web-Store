using WebStoreCore.Domain.Entities.Commons;

namespace WebStoreCore.Domain.Entities.Products
{
    public class ProductFeatures : BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
