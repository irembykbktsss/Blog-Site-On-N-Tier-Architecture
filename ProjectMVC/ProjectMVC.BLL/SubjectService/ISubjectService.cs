using ProjectMVC.BLL.DTOs.SubjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.SubjectService
{
    public interface ISubjectService
    {
        Task<bool> AddAsync(SubjectCreateDTO subjectCreateDTO);
        void Update(SubjectUpdateDTO subjectUpdateDTO);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<SubjectListDTO>> GetAllAsync();
        Task<SubjectListDTO> GetByIdAsync(int id);
    }
}
