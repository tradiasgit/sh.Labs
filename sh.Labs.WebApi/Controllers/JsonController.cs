using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace sh.Labs.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;

        public JsonController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            var doc = FindOne(id);
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(BsonTypeMapper.MapToDotNetValue(doc));
            return result;
        }

        private static IMongoDatabase GetDatabase()
        {
            var client = new MongoClient("mongodb+srv://hh:skingsking@s-tzqg1.mongodb.net/test?retryWrites=true&w=majority");
            var db = client.GetDatabase("dev");
            return db;
        }
        private static BsonDocument FindOne(string oid, string collectionName = "Nodes")
        {
            if (!_cache.ContainsKey(oid))
            {
                var db = GetDatabase();
                var coll = db.GetCollection<BsonDocument>(collectionName);
                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(oid));
                var one = coll.Find(filter).FirstOrDefault();
                _cache.Add(oid, one);
            }
            var result = _cache[oid];
            _cache.Remove(oid);
            return result;
        }

        private static Dictionary<string, BsonDocument> _cache = new Dictionary<string, BsonDocument>();
    }
}
