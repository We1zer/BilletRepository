using AutoMapper;
using Billet_Utility;
using Billet_Web.Models;
using Billet_Web.Models.Dto;
using Billet_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Billet_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBilletService _billetService;
        private readonly IMapper _mapper;
        public HomeController(IBilletService billetService, IMapper mapper)
        {
            _billetService = billetService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<BilletDTO> list = new();
            var response = await _billetService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BilletDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

     

       
    }
}