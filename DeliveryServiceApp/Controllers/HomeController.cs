using DeliveryServiceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApp.Controllers
{
    /// <summary>
    ///     Kontroler koji sadrzi akcije koje manipulisu prikazom pocetne stranice 
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Nasledjuje klasu abstraktnu klasu <see cref="Controller"/> <br />
    ///         koja pruza metode koje odgovaraju na HTTP zahteve koji se <br />
    ///         upucuju na ASP.NET MVC Web sajt.
    ///     </para>
    ///     <para>
    ///         <see href="https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller?view=aspnet-mvc-5.2">
    ///             Vise informacija o Controller klasi
    ///         </see>
    ///     </para>
    /// </remarks>
    public class HomeController : Controller
    {
        /// <summary>
        ///     Post akcija koja vraca View razor stranice <br />
        ///     koji predstavlja pocetnu stranicu
        /// </summary>
        /// <remarks>  
        ///     Kako akcija vraca View pocetne stranice, ima atribut <seealso cref="AllowAnonymousAttribute"/> koji <br/>
        ///     omogucava i posetiocima koji nisu ulogovani da pristupe ovoj putanji.
        /// </remarks>
        /// <returns>Razor stranica</returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Post akcija koja vraca View razor stranice koji predstavlja stranicu<br />
        ///     koja obavestava korisnika da nema pristup putanji kojoj je pokusao da pristupi
        /// </summary>
        /// <remarks>  
        ///     Kako akcija vraca View stranice koja obavestava korisnika da nema pristup, <br />
        ///     ima atribut <seealso cref="AllowAnonymousAttribute"/> koji
        ///     omogucava i posetiocima koji nisu <br /> ulogovani da pristupe ovoj putanji.
        /// </remarks>
        /// <returns>Razor starnica</returns>
        [AllowAnonymous]
        public IActionResult AccesDenied()
        {
            return View();
        }

        /// <summary>
        ///     Post akcija koja vraca View razor stranice koji predstavlja stranicu<br />
        ///     koja obavestava korisnika da je doslo do greske prilikom vrsenja zahteva
        /// </summary>
        /// <param name="message">Poruka koju prosledjuje bacena greska</param>
        /// <returns>Razor stranica</returns>
        [AllowAnonymous]
        public IActionResult Error(string message)
        {
            ErrorViewModel model = new ErrorViewModel { Message = message };
            return View(model);
        }
    }
}
