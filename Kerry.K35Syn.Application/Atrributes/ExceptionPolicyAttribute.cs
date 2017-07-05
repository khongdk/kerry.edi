using Microsoft.Practices.Unity.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kerry.K35Syn.Application.Atrributes
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]
    public class ExceptionPolicyAttribute:Attribute, Kerry.K35Syn.Application.Atrributes.IExceptionPolicyAttribute
    {
        public string ExceptionPolicyName { get; private set; }
        public ExceptionPolicyAttribute(string exceptionPolicyName)
        {
            Guard.ArgumentNotNullOrEmpty(exceptionPolicyName, "exceptionPolicyName");
            this.ExceptionPolicyName = exceptionPolicyName;

        }
    }

        

}