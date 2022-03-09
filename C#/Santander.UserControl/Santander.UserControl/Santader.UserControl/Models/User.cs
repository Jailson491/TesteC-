using System.ComponentModel.DataAnnotations;

namespace Santader.UserControl.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }

        public int DepartmentId { get; set; }

        public DateTime DateCreate { get; set; }
        public DateTime DateAlter { get; set; }

        public int IdUserAlter { get; set; }
        public bool Enable { get; set; }

    }
}
