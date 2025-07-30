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

      [HttpGet]
      public IActionResult AddCustomer()
      {
         return View();
      }

      [HttpPost]
      public IActionResult AddCustomer(AddCustomerViewModel newCust)
      {
         XElement newCustName = new XElement("CustomerName",
                                                newCust.Name);
         XElement newCustLoc = new XElement("Location",
                                                newCust.Location);
         XElement newCustProj = new XElement("Project",
                                                newCust.Project);

         XElement newCustomer = new XElement("Customer",
            newCustName, newCustLoc, newCustProj);

         XDocument docu = XDocument.Load("Customers.xml");
         docu.Root.Add(newCustomer);
         docu.Save("Customers.xml");

         return RedirectToAction("Index","Customer");
      }
   }
}
