using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BatchApp.Models
{
    public class BatchModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? BatchID { get; set; }
        [Required]
        public string BusinessUnit { get; set; }
        public IEnumerable<ACL> ACLs { get; set; }
        public IEnumerable<Atribute> Atributes { get; set; }
        public DateTime ExpiryDate { get; set; }

        //public IList<Atribute> Atribute { get; set; } = new List<Atribute>();

        //[Required, DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        //public DateTime batchPublishDate { get; set; }
        //[Required, DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]

    }
}