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

    [Route("api/BilletUserAPI")]
    [ApiController]
    public class BilletUserAPIController:ControllerBase
    {

        protected APIResponse _response;   
        private readonly IBilletUserRepository _dbBilletUser;
        private readonly IBilletRepository _dbBillet;
        private readonly IMapper _mapper;
        public BilletUserAPIController(IBilletUserRepository dbBilletUser, IMapper mapper, IBilletRepository dbBillet)

        {
            _dbBilletUser = dbBilletUser;
            _mapper = mapper;
            this._response = new();
            _dbBillet = dbBillet;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetBilletsUser()
        {
            try
            {
                IEnumerable<BilletUser> billetUserList = await _dbBilletUser.GetAllAsync(includeProperties:"Billet");
                _response.Result = _mapper.Map<List<BilletUserDTO>>(billetUserList);
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
        [HttpGet("{id:int}", Name = "GetBilletUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
         public async Task<ActionResult<APIResponse>> GetBilletUser(int id)
         {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var billetUser = await _dbBilletUser.GetAsync(u => u.BilletNo == id);
                if (billetUser == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<BilletUserDTO>(billetUser);
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
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateBilletUser([FromBody]BilletUserDTO createDTO) 
        {
           
            try
            {
                if (await _dbBilletUser.GetAsync(u => u.BilletNo == createDTO.BilletNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "BilletUser already Exists!");
                    return BadRequest(ModelState);
                }
                if (await _dbBillet.GetAsync(u => u.Id == createDTO.BilletId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Billet ID is Invalid!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                
                BilletUser billetUser = _mapper.Map<BilletUser>(createDTO);
               
                await _dbBilletUser.CreateAsync(billetUser);
                _response.Result = _mapper.Map<BilletUserDTO>(billetUser);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetBillet", new { id = billetUser.BilletNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteBilletUser")]
        public async Task<ActionResult<APIResponse>> DeleteBilletUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var billetUser = await _dbBilletUser.GetAsync(u => u.BilletNo == id);
                if (billetUser == null)
                {
                    return NotFound();
                }
                await _dbBilletUser.RemoveAsync(billetUser);
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
        [HttpPut("{id:int}", Name = "UpdateBilletUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult<APIResponse>> UpdateBilletUser(int id, [FromBody] BilletUserDTO updateUserDTO)
        {
            try
            {
                if (updateUserDTO == null || id != updateUserDTO.BilletNo)
                {
                    return BadRequest();
                }
                BilletUser model = _mapper.Map<BilletUser>(updateUserDTO);

                await _dbBilletUser.UpdateAsync(model);
                _response.Result = _mapper.Map<BilletUserDTO>(model);
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
        
    }
}
