using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Services
{
       public class ForgetPasswordFormForgetPasswordForm
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }
    }
    public class valid
    {
        public bool IsOk { get; set; }
        public string Message  { get; set; }
    }
    public class emailconfirm
    {
        public string username { get; set; }
        public string token { get; set; }
    }
    public class AuthObj
    {
    }
}
