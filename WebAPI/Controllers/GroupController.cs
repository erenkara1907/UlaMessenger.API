using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _groupService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbyuser")]
        public IActionResult GetListByUser(int userId)
        {
            var result = _groupService.GetListByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int groupId)
        {
            var result = _groupService.GetById(groupId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Group group)
        {
            var result = _groupService.Add(group);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Group group)
        {
            var result = _groupService.Update(group);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Group group)
        {
            var result = _groupService.Delete(group);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
