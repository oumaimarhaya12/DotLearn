using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;

namespace DotLearn.Controllers
{
    public class LessonController : Controller
    {

        public static int score = 0;


        public IActionResult Start()
        {
            return View();
        }

        public IActionResult OverviewLesson()
        {
            return View();
        }

        public IActionResult CoreConcepts()
        {
            return View();
        }

        public IActionResult Architecture()
        {
            return View();
        }

        public IActionResult Implementation()
        {
            return View();
        }

        public IActionResult Challenges()
        {
            return View();
        }

        public IActionResult UseCases()
        {
            return View();
        }

        public IActionResult Congratulations()
        {
            return View();
        }
        public IActionResult Test1()
        {
            return View();
        }
        public IActionResult Test2()
        {
            return View();
        }
        public IActionResult Succes()
        {
            return View();
        }
        public IActionResult Failure()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitAnswers(Dictionary<string, string> answers)
        {
            string answer1 = answers.TryGetValue("answer1", out string? value) ? value : null;
            string answer2 = answers.ContainsKey("answer2") ? answers["answer2"] : null;
            string answer3 = answers.ContainsKey("answer3") ? answers["answer3"] : null;

            // Validation des réponses
            if (string.IsNullOrEmpty(answer1) || string.IsNullOrEmpty(answer2) || string.IsNullOrEmpty(answer3))
            {
                ViewBag.Error = "Veuillez répondre à toutes les questions.";
                return View("Test1"); // Recharge la vue Test1 avec un message d'erreur
            }

            if (answer1 == "b")
            {
                score++;
            }
            if (answer2 == "b")
            {
                score++;
            }
            if (answer3 == "b")
            {
                score++;
            }

            ViewBag.Message = "Vos réponses ont été soumises avec succès.";
            return RedirectToAction("Test2"); // Redirige vers la vue de félicitations
        }


        public IActionResult Download()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Certificate.pdf");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Certificate file not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/pdf", "certificate.pdf");
        }


        public IActionResult SubmitAnswers2(Dictionary<string, string> answers)
        {
            string answer1 = answers.TryGetValue("answer1", out string? value) ? value : null;
            string answer2 = answers.ContainsKey("answer2") ? answers["answer2"] : null;
            string answer3 = answers.ContainsKey("answer3") ? answers["answer3"] : null;

            // Validation des réponses
            if (string.IsNullOrEmpty(answer1) || string.IsNullOrEmpty(answer2) || string.IsNullOrEmpty(answer3))
            {
                ViewBag.Error = "Veuillez répondre à toutes les questions.";
                return View("Test1"); // Recharge la vue Test1 avec un message d'erreur
            }

            if (answer1 == "d")
            {
                score++;
            }
            if (answer2 == "a")
            {
                score++;
            }
            if (answer3 == "b")
            {
                score++;
            }

            if (score > 4)
            {
                score = 0;
                return RedirectToAction("Succes");

            }
            else
            {
                score = 0;
                return RedirectToAction("Failure");
            }

        }





    }





}