using System.ComponentModel.DataAnnotations;

namespace Santader.UserControl.Models
{
    public class UserDelete
    {
        [Key]
        public int id { get; set; }
        public int idUser { get; set; }
        public DateTime ResignationDate { get; set; }
        public string? Process { get; set; }
    }
}
