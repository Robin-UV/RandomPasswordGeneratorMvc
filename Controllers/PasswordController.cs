using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasswordGeneratorMvc.Models; 

namespace RandomPasswordGeneratorMvc.Controllers
{
    public class PasswordController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            PasswordViewModel model = new PasswordViewModel(); 
            return View(model);
        }

        // Function to generate new random password

        [HttpPost]
        public IActionResult GenerateNewRandomPassword(int passwordLength, bool includeUpperCase, bool includeSpecialCharacters)
        {
            PasswordViewModel model = new PasswordViewModel();
            Random random = new Random();

            string defaultPassword = "abcdefghijklmnopqrstuvwxyz0123456789";
            string upperCase = "ABCDEFGHIJKLMNOPQRSTUVQXYZ";
            string specialCharacters = "!@#$%^&*()?";
            string generatedPassword = "";
            string result = "";

            if (includeUpperCase && includeSpecialCharacters)
            {
                generatedPassword = defaultPassword + upperCase + specialCharacters; 
            }
            else if (includeUpperCase)
            {
                generatedPassword = defaultPassword + upperCase; 
            }
            else if (includeSpecialCharacters)
            {
                generatedPassword = defaultPassword + specialCharacters; 
            }
            else
            {
                generatedPassword = defaultPassword; 
            }

            for (int i = 0; i < passwordLength; i++)
            {
                int letterNumber = random.Next(0, generatedPassword.Length);
                char letter = generatedPassword[letterNumber];
                result += letter; 
            }

            model.GeneratedPassword = result;

            return View("Index", model); 
        }
    }
}

