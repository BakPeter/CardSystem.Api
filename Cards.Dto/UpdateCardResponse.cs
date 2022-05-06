using Cards.Models;

namespace Cards.Dto
{
    public class UpdateCardResponse
    {
        public Card? UpdatedCard { get; set; }

        public Exception? Error { get; set; }
    }
}
