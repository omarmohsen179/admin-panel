using AdminPanelApi.Core;
using AdminPanelApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public BranchController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var objlist = this.unitOfWork.BranchManager.Get(e => e.Active == true);
            if (objlist != null)
            {
                return Ok(objlist);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet("/")]
        public IActionResult Getxx()
        {
            return Ok("done ");
            
        }
        [HttpGet("admin")]
        public IActionResult Getuser()
        {
            var objlist = this.unitOfWork.BranchManager.GetAll();
            if (objlist != null)
            {
                return Ok(objlist);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Insert([FromBody] Branch Temp)
        {

            try
            {

                var numbers = this.unitOfWork.NumberManager.AddList(Temp.Numbers);
                var Object = this.unitOfWork.BranchManager.Add(Temp);
                if (Object.Id > 0)
                {
                    //      string JSONresult = JsonConvert.SerializeObject(member);
                    return Ok(Object);
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
        [HttpPut]

        public  IActionResult Update([FromBody] Branch Temp)
        {
            try
            {
              
                if (Temp.Numbers.Where(e => e.Id <= 0).Count() > 0)
                {
                    var add = this.unitOfWork.NumberManager.AddList(Temp.Numbers.Where(e => e.Id <= 0)).ToList();
                    Temp.Numbers = add;
                    Temp.Numbers.ToList().AddRange(Temp.Numbers.Where(e => e.Id > 0));
                }
              

                var Update = this.unitOfWork.NumberManager.UpdateList(Temp.Numbers);
           
              
                var Object = this.unitOfWork.BranchManager.Update(Temp);
                if (Object)
                {
                    //      string JSONresult = JsonConvert.SerializeObject(Temp);
                    return Ok(Temp);
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
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {

            try
            {
                var Object = this.unitOfWork.BranchManager.RemoveById(id);
                if (Object)
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
