using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kerry.K35Syn.Application.Models
{
    public class Employee
    {
        protected string EmpID { get; set; }
        protected double Salary { get; set; }



        

        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(ownerclass), new PropertyMetadata(0));

        

        public abstract double CalculateBonus();
    }
    public class Manager:Employee
    {
       
        public override double CalculateBonus()
        {
            return this.Salary*(0.05) ;
        }

    }

    public class NormalEmployee : Employee
    {
        public override double CalculateBonus()
        {
            //throw new NotImplementedException();
            return this.Salary * (0.01);
        }
    }

    
}