using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Kerry.K35Syn.Unit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogEntry logEntry = new LogEntry();
            logEntry.EventId = 1;
            logEntry.Priority = 1;
            logEntry.Title = "Entlib Log block testing";
            logEntry.Message = "http://www.baidu.com";
            logEntry.Categories.Add("C#学习");
            logEntry.Categories.Add("Manners Learning");


            ExceptionManager em = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            try
            {
                em.Process(NotifyRethrow, "General Policy");
            }
            catch (ArgumentOutOfRangeException)
            {

                Console.WriteLine("捕获到ArgumentOutOfRangeException异常,并写入日志!");
            }

            Logger.Writer.Write(logEntry, "Flat");
            Console.WriteLine("日志写入完成!");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void NotifyRethrow()
        {
            List<string> list = new List<string>();
            string str = list[1];
            Console.WriteLine("发生异常,不执行该指令");
        }
    }
}
