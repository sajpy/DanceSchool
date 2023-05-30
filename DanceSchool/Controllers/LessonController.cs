//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using DanceSchool.Models;
//using DanceSchool.Repositories.IRepository;

//namespace DanceSchool.Controllers
//{
//    public class LessonController : Controller
//    {
//        private readonly ILessonRepository _lessonRepository;
//        private readonly ITrainerRepository _trainerRepository;
//        private readonly UserManager<IdentityUser> _userManager;

//        public LessonController(ILessonRepository lessonRepository, ITrainerRepository trainerRepository, UserManager<IdentityUser> userManager)
//        {
//            _lessonRepository = lessonRepository;
//            _trainerRepository = trainerRepository;
//            _userManager = userManager;
//        }

//        public async Task<IActionResult> Index(int? trainerId, int? hallId)
//        {
//            IEnumerable<Lesson> lessons;
//            if (trainerId.HasValue)
//            {
//                lessons = await _lessonRepository.GetLessonsByTrainerIdAsync(trainerId.Value);
//            }
//            else if (hallId.HasValue)
//            {
//                lessons = await _lessonRepository.GetLessonsByHallIdAsync(hallId.Value);
//            }
//            else
//            {
//                lessons = await _lessonRepository.GetAllLessonsAsync();
//            }

//            return View(lessons);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            var trainers = _trainerRepository.GetAllTrainersAsync().Result;
//            ViewBag.Trainers = trainers;
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Lesson lesson)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = await _userManager.GetUserAsync(User);
//                //lesson.CreatedBy = user;
//                await _lessonRepository.AddLessonAsync(lesson);
//                return RedirectToAction(nameof(Index));
//            }

//            return View(lesson);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Edit(int id)
//        {
//            var lesson = await _lessonRepository.GetLessonByIdAsync(id);
//            if (lesson == null)
//            {
//                return NotFound();
//            }

//            var trainers = _trainerRepository.GetAllTrainersAsync().Result;
//            ViewBag.Trainers = trainers;
//            return View(lesson);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(int id, Lesson lesson)
//        {
//            if (id != lesson.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    await _lessonRepository.UpdateLessonAsync(lesson);
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!await _lessonRepository.LessonExistsAsync(id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }

//            var trainers = _trainerRepository.GetAllTrainersAsync().Result;
//            ViewBag.Trainers = trainers;
//            return View(lesson);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var lesson = await _lessonRepository.GetLessonByIdAsync(id);
//            if (lesson == null)
//            {
//                return NotFound();
//            }

//            return View(lesson);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Delete(int id, Lesson lesson)
//        {
//            if (id != lesson.Id)
//            {
//                return NotFound();
//            }

//            await _lessonRepository.DeleteLessonAsync(id);
//            return RedirectToAction(nameof(Index));
//        }
//    }

//}
