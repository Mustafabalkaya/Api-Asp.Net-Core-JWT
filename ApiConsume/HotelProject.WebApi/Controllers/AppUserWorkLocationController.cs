﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var values=_appUserService.TUsersListWorkLocation();
            Context context = new Context();
            var values=context.Users.Include(x => x.WorkLocation).Select(y => new AppUserWorkLocationViewModel
            {
                Name= y.Name,
                Surname=y.SurName,
                WorkLocationName=y.WorkLocation.WorkLocationName,
                City=y.City,
                Country = y.Country,

                Gender = y.Gender,

                ImageUrl=y.ImageUrl
            }).ToList();
            return Ok(values);
        }
    }
}
