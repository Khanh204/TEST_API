using System.ComponentModel.DataAnnotations;

namespace TEST_API.Model
{
    public class CreateOrder
    {
        [Required]
        [MaxLength(50)]
        public string ItemCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }

        [Required]
        public int ItemQty { get; set; }

        [Required]
        [MaxLength(200)]

        public string OrderDelivery { get; set; }

        [Required]
        [MaxLength(200)]
        public string OrderAddress { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
