using Cards.Models;

namespace Cards.Dto
{
    public class GetAllCardsResponse
    {
        public List<Card>? Cards { get; set; }
        public Exception? Error { get; set; }
    }
}
