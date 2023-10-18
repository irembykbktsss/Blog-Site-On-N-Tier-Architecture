using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.BLL.DTOs.SubjectDTOs;
using ProjectMVC.BLL.SubjectService;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.UI.Models.VMs.SubjectVMs;

namespace ProjectMVC.UI.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subjects = await _subjectService.GetAllAsync();
            var subjectsVM = subjects.Select(x => _mapper.Map<SubjectListVM>(x)).ToList();
            return View(subjectsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectCreateVM subjectCreateVM)
        {
            if (ModelState.IsValid)
            {
                SubjectCreateDTO subject = _mapper.Map<SubjectCreateDTO>(subjectCreateVM);
                await _subjectService.AddAsync(subject);
                return RedirectToAction("Index");
            }
            else
            {
                return View(subjectCreateVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SubjectListDTO subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
            {
                return RedirectToAction("NotFound");
            }

            SubjectUpdateVM subjectUpdateVM = _mapper.Map<SubjectUpdateVM>(subject);
            return View(subjectUpdateVM);
        }


        [HttpPost]
        public IActionResult Update(SubjectUpdateVM subjectUpdateVM)
        {
            if (ModelState.IsValid)
            {
                SubjectUpdateDTO subject = _mapper.Map<SubjectUpdateDTO>(subjectUpdateVM);
                _subjectService.Update(subject);
                return RedirectToAction("Index");
            }
            else
            {
                return View(subjectUpdateVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            SubjectListDTO subjectDeleted = await _subjectService.GetByIdAsync(Id);
            Subject subjectDel = _mapper.Map<Subject>(subjectDeleted);

            await _subjectService.DeleteAsync(subjectDel.Id);
            return RedirectToAction("Index");

        }
    }
}
