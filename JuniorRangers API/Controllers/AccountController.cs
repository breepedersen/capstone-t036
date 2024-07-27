using AutoMapper;
using JuniorRangers_API.Dto.Account;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using JuniorRangers_API.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JuniorRangers_API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly string RangerRegCode = "Ranger123";    //TODO: secure register code for rangers

        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager) 
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            // Find user using UserManager
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if(user == null) return Unauthorized("Invalid username");

            // Check password using SignInManager
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            // Return user
            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var user = new User
                {
                    UserName = registerDto.Username,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if(createdUser.Succeeded)
                {
                    // Register as student or ranger according to role selected
                    IdentityResult roleResult;
                    if (registerDto.Role == "Student")
                    {
                        roleResult = await _userManager.AddToRoleAsync(user, "Student");
                    }
                    else if (registerDto.Role == "Ranger" && registerDto.RangerCode == RangerRegCode)   //reqiore valid ranger code to register as ranger
                    {
                        roleResult = await _userManager.AddToRoleAsync(user, "Ranger");
                    }
                    else
                    {
                        await _userManager.DeleteAsync(user);
                        if (registerDto.Role == "Ranger" && registerDto.RangerCode != RangerRegCode)
                        {
                            return BadRequest("Invalid ranger code.");
                        }
                        return BadRequest("Invalid role specified.");
                    }

                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = user.UserName,
                                Token = _tokenService.CreateToken(user)
                            }
                        );
                    }
                    else
                    {
                        await _userManager.DeleteAsync(user);
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            } catch (Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}