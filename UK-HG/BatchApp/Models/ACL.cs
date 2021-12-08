using System.ComponentModel.DataAnnotations;

namespace BatchApp.Models
{
    public class ACL
    {
        [Key]
        public string ReadUser { get; set; }
        public string ReadGroup { get; set; }

    }
}
