using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;


namespace Kerry.K35Syn.Application.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            var haveException = false;  
            ExceptionManager em = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
            try
            {
                em.Process(WrapHandler, "Policy");
                em.Process(NoThrowException, "Policy");
            }
            catch (Exception)
            {
                haveException = true;
                Response.Write("Catch exception");

                throw;
            }
            if (haveException ==false)
            {
                
            }
            return View();
        }
        private static void WrapHandler()
        {
            string[] ht = new string[] { };
            ht[2].ToString();

        }
        private void NoThrowException()
        {
            int i = Int32.Parse("A");
        }

    }
}
