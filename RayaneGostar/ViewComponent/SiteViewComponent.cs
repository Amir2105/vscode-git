using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RayaneGostar.Views.Shared.Component.ViewComponent
{
    public class SiteViewComponent
    {
        #region site header
        public class SiteHeaderViewComponent : ViewComponent
        {
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return View("SiteHeader");
            }
        }
        #endregion

        #region site footer
        public class SiteFooterViewComponent : ViewComponent
        {
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return View("SiteFooter");
            }
        }
        #endregion
    }
}