using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace image.upload
{
    public class DbContext : IDbContext
    {
       private readonly IMongoDatabase _db;

       public DbContext(IOptions<Settings> options)
       {
          var client =  new MongoClient(options.Value.ConnectionString);
          _db = client.GetDatabase(options.Value.Database);
       }

       public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    }
}