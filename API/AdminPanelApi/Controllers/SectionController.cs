using AdminPanelApi.Core;
using AdminPanelApi.DTOs;
using AdminPanelApi.Helpers;
using AdminPanelApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public static ImageUploder _imageUploder;

        public SectionController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment enviroment)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
            _imageUploder = new ImageUploder(enviroment);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Sections = this.unitOfWork.SectionManager.Get(includeProperties: "Text,Image");
            if (Sections != null)
            {
                string JSONresult = JsonConvert.SerializeObject(Sections);
                return Ok(JSONresult);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet("{page}")]
        public IActionResult Getpage(string page)
        {
            var Sections = this.unitOfWork.SectionManager.Get(includeProperties: "Text,Image", filter:e=>e.SectionName==page);
            if (Sections != null)
            {
                string JSONresult = JsonConvert.SerializeObject(Sections);
                return Ok(JSONresult);
            }
            else
            {
                return Ok();
            }
        }
        [HttpPost]
        public IActionResult InsertMember([FromForm] IFormFile Imageup, [FromForm] Section Temp)
        {



    
            try
            {
                var texts = this.unitOfWork.TextManager.AddList(Temp.Text);
                var secion = this.unitOfWork.SectionManager.Add(Temp);
                if (secion.Id > 0)
                {
                    try
                    {

                        if (Imageup != null)
                        {
                            var result = _imageUploder.UplodeFile(Imageup);
                            if (result.isOk)
                            {
                                var images = new SectionImages() { SectionId = secion.Id, ImagePath = Temp.Image?.ImagePath, Section = Temp };
                                // var images = new SectionImages() { SectionId = Temp.Id,ImagePath= result.value,Section=Temp };
                        images.ImagePath = result.value;
                        var member = this.unitOfWork.SectionImagesManager.Update(images);
                        Temp.Image = images;
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
                    string JSONresult = JsonConvert.SerializeObject(Temp);
                    return Ok(JSONresult);
                }
                else
                {
                    return BadRequest(secion);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]

        public IActionResult Update([FromForm] IFormFile Imageup, [FromForm] SectionDto Tempx)
        {
       
            Section Temp= _mapper.Map<Section>(Tempx);
            try
            {
              
                if (Imageup != null)
                {
                    var result = _imageUploder.UplodeFile(Imageup);
                    if (result.isOk)
                    {
                        var images = new SectionImages() { SectionId = Temp.Id, ImagePath = Temp.Image?.ImagePath, Section = Temp };
                      
                        images.ImagePath = result.value;
                        var member = this.unitOfWork.SectionImagesManager.Update(images);
                        Temp.Image = images;
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
                foreach (var ele in Temp.Text)
                {
                    ele.SectionId = Temp.Id;
                    ele.Section = Temp;
                }
                var texts = this.unitOfWork.TextManager.UpdateList(Temp.Text);
                var obj = this.unitOfWork.SectionManager.Update(Temp);
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
                var member = this.unitOfWork.SectionManager.RemoveById(id);
                if (member)
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
