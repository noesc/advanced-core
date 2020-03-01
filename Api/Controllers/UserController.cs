using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("api/user/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserLogic userLogic = new UserLogic();
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var users = userLogic.GetUsers();
                return Ok(users);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

        [HttpPost]
        public IActionResult Create([FromBody]UserDTO user)
        {
            try
            {
                userLogic.AddUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody]UserDTO user)
        {
            try
            {
                userLogic.EditUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EditUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                userLogic.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = userLogic.GetUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}