using System.Web;
using System.Web.Mvc;

namespace Curso_Crud_DevMedia
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
