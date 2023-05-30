using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DanceSchool.Data;
using DanceSchool.DTO.Pair;
using DanceSchool.Entities;
using DanceSchool.Models;
using DanceSchool.Services.IService;

namespace DanceSchool.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class PairController : Controller
    {
        private readonly IPairService _pairService;

        public PairController(IPairService pairService)
        {
            _pairService = pairService;
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PairCreateDto pairDto)
        {
            if (!ModelState.IsValid)
            {
                return View(pairDto);
            }

            PairCreateDto pairCreateDto = new()
            {
                User1Name = pairDto.User1Name,
                User2Name = pairDto.User2Name,
            };


            await _pairService.AddPairAsync(pairDto);

            

            return RedirectToAction(nameof(Index));
        }

    }

}
