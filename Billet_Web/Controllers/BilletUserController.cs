using AutoMapper;
using Billet_Utility;
using Billet_Web.Models;
using Billet_Web.Models.Dto;
using Billet_Web.Models.VM;
using Billet_Web.Services;
using Billet_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Billet_Web.Controllers
{
    public class BilletUserController : Controller
    {
        private readonly IBilletUserService _billetUserService;
        private readonly IBilletService _billetService;
        private readonly IMapper _mapper;
        public BilletUserController(IBilletUserService billetUserService, IMapper mapper, IBilletService billetService)
        {
            _billetUserService = billetUserService;
            _mapper = mapper;
            _billetService = billetService;
        }
        public async Task<IActionResult> IndexBilletUser()
        {
            List<BilletUserDTO> list = new();
            var response = await _billetUserService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BilletUserDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        } 
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBilletUser()
        {
            BilletUserCreateVM billetUserVM = new();
            var response = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                billetUserVM.BilletList = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(response.Result)).Select(i=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value= i.Id.ToString()
                });
            }
            return View(billetUserVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBilletUser(BilletUserCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _billetUserService.CreateAsync<APIResponse>(model.BilletUser, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexBilletUser));
                }else
                {
                    if(response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            var resp = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.BilletList = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(resp.Result)).Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateBilletUser(int billetNo)
        {
            BilletUserUpdateVM billetUserVM = new();
            var response = await _billetUserService.GetAsync<APIResponse>(billetNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                BilletUserDTO model = JsonConvert.DeserializeObject<BilletUserDTO>(Convert.ToString(response.Result));
                billetUserVM.BilletUser = _mapper.Map<BilletUserDTO>(model);
            }
            
            response = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                billetUserVM.BilletList = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(response.Result)).Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(billetUserVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBilletUser(BilletUserUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _billetUserService.UpdateAsync<APIResponse>(model.BilletUser, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexBilletUser));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            var resp = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.BilletList = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(resp.Result)).Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBilletUser(int billetNo)
        {
            BilletUserDeleteVM billetUserVM = new();
            var response = await _billetUserService.GetAsync<APIResponse>(billetNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                BilletUserDTO model = JsonConvert.DeserializeObject<BilletUserDTO>(Convert.ToString(response.Result));
                billetUserVM.BilletUser = _mapper.Map<BilletUserDTO>(model);
            }

            response = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                billetUserVM.BilletList = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(response.Result)).Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(billetUserVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBilletUser(BilletUserDeleteVM model)
        {

            var response = await _billetUserService.DeleteAsync<APIResponse>(model.BilletUser.BilletNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexBilletUser));
            }

            return View(model);
        }


    }
}
