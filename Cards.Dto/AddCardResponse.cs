namespace Cards.Dto
{
    public class AddCardResponse
    {
        public Guid? AddedCardId { get; set; }
        public Exception? Error { get; set; }
    }
}
