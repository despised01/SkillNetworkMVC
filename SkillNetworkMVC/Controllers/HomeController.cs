﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillNetworkMVC.Data.UnitOfWork;
using SkillNetworkMVC.Models;
using SkillNetworkMVC.Models.Users;
using SkillNetworkMVC.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SkillNetworkMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager,
            SignInManager<User> signInManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [Route("")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("MyPage", "AccountManager");
            }
            else
            {
                return View(new MainViewModel());
            }
        }

        [Route("[action]")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
