using DeliveryServiceApp.Models;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Controllers
{
    /// <summary>
    ///     Kontroler koji upravlja autentifikacijom korisnika
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
    public class AuthenticationController : Controller
    {
        /// <value>
        ///     Polje koje prihvata referencu na instancu objekta UserManager klase
        /// </value>
        /// <remarks>
        ///     <para>
        ///         U kontroleru, ovom polju se dodeljuje referenca preko dependecy injection-a, <br />
        ///         sto olaksava kasnije unit testiranje i omogucuje lakse refaktorisanje koda.
        ///     </para>
        ///     <para>
        ///         UserManager klasa prihvata parametar tipa TUser, u kontekstu <br />
        ///         datog softverskog sistema, to je klasa <see cref="Person"/>.
        ///     </para>
        ///     <para>
        ///         UserMananger klasa omogucava koriscenje build-in metoda za manipulaciju <br />
        ///         nad klasom koja je referencirana kao parametar tipa. <br />
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.usermanager-1?view=aspnetcore-6.0">
        ///             Vise informacija o klasi UserManager
        ///         </see>
        ///     </para>
        /// </remarks>
        private readonly UserManager<Person> userManager;

        /// <value>
        ///     Polje koje prihvata referencu na instancu objekta SignInManager klase
        /// </value>
        /// <remarks>
        ///     <para>
        ///         U kontroleru, ovom polju se dodeljuje referenca preko dependecy injection-a, <br />
        ///         sto olaksava kasnije unit testiranje i omogucuje lakse refaktorisanje koda.
        ///     </para>
        ///     <para>
        ///         SignInManager klasa prihvata parametar tipa TUser, u kontekstu <br />
        ///         datog softverskog sistema, to je klasa <see cref="Person"/>.
        ///     </para>
        ///     <para>
        ///         Klasa SignInManager omogucava koriscenje build-in metoda za <br />
        ///         autentifikaciju, autoriziciju i manipulaciju korisnicikim profilom <br />
        ///         i podacima one klase koja je referencirana kao parametar tipa. <br />
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.signinmanager-1?view=aspnetcore-6.0">
        ///             Vise informacija o klasi SignInManager
        ///         </see>
        ///     </para>
        /// </remarks>>
        private readonly SignInManager<Person> signInManager;

        /// <summary>
        ///     Konstruktor koji vrsi dependency injection klasa <seealso cref="UserManager{TUser}"/> i <seealso cref="SignInManager{TUser}"/> <br />
        ///     u klasu <see cref="AuthenticationController"/>
        /// </summary>
        /// <param name="userManager">Instanca klase UserManager sa parametrom tipa klase Person</param>
        /// <param name="signInManager">Instanca klase SignInManager sa parametrom tipa klase Person</param>
        public AuthenticationController(UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region registration

        /// <summary>
        ///     Get akcija koja vraca View razor stranice <br />
        ///     sa formom za registraciju korisnika.
        /// </summary>
        /// <returns>Razor stranica</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        ///     Post akcija koja se poziva prilikom registracije korisnika.
        ///     <list type="table">
        ///         <item>
        ///             <term>Ukoliko nakon mapiranja iz <seealso cref="RegisterViewModel"/> u <seealso cref="Customer"/> <br />
        ///             klasu, build-in metoda klase <seealso cref="UserManager{TUser}"/> uspesno sacuvala novog <br />
        ///             korisnika
        ///             </term>
        ///             <description>Akcija nas redirektuje na putanju Index akcije Home kontrolera</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko korisnik sa istim korisnickim imenom vec postoji ili sifra nije odgovarajuca
        ///             </term>
        ///             <description>Akcija nas <br /> ostavlja na istoj putanju i dodaje poruke sa greskama u prikazanu
        ///             razor stranicu</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <remarks>
        ///     Ova metoda kao ulazni parametar prima model <seealso cref="RegisterViewModel"/> koji <br />
        ///     predstavlja pomocnu strukturu kako bi selektovali samo one podatke koji su nam neophodni <br />
        ///     za registraciju korisnika, umesto da direktno korisnimo <seealso cref="Customer"/> klasu.
        /// </remarks>
        /// <param name="model">Pomocni model <seealso cref="RegisterViewModel"/></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterViewModel model)
        {
            Customer customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                PostalCode = model.PostalCode
            };

            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.PasswordConfirm) || !model.Password.Equals(model.PasswordConfirm))
            {
                ModelState.AddModelError("Password", "Password not added");
                return View();
            }

            var result = await userManager.CreateAsync(customer, model.Password);

            if (result.Succeeded)
            {
                var currentUser = await userManager.FindByNameAsync(customer.UserName);

                var roleresult = await userManager.AddToRoleAsync(currentUser, "Customer");

                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                if (result.Errors.Any(e => e.Code.Contains("DuplicateUserName")))
                {
                    ModelState.AddModelError("Username", result.Errors.FirstOrDefault(e => e.Code == "DuplicateUserName")?.Description);
                }
                if (result.Errors.Any(e => e.Code.Contains("Password")))
                {
                    ModelState.AddModelError("Password", result.Errors.FirstOrDefault(e => e.Code.Contains("Password"))?.Description);
                }
                return View();
            }
        }
        #endregion

        /// <summary>
        ///     Get akcija koja vraca View razor stranice sa formom za logovanje korisnika
        /// </summary>
        /// <returns>Razor stranica</returns>
        #region login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        ///     Post akcija koja se poziva prilikom logovanja korisnika
        ///      <list type="table">
        ///         <item>
        ///             <term>Ukoliko build-in metoda klase <seealso cref="SignInManager{TUser}}"/> uspesno <br />
        ///             izvrsi logovanje korinsika
        ///             </term>
        ///             <description>Akcija nas redirektuje na putanju Index akcije Home kontrolera</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko logovanje nije proslo uspesno
        ///             </term>
        ///             <description>Akcija nas <br /> ostavlja na istoj putanju i dodaje poruke sa greskama u prikazanu
        ///             razor stranicu</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     Ova metoda kao ulazni parametar prima model <seealso cref="LoginViewModel"/> koji <br />
        ///     predstavlja pomocnu strukturu kako bi selektovali samo one podatke koji su nam neophodni <br />
        ///     za logovanje korisnika, umesto da direktno korisnimo <seealso cref="Customer"/> klasu.
        ///     </para>
        /// </remarks>
        /// <param name="model">Pomocni model <seealso cref="LoginViewModel"/></param>
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);


            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                var roles = await userManager.GetRolesAsync(user);

                if (roles.Contains("Deliverer"))
                {
                    HttpContext.Session.SetString("userrole", "Deliverer");
                }

                if (roles.Contains("Customer"))
                {
                    HttpContext.Session.SetString("userrole", "Customer");
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Wrong credentials!");
            return View();
        }
        #endregion

        /// <summary>
        ///     Post akcija koja sluzi za odjavljivanje korisnika
        /// </summary>
        /// <returns>Redirektuje na putanju Index akcije Home kontrolera</returns>
        #region logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
