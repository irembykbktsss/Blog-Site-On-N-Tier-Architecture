using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.BLL.AppUserService;
using ProjectMVC.BLL.DTOs.AppUserDTOs;
using ProjectMVC.UI.Models.VMs.AppUserVMs;
using System.Security.Claims;

namespace ProjectMVC.UI.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserService appUserservice, IMapper mapper)
        {
            _appUserService = appUserservice;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM addVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<RegisterDTO>(addVM);
                    var result = await _appUserService.Register(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description.ToString());
                        }
                    }
                }
                return View(addVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(addVM);
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            try
            {
                LoginDTO userdto = _mapper.Map<LoginDTO>(loginVM);

                if (userdto != null)
                {
                    var result = await _appUserService.Login(userdto);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Article");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Hatalı giriş");
                    }
                }
                else
                {
                    ModelState.AddModelError("Kullanıcı bulunamadı", "Lütfen kayıt olunuz.");
                }

                return View(loginVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(loginVM);
            }

        }

        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();
            return RedirectToAction("Index", "Article");
        }


        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
           
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            id = user;

            AppUserListDTO userDTO = await _appUserService.GetByIdAsync(id);

            if (userDTO == null)
            {
                return RedirectToAction("NotFound");
            }

            AppUserUpdateVM userUpdateVM = _mapper.Map<AppUserUpdateVM>(userDTO);
            return View(userUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateVM updateVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDTO = _mapper.Map<AppUserUpdateDTO>(updateVM);
                    var result = await _appUserService.Update(userDTO);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Article");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                return View(updateVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(updateVM);
            }
            
        }
    }
}
