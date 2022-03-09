namespace Santader.UserControl.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateAlter { get; set; }

        public int IdUserAlter { get; set; }
    }
}
