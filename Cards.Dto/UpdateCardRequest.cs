namespace Cards.Dto
{
    public class UpdateCardRequest
    {
        public Guid CardId { get; set;}
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }

        public int ExpiryMoth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVC { get; set; }
    }
}
