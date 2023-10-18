using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.BLL.AppUserService;
using ProjectMVC.BLL.ArticleService;
using ProjectMVC.BLL.SubjectService;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.CORE.Repositories;
using ProjectMVC.REPO.Context;
using ProjectMVC.REPO.Repositories;

namespace ProjectMVC.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //db baðlantýsý
            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(conn);
                options.UseLazyLoadingProxies();
            });


            //repository
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
            builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
            builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

            //service
            builder.Services.AddTransient<IAppUserService, AppUserService>();
            builder.Services.AddTransient<ISubjectService, SubjectService>();
            builder.Services.AddTransient<IArticleService, ArticleService>();   

            //add identity service
            var a = builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //password
                options.Password.RequireDigit = false;              
                options.Password.RequiredLength = 3;                //min length
                options.Password.RequireLowercase = false;          
                options.Password.RequireUppercase = false;          
                options.Password.RequireNonAlphanumeric = false;    


                //user
                options.User.RequireUniqueEmail = true;            //eposta adresleri benzersiz olmalý
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";       //izin verilen karakterler

                //signin
                options.SignIn.RequireConfirmedEmail = false;       //e-posta onayý gereksin mi
                options.SignIn.RequireConfirmedPhoneNumber = false;    //telefon onayý gereksin mi
                options.SignIn.RequireConfirmedAccount = false;        //hesap onayý gereksin mi


            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddRoles<IdentityRole>();        




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //kimlik doðrulama
            app.UseAuthentication();

            //yetkilendirme
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Article}/{action=Index}/{id?}");

            app.Run();
        }
    }
}