using Postgrest.Attributes;
using Postgrest.Models;

namespace portfolioAPI
{
    public class Profile : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }
        [Column("created_at")]
        public DateTime Created_At { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
    }
}
