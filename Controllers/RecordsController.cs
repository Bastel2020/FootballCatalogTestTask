//using Football.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Football.Interfaces;
//using Football.DTOs;

//namespace Football.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RecordsController : Controller
//    {
//        private IFootballersRepository _FootballersRepository;
//        public RecordsController(IFootballersRepository FootballersRepository)
//        {
//            _FootballersRepository = FootballersRepository;
//        }
//        // GET: RecordsController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddFootballer([FromForm] AddFootballerDTO footballerToAdd)
//        {
//            var actionSuccess = await _FootballersRepository.AddFootballer(footballerToAdd);
//            if (actionSuccess)
//                return Ok("Футболист успешно добавлен.");
//            else
//                return BadRequest("Ошибка при добавлении футболиста!");
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetFootballers()
//        {
//            var actionSuccess = await _FootballersRepository.AddFootballer(footballerToAdd);
//            if (actionSuccess)
//                return Ok("Футболист успешно добавлен.");
//            else
//                return BadRequest("Ошибка при добавлении футболиста!");
//        }

//        // GET: RecordsController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: RecordsController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: RecordsController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: RecordsController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: RecordsController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: RecordsController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
