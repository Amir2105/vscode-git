using Microsoft.AspNetCore.Mvc;

namespace RayaneGostar.ViewComponents
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
        #region site header

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