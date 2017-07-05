using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kerry.K35Syn.Application.Atrributes
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public ExceptionPolicyImpl ExceptionPolicy { get; set; }
        public ExceptionHandlingAttribute(string exceptionPolicyName)
        {
            this.ExceptionPolicy = EnterpriseLibraryContainer.Current.GetInstance<ExceptionPolicyImpl>(exceptionPolicyName);

        }
        public override void OnException(ExceptionContext filterContext)
        {
            try
            {
                this.ExceptionPolicy.HandleException(filterContext.Exception);
            }
            catch (Exception ex)
            {
                filterContext.Exception = ex;
                base.OnException(filterContext);

            }
        }

        //private void ConfigureEntLib
    }
}