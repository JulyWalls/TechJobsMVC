using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        static List<Dictionary<string, string>> jobbies = new List<Dictionary<string, string>>();

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.jobs = jobbies;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm) 
        {
            if (searchType.Equals("all"))
            {
               jobbies =  JobData.FindByValue(searchTerm);
            }
            else
            {
                ViewBag.columns = ListController.columnChoices;
                jobbies = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            return Redirect("/Search");


        }
        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
