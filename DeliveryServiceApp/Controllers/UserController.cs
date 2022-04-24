using DeliveryServiceApp.Models;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Controllers
{
    /// <summary>
    ///     Kontroler koji upravlja korisnickim profilom
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
    public class UserController : Controller
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
        ///     Polje koje prihvata referencu na interfejs <seealso cref="IPersonUnitOfWork"/>
        /// </value>
        /// <remarks>
        ///     <para>
        ///         U kontroleru, ovom polju se dodeljuje referenca preko dependecy injection-a, <br />
        ///         sto olaksava kasnije unit testiranje i omogucuje lakse refaktorisanje koda.
        ///     </para>
        ///     <para>
        ///         Interfejs <seealso cref="IPersonUnitOfWork"/> kao atribute ima reference na interfejse repozitorijuma <br />
        ///         domenskih klasa. Implementacija interfejsa IPersonUnitOfWork, kao i interfejsa repozitorijuma <br />
        ///         domenskih klasa ima ulogu manipulacije nad tabelama relacione baze podataka koja je <br />
        ///         povezana sa datim softverskim sistemom.
        ///     </para>
        /// </remarks>
        private readonly IPersonUnitOfWork unitOfWork;


        /// <summary>
        ///     Konstruktor koji vrsi dependency injection
        /// </summary>
        /// <param name="unitOfWork">Interfejs <seealso cref="IUnitOfWork"/></param>
        /// <param name="userManager">Klasa <seealso cref="UserManager{TUser}"/></param>
        public UserController(UserManager<Person> userManager, IPersonUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Get akcija koja vraca View razor stranicu sa podacima <br />
        ///     o ulogovanom korisniku 
        ///     <list type="table">
        ///         <item>
        ///             <term>Ukoliko uzimanje id-ja korisnika iz HttpContext-a nije uspesno <br />
        ///             ili se podaci o korisniku sa identifikovanim id-ijem ne nalaze u bazi
        ///             </term>
        ///             <description>Akcija nas redirektuje na Error View</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko su podaci o korisniku uspesno pronadjeni i selektovani
        ///             </term>
        ///             <description>Akcija nas redirektuje na akciju Detail istog kontrolera</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <remarks>
        /// <para>
        ///     Podatak o Id-ju korisnika koji je potreban kako bi se nasli podaci tog korisnika<br />
        ///     se ne prosledjuje kao argument akcije, vec se preko metode klase <seealso cref="UserManager{TUser}"/> <br />
        ///     dobija iz HttpContext-a.
        /// </para>
        /// <para>
        ///      Akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///      Deliverer-a ili Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnici mogu da proveravaju<br />
        ///      informacije na svom korisnickom nalogu.
        /// </para>
        /// </remarks>
        /// <returns>Razor stranica</returns>
        [Authorize(Roles = "Customer, Deliverer")]
        public async Task<IActionResult> Index()
        {
            UserProfileViewModel model = new UserProfileViewModel();

            int userId = -1;
            int.TryParse(userManager.GetUserId(HttpContext.User), out userId);

            if (userId != -1)
            {
               var user =  await userManager.FindByIdAsync(userId.ToString());
                
                if(user != null)
                {
                    model.Id = user.Id;
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.Username = user.UserName;
                    model.Email = user.Email;
                    model.PhoneNumber = user.PhoneNumber;

                    var role = await userManager.GetRolesAsync(user);
                    if (role.Contains("Customer"))
                    {
                        var customer = unitOfWork.Customer.FindByID(userId);
                        model.Address = customer.Address;
                        model.PostalCode = customer.PostalCode;
                    }
                    else
                    {
                        var deliverer = unitOfWork.Deliverer.FindByID(userId);
                        model.DateOfEmployment = deliverer.DateOfEmployment;
                    }

                    return View("Detail", model);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }

        /// <summary>
        ///     Get akcija koja vraca View razor stranice sa formom popunjenom <br />
        ///     podacima o korisniku i namenjenom izmeni tih podataka.
        /// </summary>
        /// <remarks>
        /// <para>
        ///      Akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///      Deliverer-a ili Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnici mogu da proveravaju<br />
        ///      informacije na svom korisnickom nalogu.
        /// </para>
        /// </remarks>
        /// <param name="model">Model <seealso cref="UserProfileViewModel"/> koji sadrzi podatke o selektovanom korisniku</param>
        /// <returns>Razor stranica</returns>
        [Authorize(Roles = "Customer, Deliverer")]
        [HttpGet]
        public IActionResult Edit(UserProfileViewModel model)
        {
            return View(model);
        }

        /// <summary>
        ///     Post akcija koja cuva podatke o izmenjenom korisnickom profilu
        ///     <list type="table">
        ///         <item>
        ///             <term>Ukoliko uprosledjeni model nije validan
        ///             </term>
        ///             <description>Akcija nas <br /> ostavlja na istoj putanji i dodaje poruke sa greskama u prikazanu
        ///             razor stranicu </description>
        ///         </item>
        ///        <item>
        ///             <term>Ukoliko korisnik sa Id-jem selektovanim iz prosledjenog modela ne postoji u bazi
        ///             </term>
        ///             <description>Akcija nas redirektuje na Error View </description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko su novi podaci o korisniku uspesno sacuvani
        ///             </term>
        ///             <description>Akcija nas redirektuje na akciju Detail istog kontrolera</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="model">Model <seealso cref="UserProfileViewModel"/> koji sadrzi izmenjene podatke o korisniku</param>
        [HttpPost]
        public async  Task<IActionResult> Edited(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            var user = await userManager.FindByIdAsync(model.Id.ToString());

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.Username;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                await userManager.UpdateAsync(user);

                var role = await userManager.GetRolesAsync(user);
                if (role.Contains("Customer"))
                {
                    Customer c = new Customer
                    {
                        Address = model.Address,
                        PostalCode = model.PostalCode
                    };

                    unitOfWork.Customer.Edit(c);
                }
                return View("Detail", model);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
