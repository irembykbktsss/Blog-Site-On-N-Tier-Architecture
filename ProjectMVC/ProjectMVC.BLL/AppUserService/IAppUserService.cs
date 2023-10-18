using Microsoft.AspNetCore.Identity;
using ProjectMVC.BLL.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.AppUserService
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO entity);
        Task<SignInResult> Login(LoginDTO loginDTO);
        Task LogOut();

        Task<IdentityResult> Update(AppUserUpdateDTO entity);
        Task<AppUserListDTO> GetByIdAsync(string id);
    }
}
