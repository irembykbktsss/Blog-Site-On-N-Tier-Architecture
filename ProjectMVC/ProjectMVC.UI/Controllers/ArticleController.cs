using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.BLL.ArticleService;
using ProjectMVC.BLL.DTOs.ArticleDTOs;
using ProjectMVC.BLL.DTOs.SubjectDTOs;
using ProjectMVC.BLL.SubjectService;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.UI.Models.VMs.ArticleVMs;
using ProjectMVC.UI.Models.VMs.SubjectVMs;
using System.Security.Claims;

namespace ProjectMVC.UI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, ISubjectService subjectService, IMapper mapper)
        {
            _articleService = articleService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllAsync();
            var randomArticles = articles.OrderBy(a => Guid.NewGuid()).Take(20).ToList();
            var articleVM = randomArticles.Select(x => _mapper.Map<ArticleListVM>(x)).ToList();

            return View(articleVM);
        }

        /// <summary>
        /// Kullanıca ait makalelerin listelendiği sayfaya ait action
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> UserArticleList()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var article = await _articleService.GetAllByUserAsync(user);
            var articleVM = article.Select(x => _mapper.Map<ArticleListVM>(x)).ToList();
            return View(articleVM);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(user == null)
            {
                return RedirectToAction("Login", "Appuser");
            }

            var subjects = await _subjectService.GetAllAsync();
            List<SubjectListVM> subjectListVMs = subjects.Select(x => _mapper.Map<SubjectListDTO, SubjectListVM>(x)).ToList();

            ArticleCreateVM articleCreateVM = new ArticleCreateVM
            {
                Subjects = subjectListVMs,
                AppUserId = user                
            };
            
            return View(articleCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateVM articleCreateVM)
        {
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (ModelState.IsValid)
                {
                    ArticleCreateDTO articleDTO = _mapper.Map<ArticleCreateDTO>(articleCreateVM);
                    articleDTO.AppUserId = user;
                    articleDTO.AvgReadTime = _articleService.CalculateAvgReadTime(articleCreateVM.Detail);
                    await _articleService.AddAsync(articleDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(articleCreateVM);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(articleCreateVM);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var subjects = await _subjectService.GetAllAsync();
            List<SubjectListVM> subjectListVMs = subjects.Select(x => _mapper.Map<SubjectListDTO, SubjectListVM>(x)).ToList();

            ArticleListDTO article = await _articleService.GetByIdAsync(id);
            if(article == null)
            {
                return RedirectToAction("NotFound");
            }
            ArticleUpdateVM articleUpdateVM = _mapper.Map<ArticleUpdateVM>(article);
            articleUpdateVM.Subjects = subjectListVMs;
            articleUpdateVM.AppUserId = user;
            return View(articleUpdateVM);
        }

        [HttpPost]
        public IActionResult Update(ArticleUpdateVM articleUpdateVM)
        {
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (ModelState.IsValid)
                {
                    ArticleUpdateDTO article = _mapper.Map<ArticleUpdateDTO>(articleUpdateVM);
                    article.AppUserId = user;
                    _articleService.Update(article);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(articleUpdateVM);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(articleUpdateVM);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ArticleListDTO articleDto = await _articleService.GetByIdAsync(Id);
                    Article article = _mapper.Map<Article>(articleDto);

                    await _articleService.DeleteAsync(article.Id);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index");
            }
                     
        }

        [HttpGet]
        public async Task<IActionResult> Detail(ArticleUpdateVM articleUpdateVM)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ArticleListDTO articleDto = await _articleService.GetByIdAsync(articleUpdateVM.Id);
            ArticleUpdateVM articledetails = _mapper.Map<ArticleUpdateVM>(articleDto);
            articledetails.AppUserId = user;
           
            return View(articledetails);
        }


        /// <summary>
        /// Konular listesinden seçilen konuya göre makalelerin listelendiği sayfaya ait action
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ArticleBySubjectList(int subjectId)
        {          
            var article = await _articleService.GetAllBySubjectAsync(subjectId);
            var articleVM = article.Select(x => _mapper.Map<ArticleListVM>(x)).ToList();
            return View(articleVM);
        }
    }
}
