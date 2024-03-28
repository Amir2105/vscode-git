namespace RayaneGostar.Views.Shared.Component.ViewComponent
{
    public class SiteViewComponent
    {
        #region siteHeader
        public class SiteHeaderViewComponent :ViewComponent
        {
            public async Task<IViewComponentResult>InvokeAsync()
            {
               return View("SiteHeader") ;
            }
        }
            
        #endregion
            #region siteFooter
        public class SiteFooterViewComponent :ViewComponent
        {
            public async Task<IViewComponentResult>InvokeAsync()
            {
               return View("SiteFooter") ;
            }
        }
            
        #endregion
    }
}