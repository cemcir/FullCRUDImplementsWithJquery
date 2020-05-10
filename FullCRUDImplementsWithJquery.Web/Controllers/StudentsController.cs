using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullCRUDImplementationWithJquery.Core.ErrorMessage;
using FullCRUDImplementationWithJquery.Core.Redirect;
using FullCRUDImplementationWithJquery.Core.RedirectWithError;
using Microsoft.AspNetCore.Mvc;

namespace FullCRUDImplementationWithJquery.Web.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View(new RedirectWithErrorMessage(new RedirectToPage(),new ErrorMessageCode()));
        }
    }
}