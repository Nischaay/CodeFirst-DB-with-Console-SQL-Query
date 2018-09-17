using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
