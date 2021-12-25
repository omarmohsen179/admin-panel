﻿using AdminPanelApi.Core;
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using WhatsAppApi;

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

            var result = await _authService.RegisterAsync(model,userType:"user");

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
        [HttpGet("whatsapp")]
        public async Task<IActionResult> SendWhatsApp()
        {
            try
            {
                var data = new Dictionary<string, string>()
        {
            {"phone","+201006695562"},
            { "body", "hi thier " }
        };
                return Ok(await SendRequest("sendMessage", JsonConvert.SerializeObject(data)));
  
            }
            catch (Exception ex) { 
            return Ok(ex.Message);
            }



           
        }
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAsyncAdmin([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model,"Admin");

            if (!result.IsOk)
                return BadRequest(result.Message);

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
        [HttpGet("check-type")]
        [Authorize (Roles =UserRoles.Admin)]
        public async Task<IActionResult> UserType()
        {
           
            return Ok(200);
        }

        [HttpGet("check-ddtype")]
        public async Task<string> SendRequest(string method, string data)
        {
            string url = $"https://api.chat-api.com/instance389933/sendMessage?token=f80iimxtf7p5zvoj";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("", content);
                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}
