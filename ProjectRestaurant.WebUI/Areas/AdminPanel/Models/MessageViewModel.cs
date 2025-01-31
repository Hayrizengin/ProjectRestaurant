using ProjectRestaurant.Entity.DTO.MessageDTO;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Models
{
    public class MessageViewModel
    {
        public List<MessageDTOResponse> Messages { get; set; }
        public List<MessageDTOResponse> InActiveMessages { get; set; }
    }
}
