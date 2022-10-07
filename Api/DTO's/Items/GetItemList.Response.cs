using System;

namespace API.DTOs.Items
{
    public class GetItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ErrorMessage { get; set; }

    }
}