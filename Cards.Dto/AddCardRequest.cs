namespace Cards.Dto
{
    public class AddCardRequest
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }

        public int ExpiryMoth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVC { get; set; }
    }
}
