using System.ComponentModel.DataAnnotations;

namespace RayaneGostar.Domain.Models.ViewModels
{
    public class LoginUserViewModel
    {
        
        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

    }
    public enum LoginUserResult
    {
       NotFound,
        NotActive,
        Success,
        IsBlocked
 
    }
}