using ShopTemplate.Models;

namespace ShopTemplate.Domain.Models.Entities
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; }
        public string Body { get; set; }
        public bool Read { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}