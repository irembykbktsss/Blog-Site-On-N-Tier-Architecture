using AutoMapper;
using ProjectMVC.BLL.DTOs.ArticleDTOs;
using ProjectMVC.CORE.Concrete;
using ProjectMVC.CORE.Enums;
using ProjectMVC.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.BLL.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepo;       
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepo, IMapper mapper)
        {
            _articleRepo = articleRepo;           
            _mapper = mapper;
        }

        /// <summary>
        /// Makale ekleme işlemi
        /// </summary>
        /// <param name="articleCreateDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddAsync(ArticleCreateDTO articleCreateDTO)
        {
            if (articleCreateDTO != null)
            {
                Article article = _mapper.Map<Article>(articleCreateDTO);
                var result = await _articleRepo.AddAsync(article);
                return result;
            }
            else
            {
                throw new Exception("Ekleme işleminde hata alındı..");
            }
        }

        /// <summary>
        /// Makale silme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteAsync(int id)
        {
            var deleteArticle = await _articleRepo.GetWhere(c => c.Id == id);

            if (deleteArticle != null)
            {
                deleteArticle.DeletedDate = DateTime.Now;
                deleteArticle.Status = Status.Passive;
                var result = _articleRepo.Update(deleteArticle);
                return result;
            }
            else
            {
                throw new Exception("Silme işleminde hata alındı..");
            }
        }

        /// <summary>
        /// Durumu pasif olmayan tüm makaleleri listeleme
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ArticleListDTO>> GetAllAsync()
        {
            var articleList = await _articleRepo.GetAllWhereAsync(x => x.Status != Status.Passive);
            var listDTO = articleList.Select(x => _mapper.Map<ArticleListDTO>(x));
            return listDTO;
        }

        /// <summary>
        /// Durumu pasif olmayan, gelen konu id değerine göre makaleleri listeleme
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ArticleListDTO>> GetAllBySubjectAsync(int subjectId)
        {
            var articleList = await _articleRepo.GetAllWhereAsync(x => (x.Status != Status.Passive && x.SubjectId == subjectId));
            var listDTO = articleList.Select(x => _mapper.Map<ArticleListDTO>(x));
            return listDTO;
        }


        /// <summary>
        /// Durumu pasif olmayan, gelen user id değerine göre makaleleri listeleme
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ArticleListDTO>> GetAllByUserAsync(string UserId)
        {           
            var articleList = await _articleRepo.GetAllWhereAsync(x => ( x.Status != Status.Passive && x.AppUserId == UserId));
            var listDTO = articleList.Select(x => _mapper.Map<ArticleListDTO>(x));
            return listDTO;
        }

        /// <summary>
        /// Gelen id değerine göre makaleyi getirme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ArticleListDTO> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                Article article = await _articleRepo.GetWhere(x => x.Id == id);
                ArticleListDTO articleDTO = _mapper.Map<ArticleListDTO>(article);
                return articleDTO;
            }
            else
            {
                throw new Exception("Böyle bir id bulunamadı..");
            }
        }

        /// <summary>
        /// Makale güncelleme işlemi
        /// </summary>
        /// <param name="articleUpdateDTO"></param>
        /// <exception cref="Exception"></exception>
        public void Update(ArticleUpdateDTO articleUpdateDTO)
        {
            if (articleUpdateDTO != null)
            {
                Article article = _mapper.Map<Article>(articleUpdateDTO);
                article.UpdatedDate = DateTime.Now;
                article.Status = Status.Modified;
                _articleRepo.Update(article);
            }
            else
            {
                throw new Exception("Güncelleme işleminde hata alındı..");
            }
        }

        /// <summary>
        /// Makale ortalama okunma süresini hesapla
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public int CalculateAvgReadTime(string detail)
        {
            // Metni boşluklara göre kelimelere ayır
            string[] kelimeler = detail.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Ortalama kelime hızı (kelime/dakika)
            double ortalamaKelimeHizi = 225; // Örnek değer değiştirilebilir

            // Metindeki toplam kelime sayısı
            int kelimeSayisi = kelimeler.Length;

            // Okuma süresini hesapla (dakika cinsinden)
            double okumaSuresiDakika = (double)kelimeSayisi / ortalamaKelimeHizi;

            return (int)okumaSuresiDakika;
        }
    }
}
