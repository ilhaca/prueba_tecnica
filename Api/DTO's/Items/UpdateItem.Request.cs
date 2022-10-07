using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Items
{
    public class UpdateItemRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [StringLength(500)]
        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}