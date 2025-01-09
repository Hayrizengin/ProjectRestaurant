using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.BannerDTO;
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
    public class BannerManager : IBannerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;

        public BannerManager(IGenericValidator validator, IMapper mapper, IUnitOfWork uow)
        {
            _validator = validator;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ApiResponse<BannerDTOResponse>> AddAsync(BannerDTORequest entity)
        {
            //await _validator.ValidateAsync(entity,typeof(BannerValidator));

            var banner = _mapper.Map<Banner>(entity);

            await _uow.BannerRepository.AddAsync(banner);
            await _uow.SaveChangeAsync();

            var bannerResponse = _mapper.Map<BannerDTOResponse>(banner);
            return ApiResponse<BannerDTOResponse>.SuccessResult(bannerResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var banner = await _uow.BannerRepository.GetAsync(x=>x.Id == id);

            if (banner is null)
            {
                var error = new ErrorResult(new List<string>
                {
                    $"{id}'li veri bulunamadı."
                });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            banner.IsActive = false;
            banner.IsDeleted = true;
            _uow.BannerRepository.Update(banner);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<BannerDTOResponse>>> GetAllAsync(BannerDTORequest? entity)
        {
            var banners = await _uow.BannerRepository.GetAllAsync(x=>x.IsActive==true && x.IsDeleted==false);

            if (!banners.Any())
            {
                var error = new ErrorResult(new List<string>
                {
                    "Veri bulunamadı."
                });
                return ApiResponse<IEnumerable<BannerDTOResponse>>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var bannerDTOResponses = _mapper.Map<IEnumerable<BannerDTOResponse>>(banners);
            return ApiResponse<IEnumerable<BannerDTOResponse>>.SuccessResult(bannerDTOResponses);
        }

        public async Task<ApiResponse<BannerDTOResponse>> GetAsync(int id)
        {
            var banner = await _uow.BannerRepository.GetAsync(x=>x.Id == id && x.IsActive==true && x.IsDeleted==false);

            if (banner is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'sine sahip veri bulunamadı" });
                return ApiResponse<BannerDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var bannerDTOResponse = _mapper.Map<BannerDTOResponse>(banner);
            return ApiResponse<BannerDTOResponse>.SuccessResult(bannerDTOResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(BannerDTOUpdateRequest entity)
        {
            var banner = await _uow.BannerRepository.GetAsync(x=>x.Id == entity.Id && x.IsActive == true && x.IsDeleted == false);

            if (banner is null)
            {
                var error = new ErrorResult(new List<string> { $"{entity.Title} ile ilgili veri bulunamadı." });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            _mapper.Map(entity, banner);

            _uow.BannerRepository.Update(banner);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);

        }
    }
}
