using System.ComponentModel.DataAnnotations;

namespace Commy.Model
{
  
     public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
