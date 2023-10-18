using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectMVC.BLL.DTOs.AppUserDTOs;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(IAppUserRepository userRepo, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Gelen Id değerine göre kullanıcıyı getirme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppUserListDTO> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var mappedUser = _mapper.Map<AppUserListDTO>(user);
            return mappedUser;
        }

        /// <summary>
        /// Sisteme giriş işlemi
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<SignInResult> Login(LoginDTO loginDTO)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, loginDTO.Password, true, false);
                return result;
            }
            else
            {
                throw new Exception("Login işlemi başarısız.Mail adresinizi ve şifrenizi kontrol ediniz.");
            }
        }

        /// <summary>
        /// Sistemden çıkış işlemi
        /// </summary>
        /// <returns></returns>
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }


        /// <summary>
        /// Sisteme kayıt olma işlemi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IdentityResult> Register(RegisterDTO entity)
        {
            if (entity != null)
            {
                AppUser user = _mapper.Map<AppUser>(entity);

                // E-posta adresinden kullanıcı adını ve isim/soyisimi oluşturuldu
                string[] emailParts = entity.Email.Split('@');
                if (emailParts.Length >= 2)
                {
                    string username = emailParts[0];
                    string[] nameParts = username.Split('.');

                    if (nameParts.Length >= 2)
                    {
                        user.UserName = username;
                        user.FirstName = nameParts[0];
                        user.LastName = nameParts[1];
                    }
                    else
                    {
                        user.UserName = username;
                        user.FirstName = "Bilinmiyor";
                        user.LastName = "Bilinmiyor";
                    }
                }
                else
                {
                    user.UserName = "Bilinmiyor";
                    user.FirstName = "Bilinmiyor";
                    user.LastName = "Bilinmiyor";
                }

                var addUser = await _userManager.CreateAsync(user, entity.Password);
                return addUser;
            }
            else
            {
                throw new Exception("Ekleme işleminde hata alındı..");
            }
        }

        /// <summary>
        /// Sisteme kayıtlı kullanıcı bilgilerini güncelleme işlemi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IdentityResult> Update(AppUserUpdateDTO entity)
        {
            if (entity != null)
            {
                var existingUser = await _userManager.FindByIdAsync(entity.Id);
                if (existingUser != null)
                {
                    existingUser.FirstName = entity.FirstName;
                    existingUser.LastName = entity.LastName;
                    existingUser.Email = entity.Email;
                    existingUser.PhoneNumber = entity.PhoneNumber;

                    existingUser.UpdatedDate = DateTime.Now;
                    existingUser.Status = CORE.Enums.Status.Modified;

                    var result = await _userManager.UpdateAsync(existingUser);
                    return result;
                }
                else
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
                }
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "Güncelleme işleminde hata alındı." });
            }
        }
    }

}
