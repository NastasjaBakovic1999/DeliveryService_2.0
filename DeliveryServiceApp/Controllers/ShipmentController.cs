using DeliveryServiceApp.Models;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceData.UnitOfWork.Implementation;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DeliveryServiceApp.Controllers
{
    /// <summary>
    ///     Kontroler koji sadrzi akcije koje sluze za manipulaciju posiljkama
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
    public class ShipmentController : Controller
    {
        /// <value>
        ///     Polje koje prihvata referencu na intancu klase koja implementira interfejs <seealso cref="IServiceAdditonalService"/>
        /// </value>
        private readonly IServiceAdditonalService serviceAdditonalService;
        /// <value>
        ///     Polje koje prihvata referencu na intancu klase koja implementira interfejs <seealso cref="IServiceShipmentWeight"/>
        /// </value>
        private readonly IServiceShipmentWeight serviceShipmentWeight;
        /// <value>
        ///     Polje koje prihvata referencu na intancu klase koja implementira interfejs <seealso cref="IServiceShipment"/>
        /// </value>
        private readonly IServiceShipment serviceShipment;
        /// <value>
        ///     Polje koje prihvata referencu na intancu klase koja implementira interfejs <seealso cref="IServiceAddionalServiceShipment"/>
        /// </value>
        private readonly IServiceAddionalServiceShipment serviceAddionalServiceShipment;
        /// <value>
        ///     Polje koje prihvata referencu na intancu klase koja implementira interfejs <seealso cref="IServiceStatus"/>
        /// </value>
        private readonly IServiceStatus serviceStatus;
        /// <value>
        ///     Polje koje prihvata referencu na intancu klase koja implementira interfejs <seealso cref="IServiceStatusShipment"/>
        /// </value>
        private readonly IServiceStatusShipment serviceStatusShipment;

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

        /// <summary>
        ///     Konstruktor koji vrsi dependency injection
        /// </summary>
        /// <param name="userManager">Klasa <seealso cref="SignInManager{TUser}"/></param>
        /// <param name="serviceAdditonalService">Interefjs <seealso cref="IServiceAdditonalService"/></param>
        /// <param name="serviceShipmentWeight">Interfejs <seealso cref="IServiceShipmentWeight"/></param>
        /// <param name="serviceShipment">Interfejs <seealso cref="IServiceShipment"/></param>
        /// <param name="serviceAddionalServiceShipment">Inetrefejs <seealso cref="IServiceAddionalServiceShipment"/></param>
        /// <param name="serviceStatus">Interfejs <seealso cref="IServiceStatus"/></param>
        /// <param name="serviceStatusShipment"><Interfejs <seealso cref="IServiceStatusShipment"/></param>
        public ShipmentController(UserManager<Person> userManager, IServiceAdditonalService serviceAdditonalService, IServiceShipmentWeight serviceShipmentWeight,
                                   IServiceShipment serviceShipment, IServiceAddionalServiceShipment serviceAddionalServiceShipment, IServiceStatus serviceStatus,
                                   IServiceStatusShipment serviceStatusShipment)
        {
            this.userManager = userManager;
            this.serviceAdditonalService = serviceAdditonalService;
            this.serviceShipmentWeight = serviceShipmentWeight;
            this.serviceShipment = serviceShipment;
            this.serviceAddionalServiceShipment = serviceAddionalServiceShipment;
            this.serviceStatus = serviceStatus;
            this.serviceStatusShipment = serviceStatusShipment;
        }

        /// <summary>
        ///     Get akcija koja vraca View razor stranice koja prikazuje formu <br />
        ///     za kreiranje nove posiljke
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Pre nego sto vrati View, ova akcija popunjava liste u modelu <seealso cref="CreateShipmentViewModel"/> <br />
        ///         koje ce se kasnije u razor stranici koristiti za popunjavanje combo box-eva.
        ///     </para>
        ///     <para>
        ///         Takodje, akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///         Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnik koji je kupac moze da zakaze <br />
        ///         dostavu posiljke.
        ///     </para>
        /// </remarks>
        /// <returns>Razor stranica</returns>
        /// <exception cref="Exception">Ukoliko dodje do greske pri ucitavanju podataka za <br />
        /// formu zakreiranje posiljke </exception>
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            try
            {
                List<AdditionalService> additionalServicesList = serviceAdditonalService.GetAll();
                List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

                List<ShipmentWeight> shipmentWeightList = serviceShipmentWeight.GetAll();
                List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();

                CreateShipmentViewModel model = new CreateShipmentViewModel
                {
                    AdditionalServices = selectAdditionalServicesList,
                    ShipmentWeights = selectShipmentWeightList
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        /// <summary>
        ///     Post akcija koja se poziva prilikom cuvanja nove posiljke, <br />
        ///     tj njenog zakazivanja.
        ///     <list type="table">
        ///         <item>
        ///             <term>Ukoliko model prosledjen iz get akcije nije validan
        ///             </term>
        ///             <description>Akcija nas <br /> ostavlja na istoj putanji i dodaje poruke sa greskama u prikazanu
        ///             razor stranicu </description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je nova posiljka uspesno sacuvana
        ///             </term>
        ///             <description>Akcija nas redirektuje na akciju CustomerShipments istog kontrolera</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Kao ulazni parametar ima <seealso cref="CreateShipmentViewModel"/> model <br />
        ///         koji omogucava selekciju podataka koje koristimo prilikom kreiranja posiljke.
        ///     </para>
        ///     <para>
        ///         Takodje, akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///         Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnik koji je kupac moze da zakaze <br />
        ///         dostavu posiljke.
        ///     </para>
        /// </remarks>
        /// <param name="model">Model <seealso cref="CreateShipmentViewModel"/> koji sadrzi unete podatke o posiljci</param>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Create(CreateShipmentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<AdditionalService> additionalServicesList = serviceAdditonalService.GetAll();
                    List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

                    List<ShipmentWeight> shipmentWeightList = serviceShipmentWeight.GetAll();
                    List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();

                    model.AdditionalServices = selectAdditionalServicesList;
                    model.ShipmentWeights = selectShipmentWeightList;

                    return View(model);
                }

                Shipment shipment = new Shipment
                {
                    ShipmentWeightId = model.ShipmentWeightId,
                    ShipmentContent = model.ShipmentContent,
                    ContactPersonName = model.ContactPersonName,
                    ContactPersonPhone = model.ContactPersonPhone,
                    Note = model.Note,
                    ReceivingAddress = model.ReceivingAddress,
                    ReceivingCity = model.ReceivingCity,
                    ReceivingPostalCode = model.ReceivingPostalCode,
                    SendingAddress = model.SendingAddress,
                    SendingCity = model.SendingCity,
                    SendingPostalCode = model.SendingPostalCode,
                    DelivererId = 3
                };

                Random rand = new Random();
                const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
                shipment.ShipmentCode = new string(Enumerable.Repeat(chars, 11)
                                                              .Select(s => s[rand.Next(chars.Length)])
                                                              .ToArray());


                int userId = -1;
                int.TryParse(userManager.GetUserId(HttpContext.User), out userId);

                if (userId != -1)
                {
                    shipment.CustomerId = userId;
                }

                double weightPrice = serviceShipmentWeight.FindByID(model.ShipmentWeightId).ShipmentWeightPrice;
                double additionalServicesPrice = 0;

                if (model.Services != null && model.Services.Count() > 0)
                {
                    List<AdditionalService> additionalServices = serviceAdditonalService.GetAll();

                    foreach (AdditonalServiceViewModel sa in model.Services)
                    {
                        additionalServicesPrice += additionalServices.Find(s => s.AdditionalServiceId == sa.AdditionalServiceId).AdditionalServicePrice;
                    }
                }

                shipment.Price = weightPrice + additionalServicesPrice;

                serviceShipment.Add(shipment);

                foreach (AdditonalServiceViewModel sa in model.Services)
                {
                    AdditionalServiceShipment ass = new AdditionalServiceShipment();
                    ass.AdditionalServiceId = sa.AdditionalServiceId;
                    ass.ShipmentId = shipment.ShipmentId;
                    serviceAddionalServiceShipment.Add(ass);
                }

                StatusShipment ss = new StatusShipment
                {
                    ShipmentId = shipment.ShipmentId,
                    StatusId = serviceStatus.GetByName("Scheduled").StatusId,
                    StatusTime = DateTime.Now
                };

                serviceStatusShipment.Add(ss);

                return RedirectToAction("CustomerShipments");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        /// <summary>
        ///     Post akcija koja popunjava parcijalni view podacima o <br />
        ///     dodatnoj usluzi.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     Kao ulazne parametre prima Id objekta klase AdditionalService cije podatke <br />
        ///     zelimo da dodamo u parcijalni view koji akcija vraca i broj reda koji ce podaci <br />
        ///     o dodatnoj usluzi zauzimati u html tabeli parcijalnog view-a razor stranice.
        /// </para>
        /// <para>
        ///         Takodje, akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///         Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnik koji je kupac moze da dodaje <br />
        ///         dodatne usluge uz svoju posiljku.
        ///     </para>
        /// </remarks>
        /// <param name="additionalServiceId">Id objekta klase AdditionalService</param>
        /// <param name="number">Redni broj reda u tabeli</param>
        /// <returns>Razor stranica</returns>
        /// <exception cref="Exception"></exception>
        [Authorize(Roles = "Customer")]
        public IActionResult AddService(int additionalServiceId, int number)
        {
            try
            {
                AdditionalService service = serviceAdditonalService.FindByID(additionalServiceId);

                AdditonalServiceViewModel model = new AdditonalServiceViewModel
                {
                    AdditionalServiceId = service.AdditionalServiceId,
                    AddtionalServiceName = service.AdditionalServiceName,
                    AdditonalServicePrice = service.AdditionalServicePrice,
                    Sn = number
                };

                return PartialView(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        /// <summary>
        ///     Get akcija koja vraca view razor stranice koji sadrzi podatke <br />
        ///     o svim posiljkama jednog korisnika.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     Podatak o Id-ju korisnika koji je potreban kako bi se nasle sve posiljke <br />
        ///     tog korisnika se ne prosledjuje kao argument akcije, vec se preko metode klase <seealso cref="UserManager{TUser}"/> <br />
        ///     dobija iz HttpContext-a.
        /// </para>
        /// <para>
        ///      Takodje, akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///      Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnik koji je kupac moze da ima pregled <br />
        ///      svih svojih posiljki.
        ///<para>
        /// </remarks>
        /// <returns>Razor stranica</returns>
        /// <exception cref="Exception"></exception>
        [Authorize(Roles = "Customer")]
        public IActionResult CustomerShipments()
        {
            try
            {
                var userId = int.Parse(userManager.GetUserId(HttpContext.User));

                List<Shipment> model = serviceShipment.GetAllOfSpecifiedUser(userId);

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        /// <summary>
        ///     Get akcija koja vraca view razor starnice koji sadrzi sve posiljke u sistemu
        /// </summary>
        /// <remarks>
        /// <para>
        ///         Akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///         Deliverer-a da pristupi putanji ove akcije, jer samo ulogovani korisnik koji je dostavljac moze da ima pregled <br />
        ///         svih posiljki.
        ///     </para>
        /// </remarks>
        /// <returns>Razor stranica</returns>
        [Authorize(Roles = "Deliverer")]
        public IActionResult AllShipments()
        {
            List<Shipment> model = serviceShipment.GetAll();

            return View(model);
        }

        /// <summary>
        ///     Get akcija koja vraca view razor stranice koja sadrzi formu <br />
        ///     za unos jedinstvenog koda posiljke preko kojeg se pristupa informacijama <br />
        ///     o posiljci
        /// </summary>
        /// <remarks>
        /// <para>
        ///         Akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///         Deliverer-a ili Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnici mogu da proveravaju<br />
        ///         informacije o posiljci.
        ///     </para>
        /// </remarks>
        /// <returns>Razor stranica</returns>
        [Authorize(Roles = "Customer, Deliverer")]
        public IActionResult ShipmentMonitoring()
        {
            ShipmentMonitoringViewModel model = new ShipmentMonitoringViewModel();
            return View(model);
        }

        /// <summary>
        ///     Post akcija koja vraca podatke o posiljci na osnovu jedinstvenog <br />
        ///     koda posilke.
        ///     <list type="table">
        ///         <item>
        ///             <term>Ukoliko posiljka sa prosledjenim jedinstvenim kodom ne postoji
        ///             </term>
        ///             <description>Akcija nas <br /> ostavlja na istoj putanji i dodaje poruke sa greskama u prikazanu
        ///             razor stranicu </description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je nova posiljka uspesno pronadjena
        ///             </term>
        ///             <description>Akcija nas redirektuje na akciju ShipmentStatuses istog kontrolera</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <remarks>
        /// <para>
        ///     Kao ulazne parametre, akcija prima objekat pomocne klase <seealso cref="ShipmentMonitoringViewModel"/> <br />
        ///     koji iz get metode prosledjuje jedinstveni kod posiljke.
        /// </para>
        /// <para>
        ///         Akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///         Deliverer-a ili Customer-a da pristupi putanji ove akcije, jer samo ulogovani korisnici mogu da proveravaju<br />
        ///         informacije o posiljci.
        ///     </para>
        /// </remarks>
        /// <param name="model">Model <seealso cref="ShipmentMonitoringViewModel"/> koji sadrzi jedinstveni kod posiljke unet od strane korisnika sistema</param>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public IActionResult ShipmentMonitoring(ShipmentMonitoringViewModel model)
        {
            try
            {
                Shipment shipment = serviceShipment.FindByCode(model.ShipmentCode);

                if (shipment == null)
                {
                    ModelState.AddModelError(string.Empty, "The shipment code you entered does not exist. Please check your code and try again.");
                    return View("ShipmentMonitoring");
                }

                List<StatusShipment> statusShipmentList = serviceStatusShipment.GetAllByShipmentId(shipment.ShipmentId);

                List<Status> statusesList = serviceStatus.GetAll();

                foreach (StatusShipment ss in statusShipmentList)
                {
                    StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                    {
                        StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                        StatusTime = ss.StatusTime
                    };
                    model.ShipmentStatuses.Add(ssvm);
                }

                return View("ShipmentStatuses", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        /// <summary>
        ///     Get akcija koja vraca view razor stranice sa podacima o <br />
        ///     posiljci ciji je id prosledjen kao ulazni argument.
        /// </summary>
        /// <remarks>
        /// <para>
        ///         Akcija ima atribut <seealso cref="AuthorizeAttribute"/> koji dozvoljava samo korisniku sa Role-om <br />
        ///         Deliverer-a da pristupi putanji ove akcije, jer samo ulogovani korisnik koji je dostavljac moze da<br />
        ///         menja status posiljke.
        ///     </para>
        /// </remarks>
        /// <param name="id">Id posiljke ciji status zelimo da menjamo</param>
        /// <returns>Razor stranica</returns>
        /// <exception cref="Exception"></exception>
        [Authorize(Roles = "Deliverer")]
        public IActionResult EditStatus(int id)
        {
            try
            {
                Shipment shipment = serviceShipment.FindByID(id);

                List<StatusShipment> statusShipmentList = serviceStatusShipment.GetAllByShipmentId(shipment.ShipmentId);
                List<Status> statusesList = serviceStatus.GetAll();
                List<SelectListItem> statusesSelectList = statusesList.Select(s => new SelectListItem { Text = s.StatusName, Value = s.StatusId.ToString() }).ToList();

                ShipmentMonitoringViewModel model = new ShipmentMonitoringViewModel
                {
                    ShipmentCode = shipment.ShipmentCode,
                    StatusesSelect = statusesSelectList
                };

                foreach (StatusShipment ss in statusShipmentList)
                {
                    StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                    {
                        StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                        StatusTime = ss.StatusTime
                    };
                    model.ShipmentStatuses.Add(ssvm);
                }

                return View(model);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        /// <summary>
        ///    Post akcija koja cuva podatke o dodatom statusu posiljke i redirektuje <br />
        ///    na putanju AllShipments akcije istog kontrolera.
        /// </summary>
        /// <param name="id">Id posiljke ciji se status menja</param>
        /// <param name="model"><seealso cref="ShipmentMonitoringViewModel"/> model koji sadrzi podatke o dodatom statusu</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public IActionResult EditStatus(int id, ShipmentMonitoringViewModel model)
        {
            try
            {
                Shipment shipment = serviceShipment.FindByID(id);
                List<StatusShipment> statusShipmentList = serviceStatusShipment.GetAllByShipmentId(shipment.ShipmentId);

                if (statusShipmentList.Any(ss => ss.StatusId == model.StatusId))
                {
                    ModelState.AddModelError(string.Empty, "You cannot add a status that is already in the shipment status list.");

                    List<Status> statusesList = serviceStatus.GetAll();
                    List<SelectListItem> statusesSelectList = statusesList.Select(s => new SelectListItem { Text = s.StatusName, Value = s.StatusId.ToString() }).ToList();

                    ShipmentMonitoringViewModel m = new ShipmentMonitoringViewModel
                    {
                        ShipmentCode = shipment.ShipmentCode,
                        StatusesSelect = statusesSelectList
                    };

                    foreach (StatusShipment ss in statusShipmentList)
                    {
                        StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                        {
                            StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                            StatusTime = ss.StatusTime
                        };
                        m.ShipmentStatuses.Add(ssvm);
                    }

                    return View(m);
                }

                serviceStatusShipment.Add(new StatusShipment
                {
                    ShipmentId = id,
                    StatusId = model.StatusId,
                    StatusTime = DateTime.Now
                });


                return RedirectToAction("EditStatus");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }
    }   
}
