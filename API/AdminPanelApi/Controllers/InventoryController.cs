
using AutoMapper;
using AdminPanelApi.Core;
using AdminPanelApi.Helpers;
using AdminPanelApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace AdminPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public static ImageUploder _imageUploder;

        public InventoryController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment enviroment)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
            _imageUploder = new ImageUploder(enviroment);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Members = this.unitOfWork.InventorsManager.Get(e=>e.Active==true);
            if (Members != null)
            {
                string JSONresult = JsonConvert.SerializeObject(Members);
                return Ok(JSONresult);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet("admin")]
        public IActionResult Getuser()
        {
            var objlist = this.unitOfWork.InventorsManager.GetAll();
            if (objlist != null)
            {
                string JSONresult = JsonConvert.SerializeObject(objlist);
                return Ok(JSONresult);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult InsertMember([FromForm] IFormFile Image, [FromForm] Inventor Temp)
        {

            try
            {
                if (Image != null)
                {
                    var result = _imageUploder.UplodeFile(Image);
                    if (result.isOk)
                    {
                        Temp.ImagePath = result.value;
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }



            try
            {
  
                var member = this.unitOfWork.InventorsManager.Add(Temp);
                if (member.Id > 0)
                {
                        string JSONresult = JsonConvert.SerializeObject(member);
                    return Ok(JSONresult);
                }
                else
                {
                    return BadRequest(member);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]

        public IActionResult UpdateMember([FromForm] IFormFile Image, [FromForm] Inventor Temp)
        {

            try
            {
                if (Image != null)
                {
                    var result = _imageUploder.UplodeFile(Image);
                    if (result.isOk)
                    {
                        Temp.ImagePath = result.value;
                    }
                    else
                    {
                        return BadRequest("Image not valid");
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            try
            {
                var obj = this.unitOfWork.InventorsManager.Update(Temp);
                if (obj)
                {
                   string JSONresult = JsonConvert.SerializeObject(Temp);
                    return Ok(JSONresult);
                }
                else
                {
                    return BadRequest(obj);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {

            try
            {
                var obj = this.unitOfWork.InventorsManager.RemoveById(id);
                if (obj)
                {
                    return Ok(200);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
