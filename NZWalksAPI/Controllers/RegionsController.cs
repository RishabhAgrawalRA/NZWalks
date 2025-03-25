using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;
using System.Text.Json;

namespace NZWalksAPI.Controllers
{
    //https://localhost:3030/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper,ILogger<RegionsController> logger)
        {
            //this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //Get All Regions
        [HttpGet]
        //[Authorize(Roles ="Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            //logging info
            logger.LogInformation("Get All method from Regional started");
            //Get data from DB - Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();
            /*
            //Map Domain Models to DTOs
            var regionDTO = new List<RegionDTO>();

            foreach (var region in regionsDomain)
            {
                regionDTO.Add(new RegionDTO()
                {
                    ID = region.ID,
                    Code = region.Code,
                    Name = region.Name,
                    RegionaImageUrl = region.RegionaImageUrl
                });
            }
            */

            logger.LogInformation($"Get All method from Regional finished with data: {JsonSerializer.Serialize(regionsDomain)}");
            //throw new Exception("Oops");
            //Return DTOs
            return Ok(mapper.Map<List<RegionDTO>>(regionsDomain));
        }

        //Get Region by Id
        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            //Get Data from DB - Domain Model
            //var region = dbContext.Regions.Find(id);
            var regionDomain = await regionRepository.GetRegionByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }
            /*
            //Map Domain Model to DTO
            var regionDTO = new RegionDTO
            {
                ID = regionDomain.ID,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionaImageUrl = regionDomain.RegionaImageUrl
            };
            */
            //Return DTO
            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        //Create Region
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
    {
            //Map DTO to Domain Model
            var regionDomain = mapper.Map<Region>(addRegionRequestDTO);
            /*
            var regionDomain = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionaImageUrl = addRegionRequestDTO.RegionaImageUrl
            };
            */
            //Create Region use DBContext
            regionDomain = await regionRepository.CreateRegionAsync(regionDomain);
            /*
            //Map Domain Model back to DTO
            var regionDTO = new RegionDTO
            {
                ID = regionDomain.ID,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionaImageUrl = regionDomain.RegionaImageUrl
            };
            */
            var regionDTO = mapper.Map<RegionDTO>(regionDomain);
            //Return DTO
            return CreatedAtAction(nameof(GetRegionById), new { ID = regionDTO.ID }, regionDTO);
        }

        //Update Region
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //Map DTO to Domain Model
            var regionDomain = mapper.Map<Region>(updateRegionRequestDTO);
            /*
            var regionDomain = new Region
            {
                Code = updateRegionRequestDTO.Code,
                Name = updateRegionRequestDTO.Name,
                RegionaImageUrl = updateRegionRequestDTO.RegionaImageUrl
            };
            */
            regionDomain = await regionRepository.UpdateRegionAsync(id, regionDomain);

            if (regionDomain == null)
            {
                return NotFound();
            }
            /*
            //Map Domain Model back to DTO
            var regionDTO = new RegionDTO
            {
                ID = regionDomain.ID,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionaImageUrl = regionDomain.RegionaImageUrl
            };
            */
            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        //Delete Region
        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            //Check Region exists
            var regionDomain = await regionRepository.DeleteRegionAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Return Deleted Region back
            //Map Domain Model back to DTO
            /*var regionDTO = new RegionDTO
            {
                ID = regionDomain.ID,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionaImageUrl = regionDomain.RegionaImageUrl
            };*/

            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }
    }
}
