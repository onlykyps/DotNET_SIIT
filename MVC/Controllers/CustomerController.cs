using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Xml.Linq;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            XDocument customerNodes = XDocument.Load("Customers.xml");

            CustomerViewModel customersViewModel = new CustomerViewModel();

            IEnumerable<XElement> descendants = customerNodes.Descendants();

            customersViewModel.CustomerList = descendants.Where(nodDorit => nodDorit.Name == "CustomerName")
                                                        .Select(xElem => xElem.Value)
                                                        .ToList();

            return View(customersViewModel);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }
    }
}
