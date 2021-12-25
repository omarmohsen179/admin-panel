using AdminPanelApi.Core;
using AdminPanelApi.Models;
using AutoMapper;
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
            var objlist = this.unitOfWork.BranchManager.Get(e => e.Active == true,includeProperties:"Numbers");
            if (objlist != null)
            {
                string JSONresult = JsonConvert.SerializeObject(objlist);
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
            var objlist = this.unitOfWork.BranchManager.Get( includeProperties: "Numbers");
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
        public IActionResult Insert([FromBody] Branch Temp)
        {

            try
            {

                var numbers = Temp.Numbers;//this.unitOfWork.NumberManager.AddList(Temp.Numbers);
                Temp.Numbers = null;

                var Object = this.unitOfWork.BranchManager.Add(Temp);
                if (Object.Id > 0)
                {
                    if (numbers.Count() > 0) {
                        foreach (var ele in numbers)
                        {
                            ele.Id = 0;
                            ele.BranchId = Object.Id;
                        }
                        numbers = this.unitOfWork.NumberManager.AddList(numbers);
                        if (numbers == null)
                        {
                            return BadRequest();
                        }
                        Object.Numbers = numbers;
                    }

                  
                    string JSONresult = JsonConvert.SerializeObject(Object);
                    return Ok(JSONresult);
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
                var NewObjects = Temp.Numbers.Where(e => e.Id <= 0).ToList();
                var OldObjects = Temp.Numbers.Where(e => e.Id > 0).ToList();
                var myList = new List<Number>();
             
                if (NewObjects.Count() > 0)
                {
                    foreach (var ele in NewObjects) {
                          ele.Id = 0;
                        ele.BranchId = Temp.Id;
                    }
                    var add = this.unitOfWork.NumberManager.AddList(NewObjects);    
                    NewObjects = add.ToList();
                }
                myList.AddRange(OldObjects.ToList());
                myList.AddRange(NewObjects.ToList());
               
                var Update = this.unitOfWork.NumberManager.UpdateList(myList);
                var numbers = myList;
                Temp.Numbers = null;
                var Object = this.unitOfWork.BranchManager.Update(Temp);
                if (Object)
                {
                    Temp.Numbers = numbers;
                     string JSONresult = JsonConvert.SerializeObject(Temp);
                    return Ok(JSONresult);
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
        [HttpDelete("number/{id}")]

        public IActionResult DeleteNumber(int id)
        {

            try
            {
                var Object = this.unitOfWork.NumberManager.RemoveById(id);
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
