using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RayaneGostar.ViewComponents
{
    public class SiteViewComponent
    {
        #region site header

        public class SiteHeaderViewComponent : ViewComponent
        {
            public IViewComponentResult InvokeAsync()
            {
                return View("SiteHeader");
            }
        }

        #endregion
        #region site header

        public class SiteFooterViewComponent : ViewComponent
        {
            public IViewComponentResult InvokeAsync()
            {
                return View("SiteFooter");
            }
        }

        #endregion
    }
}