using System.ComponentModel.DataAnnotations;

namespace TicketHUB.Model
{
    public class TicketPurchase
    {
        [Range(1, int.MaxValue, ErrorMessage = "ConcertId must be a positive integer.")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be at least 2 characters long.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Name cannot contain numbers.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Credit card number must be exactly 12 digits.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Credit card number must be numeric and exactly 12 digits.")]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Expiration date must be in MM/YY format.")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security code is required.")]
        [StringLength(3, ErrorMessage = "Security code must be exactly 3 digits.")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Security code must be numeric.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot be longer than 100 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot be longer than 50 characters.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Postal code must be exactly 6 characters.")]
        public string PostalCode { get; set; } = string.Empty;


        [Required(ErrorMessage = "Country is required.")]
        [StringLength(100, ErrorMessage = "Country cannot be longer than 100 characters.")]
        public string Country { get; set; } = string.Empty;
    }
}
