using AutoMapper;
using Billet_Utility;
using Billet_Web.Models;
using Billet_Web.Models.Dto;
using Billet_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace Billet_Web.Controllers
{

    public class BilletController : Controller
    {
        private readonly IBilletService _billetService;
        private readonly IMapper _mapper;
        public BilletController(IBilletService billetService, IMapper mapper)
        {
            _billetService = billetService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexBillet()
        {
            List<BilletDTO> list = new();
            var response = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBillet()
        {
            
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBillet(BilletDTO model)
        {
            if(ModelState.IsValid)
            {
                var response = await _billetService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexBillet));
                }
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateBillet(int billetId)
        {
            var response = await _billetService.GetAsync<APIResponse>(billetId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                BilletDTO model = JsonConvert.DeserializeObject<BilletDTO>(Convert.ToString(response.Result)); 
                return View(_mapper.Map<BilletDTO>(model));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBillet(BilletDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _billetService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexBillet));
                }
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBillet(int billetId)
        {
            var response = await _billetService.GetAsync<APIResponse>(billetId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                BilletDTO model = JsonConvert.DeserializeObject<BilletDTO>(Convert.ToString(response.Result));
                return View((model));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBillet(BilletDTO model)
        {
            
                var response = await _billetService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexBillet));
                }
            
            return View(model);
        }
        public async Task<IActionResult> Get20Billet()
        {
            List<BilletDTO> list = new();
            var response = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(response.Result));

                // Перемішуємо список випадковим чином
                var random = new Random();
                list = list.OrderBy(x => random.Next()).ToList();

                // Отримуємо перші 20 елементів (або менше, якщо список має менше 20 елементів)
                list = list.Take(20).ToList();
            }

            return View(list);
        }
        public async Task<IActionResult> GetBilletByYear(string year)
        {
            List<BilletDTO> list = new();
            var response = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(response.Result));

                // Фільтруємо тести за роком
                if (!string.IsNullOrEmpty(year) && int.TryParse(year, out int filterYear))
                {
                    // Перевіряємо, чи Description не є null перед фільтрацією
                    list = list.Where(billet => billet.Description != null && billet.Description.Contains(filterYear.ToString())).ToList();
                }
            }

            return View(list);
        }




    }
}
