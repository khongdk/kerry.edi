using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kerry.K35Syn.Application.Common
{
    public class PageBase:Page
    {
        //public int MyProperty { get; private set; }
        public virtual string ExceptionPolicyName { get; set; }
        public PageBase()
        {
            this.ExceptionPolicyName = "default";
        }

        protected virtual string GetExceptionPolicyName()
        {
            ExceptionPolicyAttribute attribute = this.GetTyp()
        }
    }
}