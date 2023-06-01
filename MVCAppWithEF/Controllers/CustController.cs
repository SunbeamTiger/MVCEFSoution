using DBProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAppWithEF.ViewModels;


namespace MVCAppWithEF.Controllers
{
    public class CustController : Controller
    {
        private ICustomerRepository _Repo;   
        public CustController(ICustomerRepository customerRepository)
        {
            _Repo = customerRepository;
        }
        public ActionResult Index()
        {
           List<Customer> customers = _Repo.GetAllCustomers().ToList();  
           return View(customers); 
        }

        // GET: CustController/Details/5
        public ActionResult Details(int id)
        {
           Customer c = _Repo.GetCustomerById(id);  
           return View(c);
        }

        // GET: CustController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditCustomerViewModel ec = new EditCustomerViewModel();
            Customer c = _Repo.GetCustomerById(id);
            ec.LastName = c.LastName; 
            ec.FirstName = c.FirstName; 
            ec.Country= c.Country;
            ec.City = c.City;
            ec.Phone = c.Phone; 
            return View(ec);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, EditCustomerViewModel c)
        {
            //if (ModelState.IsValid)
            //{ }
            Customer cust = _Repo.GetCustomerById(Id);
            cust.FirstName = c.FirstName;
            cust.LastName = c.LastName;
            cust.City = c.City;
            cust.Phone = c.Phone;
            cust.Country = c.Country;
            cust = _Repo.Update(cust);

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
