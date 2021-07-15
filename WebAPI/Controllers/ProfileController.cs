using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _profileService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbyuser")]
        public IActionResult GetListByUser(int userId)
        {
            var result = _profileService.GetListByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int profileId)
        {
            var result = _profileService.GetById(profileId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyuser")]
        public IActionResult GetByUser(int userId)
        {
            var result = _profileService.GetByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Profile profile)
        {
            var result = _profileService.Add(profile);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Profile profile)
        {
            var result = _profileService.Update(profile);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Profile profile)
        {
            var result = _profileService.Delete(profile);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
