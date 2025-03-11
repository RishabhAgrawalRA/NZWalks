using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    //api/walks
    [Route("[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        public IWalkRepository walkRepository { get; }
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        //Get All Walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from DB - All walks
            List<Walk> walksDomain = await walkRepository.GetAllAsync();

            //Map walk domain to walk DTO
            return Ok(mapper.Map<List<WalkDTO>>(walksDomain));
        }

        //Get Walk by ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            //Get Walk Domain from DB
            var walkDomain = await walkRepository.GetWalkByIdAsync(id);

            if (walkDomain == null)
                return NotFound();

            //Map Walk Domain to Walk DTO
            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }

        //Create Walk
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDTO addWalkRequestDto)
        {
            //Map Dto to Domain Model
            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateWalkAsync(walkDomain);

            return Ok(mapper.Map<WalkDTO>(walkDomain));

        }

        //Update Walk
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            //Map update walk DTO to Domain
            var walkDomain = mapper.Map<Walk>(updateWalkRequestDTO);

            //Update Walk if exist
            walkDomain = await walkRepository.UpdateWalkAsync(id, walkDomain);

            if (walkDomain == null)
                return NotFound();

            //Map Domian back to DTO
            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }

        //Delete Walk
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.DeleteWalkAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }
    }
}
