using Cards.Models;

namespace Cards.Dto
{
    public class GetCardResponse
    {
        public Card? Card { get; set; } = null;
        public Exception? Error{ get; set; }
    }
}
