using Postgrest.Attributes;
using Postgrest.Models;

namespace portfolioAPI
{
    [Table("Projects")]
    public class Projects : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime Created_At { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Link")]
        public string Link { get; set; }

        [Column("profileid")]
        public string uuid { get; set; }
    }

   
}
