using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using MongoDB.Bson;

namespace HandIn_3.Models
{
    public class User
    {
        [XmlIgnore]
        public ObjectId _id { get; set; }

        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}