using AdminPanelApi.Core;
using AdminPanelApi.DTOs;
using AdminPanelApi.EmailSender;
using AdminPanelApi.Models;
using AdminPanelApi.Services;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsOk)
                return BadRequest(result.Message);

            //using (var client = new HttpClient())
            //{
            //    HttpResponseMessage responseAsync = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

            //    if (responseAsync.IsSuccessStatusCode)
            //    {
            //        //Storing the response details received from web api
            //        var data = responseAsync.Content.ReadAsStringAsync().Result;

            //        result.Message = JsonConvert.SerializeObject(data);
            //    }

            //};

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _jwtService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost("forget-passworx")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordFormForgetPasswordForm model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ForgetPassword(model,"");

            if (!result.IsOk)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
