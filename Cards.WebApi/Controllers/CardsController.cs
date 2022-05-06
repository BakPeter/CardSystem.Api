using Cards.Dal.Contracts;
using Cards.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Cards.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private readonly ICardsDalService _cardsDalService;

        public CardsController(
            ICardsDalService cardsService)
        {
            _cardsDalService = cardsService;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllCardsResponse>> GetAllCards()
        {
            var result = await _cardsDalService.GetAllCards();

            if (result.Error == null)
                return Ok(result);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<ActionResult<GetCardResponse>> GetCard([FromRoute] Guid id)
        {
            var result = await _cardsDalService.GetCard(new GetCardRequest { CardId = id });

            if(result.Error == null)
            {
                if (result.Card != null)
                    return Ok(result);
                else
                    return NotFound(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AddCardResponse>> AddCard(AddCardRequest dto)
        {
            var result = await _cardsDalService.AddCard(dto);

            if (result.Error == null)
            {
                if (result.AddedCardId != null)
                    //return StatusCode(StatusCodes.Status201Created, result);
                    return CreatedAtAction(nameof(GetCard), new { id= result.AddedCardId }, dto);
                else
                    return NotFound(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<UpdateCardResponse>> UpdateCard(
            [FromRoute] Guid id,
            [FromBody]UpdateCardRequest dto)
        {
            dto.CardId = id;
            var result = await _cardsDalService.UpdateCard(dto);

            if (result.Error == null)
            {
                if(result.UpdatedCard != null)
                    return Ok(result);
                else
                    return NotFound(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<DeleteCardResponse>> UpdateCard([FromRoute] Guid id)
        {
            var result = await _cardsDalService.DeleteCard(new DeleteCardRequest { CardId = id });

            if (result.Error == null)
            {
                if (result.CardDeleted)
                    return Ok(result);
                else
                    return NotFound(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }
    }
}
