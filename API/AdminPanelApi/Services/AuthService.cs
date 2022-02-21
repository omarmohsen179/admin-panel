using AdminPanelApi.DTOs;
using AdminPanelApi.EmailSender;
using AdminPanelApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Services
{
 
    public interface IAuthService
    {
        Task<valid> RegisterAsync(RegisterModel model, string userType);
        Task<valid> ConfirmEmail(emailconfirm model); 
        Task<valid> ForgetPassword(ForgetPasswordFormForgetPasswordForm model, string URL);
        Task<valid> CheckUserType(string username);
    }
 
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IJwtService _jwtService;
        private readonly IMailService mailService;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtService jwtService, IOptions<MailSettings> mailSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public async Task<valid> RegisterAsync(RegisterModel model,string userType)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new valid
                {
                    IsOk = false,
                    Message = "Email is already registered!"
                };

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
               
            };


       
             var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Description}\n");

                return new valid
                {
                    IsOk = false,
                    Message = errors
                };
            }
            
                if (model.url == null || model.url.Length == 0 && userType == UserRoles.User)
                {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
                try
                    {

                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        await mailService.SendWelcomeEmailAsync(new MailRequest()
                        {
                            ToEmail = model.Email,
                            Subject = "Email Confirmation",
                            path = model.url + "?username=" + user.UserName + "&token=" + Base64Encode(token),
                            username = user.UserName,
                            MainText = "you can confirm your email from this button"
                        });
                        return new valid
                        {
                            IsOk = true,
                            Message = "success"
                        };
                    }
                    catch (Exception ex)
                    {
                        return new valid
                        {
                            IsOk = false,
                            Message = ex.ToString()
                        };
                    }
                }
            
            else if (userType == UserRoles.Admin || userType == UserRoles.SuperAdmin) {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }




         //    var jwtSecurityToken = await _jwtService.CreateJwtToken(user);

             return new()
             {
                 IsOk = true,
                 Message = "success"
             };
        }
        public async Task<valid> ForgetPassword( ForgetPasswordFormForgetPasswordForm model,string URL)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.email);
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await mailService.SendWelcomeEmailAsync(new MailRequest()
                {
                    ToEmail = model.email,
                    Subject = "Reset password",
                    path = URL + "?email=" + model.email + "&token=" + Base64Encode(token),
                    username = user.UserName,
                    MainText = "you can reset your password from this button"
                });
                return new valid
                {
                    IsOk = true,
                    Message = "success"
                };
            }
            catch (Exception ex)
            {
                return new valid
                {
                    IsOk = false,
                    Message = ex.ToString()
                };
            }

        }
        public async Task<valid> ConfirmEmail(emailconfirm model)
        {

            var user = await _userManager.FindByNameAsync(model.username);

            if (user != null)
            {
                var actoin = await _userManager.ConfirmEmailAsync(user, model.token);
                if (actoin.Succeeded)
                {

                    return new valid
                    {
                        IsOk = true,
                        Message = "success"
                    };

                }

                return new valid
                {
                    IsOk = false,
                    Message = model.ToString()
                };

            }

            return new valid
            {
                IsOk = false,
                Message = model.ToString()
            };
        }

        public async Task<valid> CheckUserType(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);
            return new valid
            {
                IsOk = true,
                Message = roles.ElementAt(0).ToString()
            };
          


        }
    }
    }
