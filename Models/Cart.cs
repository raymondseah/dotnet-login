using System.ComponentModel.DataAnnotations;

namespace dotnet_login.Models
{
    public class Cart
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}