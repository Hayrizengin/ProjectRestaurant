using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.AboutDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using ProjectRestaurant.Tools.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;

        public AboutManager(IGenericValidator validator, IMapper mapper, IUnitOfWork uow)
        {
            _validator = validator;
            _mapper = mapper;
            _uow = uow;
        }

        /// <summary>
        /// Sayfanın hakkında kısmına ekleme yapar.
        /// </summary>
        /// <param name="entity">Eklenecek öğrenin request DTO'su</param>
        /// <returns>Eklenen öğrenin return DTO'su</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse<AboutDTOResponse>> AddAsync(AboutDTORequest entity)
        {
            // Gelen DTO'yu doğrula
            //await _validator.ValidateAsync(entity,typeof(AboutAddValidator));

            // Gelen DTO'yu Entity nesnesine çevir.
            var about = _mapper.Map<About>(entity);

            // Ekle ve değişiklikleri kaydet
            await _uow.AboutRepository.AddAsync(about);
            await _uow.SaveChangeAsync();

            // Eklenen veriyi response'a çevir ve geri döndür.
            var aboutResponse = _mapper.Map<AboutDTOResponse>(about);
            return ApiResponse<AboutDTOResponse>.SuccessResult(aboutResponse);
        }


        /// <summary>
        /// Belirtilen nesneyi siler
        /// </summary>
        /// <param name="id">Silinecek nesnenin id'si</param>
        /// <returns>Silme işleminin sonucu</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            // id ile bul
            var about = await _uow.AboutRepository.GetAsync(a => a.Id == id); // bu kısımda şuan interfaceden int id alıyor ama guid'e görede işlem yapabilmemiz lazım gelen veriyi değiştireceğiz.

            //about boş ise hata döndür.
            if (about == null)
            {
                var error = new ErrorResult(new List<string>
                {
                    "Silinecek nesne bulunamadı."
                });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            // nesneyi pasif hale getir ve silindi olarak işaretle
            about.IsActive = false;
            about.IsDeleted = true;
            _uow.AboutRepository.Update(about);
            await _uow.SaveChangeAsync();

            //silme başarılı
            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<AboutDTOResponse>>> GetAllAsync(AboutDTORequest entity)
        {
            // tüm verileri al
            var abouts = await _uow.AboutRepository.GetAllAsync(x=>x.IsActive == true && x.IsDeleted==false);

            //eğer veri yoksa hata döndür
            if (!abouts.Any())
            {
                var error = new ErrorResult(new List<string> { "Veri bulunamadı." });
                return ApiResponse<IEnumerable<AboutDTOResponse>>.FailureResult(error, HttpStatusCode.NotFound);
            }

            //veriyi dtoResponse'a dönüştür
            var aboutDTOResponses = _mapper.Map<IEnumerable<AboutDTOResponse>>(abouts);
            return ApiResponse<IEnumerable<AboutDTOResponse >>.SuccessResult(aboutDTOResponses);
        }

        public async Task<ApiResponse<AboutDTOResponse>> GetAsync(int id)
        {
            // veriyi id ile bul
            var about = await _uow.AboutRepository.GetAsync(x=>x.Id == id && x.IsActive==true && x.IsDeleted==false);

            //veri bulunmazsa hata döndür.
            if (about is null)
            {
                var error = new ErrorResult(new List<string>() { "Veri bulunamadı." });
                return ApiResponse<AboutDTOResponse>.FailureResult(error, HttpStatusCode.NotFound);
            }

            //veriyi dtoResponse'a dönüştür.
            var aboutDTOResponse = _mapper.Map<AboutDTOResponse>(about);
            return ApiResponse<AboutDTOResponse>.SuccessResult(aboutDTOResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(AboutDTOUpdateRequest entity)
        {
            // veriyi doğrula
            // await _validator.ValidateAsync(entity,typeof(AboutUpdateValidator));

            // veriyi bul
            var about = await _uow.AboutRepository.GetAsync(x=>x.Guid == entity.Guid || x.Id == entity.Id);

            //veri yoksa hata döndür
            if (about is null)
            {
                var error = new ErrorResult(new List<string> { "Güncellenecek veri bulunamadı" });
                return ApiResponse<bool>.FailureResult(error, HttpStatusCode.NotFound);
            }

            // dto'yu mevcut veri nesnesine haritala
            _mapper.Map(entity, about);

            // güncelle
            _uow.AboutRepository.Update(about);
            await _uow.SaveChangeAsync();

            //güncelleme başarılı
            return ApiResponse<bool>.SuccessResult(true);
        }
    }
}
