using AdminPanelApi.Core;
using AdminPanelApi.Helpers;
using AdminPanelApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var Sections = this.unitOfWork.SectionManager.Get();
            if (Sections != null)
            {
                return Ok(Sections);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult InsertMember([FromForm] IFormFile Image, [FromForm] Section Temp)
        {



    
            try
            {
                var texts = this.unitOfWork.TextManager.AddList(Temp.Text);
                var secion = this.unitOfWork.SectionManager.Add(Temp);
                if (secion.Id > 0)
                {
                    try
                    {

                        if (Image != null)
                        {
                            var result = _imageUploder.UplodeFile(Image);
                            if (result.isOk)
                            {
                                var images = new SectionImages() { SectionId = secion.Id, ImagePath = Temp.Image?.ImagePath, Section = Temp };
                                // var images = new SectionImages() { SectionId = Temp.Id,ImagePath= result.value,Section=Temp };
                                images.ImagePath = result.value;
                                var member = this.unitOfWork.SectionImagesManager.Update(Temp);
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
                    //      string JSONresult = JsonConvert.SerializeObject(Temp);
                    return Ok(Temp);
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

        public IActionResult Update([FromForm] IFormFile Image, [FromForm] Section Temp)
        {
       

            try
            {
              
                if (Image != null)
                {
                    var result = _imageUploder.UplodeFile(Image);
                    if (result.isOk)
                    {
                        var images = new SectionImages() { SectionId = Temp.Id, ImagePath = Temp.Image?.ImagePath, Section = Temp };
                        // var images = new SectionImages() { SectionId = Temp.Id,ImagePath= result.value,Section=Temp };
                        images.ImagePath = result.value;
                        var member = this.unitOfWork.SectionImagesManager.Update(Temp);
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
                var texts = this.unitOfWork.TextManager.UpdateList(Temp.Text);
                var member = this.unitOfWork.SectionManager.Update(Temp);
                if (member)
                {
                    //      string JSONresult = JsonConvert.SerializeObject(Temp);
                    return Ok(Temp);
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
