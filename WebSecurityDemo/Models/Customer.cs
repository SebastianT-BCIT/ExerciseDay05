// File: Models/Customer.cs
namespace WebSecurityDemo.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Read-only property for display
        public string FullName => $"{FirstName} {LastName}";
    }
}
