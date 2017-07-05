using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Kerry.K35.Syn.Web.Extensions
{
    public class ExtendHandleErrorAttribute:HandleErrorAttribute
    {
        public ExceptionPolicyImpl ExceptionPolicy { get; private set; }

        public ExtendHandleErrorAttribute(string exceptionPolicyName)
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
    }
}