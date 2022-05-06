using Cards.Dto;

namespace Cards.Dal.Contracts
{
    public interface ICardsDalService
    {
        Task<int> CalculateNumAsync(string n);
        Task<GetAllCardsResponse> GetAllCards();

        Task<GetCardResponse> GetCard(GetCardRequest dto);
        Task<AddCardResponse> AddCard(AddCardRequest dto);
        Task<UpdateCardResponse> UpdateCard(UpdateCardRequest dto);
        Task<DeleteCardResponse> DeleteCard(DeleteCardRequest dto);
    }
}
