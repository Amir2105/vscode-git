namespace RayaneGostar.Views.Shared.Component.ViewComponent
{
    public class SiteViewComponent
    {
        #region siteHeader
        public class SiteHederViewComponent :ViewComponent
        {
            public async Task<IViewComponentResult>InvokeAsync()
            {
               return View("SiteHeader") ;
            }
        }
            
        #endregion
    }
}