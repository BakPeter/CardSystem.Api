using Cards.Models;

namespace Cards.Dto
{
    public class DeleteCardResponse
    {
        public bool CardDeleted { get; set; }
        public Card? DeletedCard { get; set; }
        public Exception? Error { get; set; }
    }
}
