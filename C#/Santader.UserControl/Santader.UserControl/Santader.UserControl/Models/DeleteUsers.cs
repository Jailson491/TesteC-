using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Santader.UserControl.Models
{
    public class DeleteUsers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]       
        public int id { get; set; }
        public int idUser { get; set; }      
        public DateTime ResignationDate { get; set; }        
        public string Process { get; set; }

    }
}
