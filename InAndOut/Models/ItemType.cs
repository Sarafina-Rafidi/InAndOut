using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
