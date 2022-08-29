
//using Assignment_4.Controllers;
using System.Web.Mvc;
using System.Data.SqlClient;



namespace Assignment_4.Exceptionfilterr
{
    public class UserClassExceptionfilter : FilterAttribute , IExceptionFilter
    {
        private readonly log4net.ILog _log4net;
        public UserClassExceptionfilter()
        {
            _log4net = log4net.LogManager.GetLogger(typeof(UserClassExceptionfilter));
        }
        public void OnException(ExceptionContext filterContext)
        {

            //using (var writer = File.CreateText("C:\temp1\app2.txt"))
            //{
                if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
                {
                    //writer.WriteLine(filterContext.Exception.ToString());
                    filterContext.Result = new RedirectResult("AnotherError.cshtml");
                    filterContext.ExceptionHandled = true;
                    _log4net.Error(filterContext.Exception.ToString());
                }
                if(!filterContext.ExceptionHandled && filterContext.Exception is IndexOutOfRangeException)
                {
                    filterContext.Result = new RedirectResult("AnotherError.cshtml");
                    filterContext.ExceptionHandled = true;
                    //writer.WriteLine(filterContext.Exception.ToString());
                    _log4net.Error(filterContext.Exception.ToString());

                }
                if (!filterContext.ExceptionHandled && filterContext.Exception is SqlException)
                {
                    filterContext.Result = new RedirectResult("AnotherError.cshtml");
                    filterContext.ExceptionHandled = true;
                    //writer.WriteLine(filterContext.Exception.ToString());
                    _log4net.Error(filterContext.Exception.ToString());

                }
            //}
        }
    }
}
