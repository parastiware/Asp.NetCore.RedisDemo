using Microsoft.AspNetCore.Mvc;
using RedisTest.Helpers;
using RedisTest.Models;

namespace RedisTest.Controllers
{
    public class KycController : Controller
    {

       private CacheData cache; //custom class to store,retreive data from redis


        public KycController()
        {
            //injecting redis cahce custom class
            cache = new CacheData();
        }

        // GET: MultiStep form part 1
        [HttpGet]
        public IActionResult KycPart1()
        {
            KycFormPart1 Part1 = new KycFormPart1();
            Part1=cache.GetData(Part1);
            return View(Part1);
        }

        [HttpPost]
        public IActionResult KycPart1(KycFormPart1 Part1)
        {
            var result = cache.SetData(Part1, TimeSpan.FromMinutes(10)); //saving data for 10 mins 
            if (result)
                return RedirectToAction("KycPart2");
            return View(Part1);
        }

        // GET: MultiStep form part 1
        [HttpGet]
        public IActionResult KycPart2()
        {
            KycFormPart2 part2 = new KycFormPart2();
            part2=cache.GetData(part2);
            return View(part2);
        }

        [HttpPost]
        public IActionResult KycPart2(KycFormPart2 Part2)
        {
            var result = cache.SetData(Part2, TimeSpan.FromMinutes(10)); //saving data for 10 mins 
            if (result)
                return RedirectToAction("ShowAllData");
            return View(Part2);
        }

        //displaying data stored in  redis data base 
        public IActionResult ShowAllData()
        {
            KycForm form = new KycForm();
            form.Part1 = new KycFormPart1();
            form.Part2 = new KycFormPart2();
            form.Part1 = cache.GetData(form.Part1);
            form.Part2 = cache.GetData(form.Part2);

            return View(form);
        }

    }
}
