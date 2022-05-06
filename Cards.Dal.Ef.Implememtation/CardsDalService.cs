using Cards.Dal.Contracts;
using Cards.Dto;
using Cards.Models;
using Microsoft.EntityFrameworkCore;

namespace Cards.Dal.Ef.Implememtation
{
    public class CardsDalService : DbContext, ICardsDalService
    {
        public DbSet<Card> Cards { get; set; }

        private readonly string _connectionString;

        public CardsDalService(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        async public Task<int> CalculateNumAsync(string n)
        {
            int result = await Task.Run(() => { return int.Parse(n) + 1; });

            return result;
        }

        public async Task<GetAllCardsResponse> GetAllCards()
        {
            var result = new GetAllCardsResponse();

            try
            {
                var cards = await Cards.ToListAsync();
                result.Cards = cards;
            }
            catch (Exception e)
            {
                result.Error = e;
            }

            return result;
        }

        public async Task<GetCardResponse> GetCard(GetCardRequest dto)
        {
            var result = new GetCardResponse();

            try
            {
                var card = await Cards.FirstOrDefaultAsync(c => c != null && c.Id == dto.CardId);

                result.Card = card;
            }
            catch (Exception e)
            {
                result.Error = e;
            }

            return result;
        }

        public async Task<AddCardResponse> AddCard(AddCardRequest dto)
        {
            var result = new AddCardResponse();

            try
            {
                var card = new Card
                {
                    Id = Guid.NewGuid(),
                    CardHolderName = dto.CardHolderName,
                    CardNumber = dto.CardNumber,
                    ExpiryMoth = dto.ExpiryMoth,
                    ExpiryYear = dto.ExpiryYear,
                    CVC = dto.CVC,
                };

                await Cards.AddAsync(card);
                var savedCardCount = await SaveChangesAsync();

                if (savedCardCount != 0)
                {
                    result.AddedCardId = card.Id;
                }
            }
            catch (Exception e)
            {
                result.Error = e;
            }

            return result;
        }

        public async Task<UpdateCardResponse> UpdateCard(UpdateCardRequest dto)
        {
            var result = new UpdateCardResponse();

            try
            {
                var existingCard = (await GetCard(new GetCardRequest { CardId = dto.CardId })).Card;
                if (existingCard != null)
                {
                    existingCard.CardHolderName = dto.CardHolderName;
                    existingCard.CardNumber = dto.CardNumber;
                    existingCard.ExpiryYear = dto.ExpiryYear;
                    existingCard.ExpiryMoth = dto.ExpiryMoth;
                    existingCard.CVC = dto.CVC;

                    await SaveChangesAsync();

                    result.UpdatedCard = existingCard;
                }
            }
            catch (Exception e)
            {
                result.Error = e;
            }

            return result;
        }

        public async Task<DeleteCardResponse> DeleteCard(DeleteCardRequest dto)
        {
            var result = new DeleteCardResponse();

            try
            {
                var existingCard = (await GetCard(new GetCardRequest { CardId = dto.CardId })).Card;
                if (existingCard != null)
                {

                    Remove(existingCard);
                    await SaveChangesAsync();

                    result.CardDeleted = true;
                    result.DeletedCard = existingCard;
                }
                else
                {
                    result.CardDeleted = false;
                }
            }
            catch (Exception e)
            {
                result.CardDeleted = false;
                result.Error = e;
            }

            return result;
        }
    }
}
