using Eturnos.Data;
using Eturnos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Eturnos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext context;

        public LoginController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

          
        public IActionResult Login(Login login)
        {
            if(ModelState.IsValid)
            {
                // encriptar pass
                string passwordEncriptado = Encriptar(login.Password);
                
                var loginUser = context.Login.Where(l=>l.Usuario== login.Usuario && l.Password== passwordEncriptado).FirstOrDefault();  

                if(loginUser!=null) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["errorLogin"] = "los datos ingresados son incorrectios";
                    
                    return View("Index");
                }
                
            }
            return View("index");
        }

        private string Encriptar(string pass)
        {
            using(SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
           
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
