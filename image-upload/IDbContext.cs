using MongoDB.Driver;

namespace image.upload
{
    public interface IDbContext
    {
        IMongoCollection<User> Users { get; }
    }
}