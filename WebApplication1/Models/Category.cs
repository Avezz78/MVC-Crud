using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required] // to make sure name is not a nullable property
        public string name { get; set; }
        [DisplayName("Display order")]
        //Custom Validation
        [Range(1,100,ErrorMessage ="display order must be between 1 and 100 only!")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
