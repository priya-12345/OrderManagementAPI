using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "First name must be maximum 20 characters if entered")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Last name must be alphanumeric")]
        public string ? FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 20 characters")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Last name must be alphanumeric")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Description must be between 1 and 100 characters")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Last name must be alphanumeric")]
        public string  Description { get; set; }

     
        [Range(1, 20, ErrorMessage = "Quantity must be between 1 and 20")]
        public int Quantity { get; set; }
    }
}
