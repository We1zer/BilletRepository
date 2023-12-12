using AutoMapper;
using BilletAPI.Data;
using BilletAPI.Logging;
using BilletAPI.Models;
using BilletAPI.Models.Dto;
using BilletAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BilletAPI.Controllers
{

    [Route("api/BilletAPI")]
    [ApiController]
    public class BilletAPIController:ControllerBase
    {

        protected APIResponse _response;   
        private readonly IBilletRepository _dbBillet;
        private readonly IMapper _mapper;
        public BilletAPIController(IBilletRepository dbBillet, IMapper mapper)

        {
            _dbBillet = dbBillet;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetBillets()
        {
            try
            {
                IEnumerable<Billet> billetList = await _dbBillet.GetAllAsync();
                _response.Result = _mapper.Map<List<BilletDTO>>(billetList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetBillet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetBillet(int id)
         {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var billet = await _dbBillet.GetAsync(u => u.Id == id);
                if (billet == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<BilletDTO>(billet);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
         }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateBillet([FromBody]BilletDTO createDTO) 
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try
            {
                if (await _dbBillet.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Billet already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                if (createDTO.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Billet billet = _mapper.Map<Billet>(createDTO);
                //Billet model = new()
                //{ 

                //    Name = createDTO.Name,
                //    Answer1 = createDTO.Answer1,
                //    Id = createDTO.Id,
                //    Answer2 = createDTO.Answer2,
                //    Answer3 = createDTO.Answer3,
                //    Answer4 = createDTO.Answer4,
                //    CorrectAnswer = createDTO.CorrectAnswer,
                //    ImageUrl = createDTO.ImageUrl,
                //    Description = createDTO.Description,
                //};
                await _dbBillet.CreateAsync(billet);
                _response.Result = _mapper.Map<BilletDTO>(billet);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetBillet", new { id = billet.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteBillet")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<APIResponse>> DeleteBillet(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var billet = await _dbBillet.GetAsync(u => u.Id == id);
                if (billet == null)
                {
                    return NotFound();
                }
                await _dbBillet.RemoveAsync(billet);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateBillet")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult<APIResponse>> UpdateBillet(int id, [FromBody] BilletDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }
                Billet model = _mapper.Map<Billet>(updateDTO);

                await _dbBillet.UpdateAsync(model);
                _response.Result = _mapper.Map<BilletDTO>(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpPatch("{id:int}", Name = "UpdatePartialBillet")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialBillet(int id, JsonPatchDocument<BilletDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var billet =await _dbBillet.GetAsync(u => u.Id == id, tracked:false);
            BilletDTO billetDTO = _mapper.Map<BilletDTO>(billet);
            
            if (billet == null)
            {
                return BadRequest();

            }
            patchDTO.ApplyTo(billetDTO, ModelState);
            Billet model = _mapper.Map<Billet>(billetDTO);

            await _dbBillet.UpdateAsync(model);           
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
