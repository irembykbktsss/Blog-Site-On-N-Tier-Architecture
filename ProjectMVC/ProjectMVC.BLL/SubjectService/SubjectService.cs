using AutoMapper;
using ProjectMVC.BLL.DTOs.SubjectDTOs;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.CORE.Enums;
using ProjectMVC.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepo;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepo, IMapper mapper)
        {
            _subjectRepo = subjectRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Konu ekleme işlemi
        /// </summary>
        /// <param name="subjectCreateDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddAsync(SubjectCreateDTO subjectCreateDTO)
        {
            if (subjectCreateDTO != null)
            {
                Subject subject = _mapper.Map<Subject>(subjectCreateDTO);
                var result = await _subjectRepo.AddAsync(subject);
                return result;
            }
            else
            {
                throw new Exception("Ekleme işleminde hata alındı..");
            }
        }

        /// <summary>
        /// Konu silme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteAsync(int id)
        {
            var deleteSubject = await _subjectRepo.GetWhere(c => c.Id == id);

            if (deleteSubject != null)
            {
                deleteSubject.DeletedDate = DateTime.Now;
                deleteSubject.Status = Status.Passive;
                var result = _subjectRepo.Update(deleteSubject);
                return result;
            }
            else
            {
                throw new Exception("Silme işleminde hata alındı..");
            }
        }

        /// <summary>
        /// Durumu pasif olmayan konuları listeleme işlemi
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SubjectListDTO>> GetAllAsync()
        {
            var subjectList = await _subjectRepo.GetAllWhereAsync(x => x.Status != Status.Passive);
            var listDTO = subjectList.Select(x => _mapper.Map<SubjectListDTO>(x));
            return listDTO;
        }

        /// <summary>
        /// Gelen id değerine göre konuyu getirme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<SubjectListDTO> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                Subject subject = await _subjectRepo.GetWhere(x => x.Id == id);
                SubjectListDTO subjectDTO = _mapper.Map<SubjectListDTO>(subject);
                return subjectDTO;
            }
            else
            {
                throw new Exception("Böyle bir id değeri yoktur..");
            }
        }

        /// <summary>
        /// Konu güncelleme işlemi
        /// </summary>
        /// <param name="subjectUpdateDTO"></param>
        /// <exception cref="Exception"></exception>
        public void Update(SubjectUpdateDTO subjectUpdateDTO)
        {
            if (subjectUpdateDTO != null)
            {
                Subject subject = _mapper.Map<Subject>(subjectUpdateDTO);
                subject.UpdatedDate = DateTime.Now;
                subject.Status = Status.Modified;
                _subjectRepo.Update(subject);
            }
            else
            {
                throw new Exception("Güncelleme işleminde hata alındı...");
            }
        }
    }
}
