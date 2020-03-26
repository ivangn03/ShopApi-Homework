using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}