using System.Web;
using System.Web.Mvc;

namespace AtividadePW2_Relacionamento1_N
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
