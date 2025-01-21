using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.SocialMediaDTO;
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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;

        public SocialMediaManager(IGenericValidator validator, IMapper mapper, IUnitOfWork uow)
        {
            _validator = validator;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<ApiResponse<SocialMediaDTOResponse>> AddAsync(SocialMediaDTORequest entity)
        {
            //_validator.ValidateAsync(entity,typeof(SocialMediaDTOAddValidator));

            var socialMedia = _mapper.Map<SocialMedia>(entity);

            await _uow.SocialMediaRepository.AddAsync(socialMedia);
            await _uow.SaveChangeAsync();

            var socialMediaResponse = _mapper.Map<SocialMediaDTOResponse>(socialMedia);
            return ApiResponse<SocialMediaDTOResponse>.SuccessResult(socialMediaResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var socialMedia = await _uow.SocialMediaRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (socialMedia is null)
            {
                var error = new ErrorResult(new List<string>{ $"{id}'sine sahip veri bulunamadı" });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            socialMedia.IsActive = false;
            socialMedia.IsDeleted = true;
            _uow.SocialMediaRepository.Update(socialMedia);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<SocialMediaDTOResponse>>> GetAllAsync(SocialMediaDTORequest? entity)
        {
            var socialMedias = await _uow.SocialMediaRepository.GetAllAsync(x=>x.IsActive == true && x.IsDeleted == false);

            if (!socialMedias.Any())
            {
                var error = new ErrorResult(new List<string> { "Veri bulunamadı." });
                return ApiResponse<IEnumerable<SocialMediaDTOResponse>>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var socialMediaDTOResponses = _mapper.Map<IEnumerable<SocialMediaDTOResponse>>(socialMedias);
            return ApiResponse<IEnumerable<SocialMediaDTOResponse>>.SuccessResult(socialMediaDTOResponses);
        }

        public async Task<ApiResponse<SocialMediaDTOResponse>> GetAsync(int id)
        {
            var socialMedia = await _uow.SocialMediaRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (socialMedia is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'sine sahip veri bulunamadı." });
                return ApiResponse<SocialMediaDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var socialMediaDTOResponse = _mapper.Map<SocialMediaDTOResponse>(socialMedia);
            return ApiResponse<SocialMediaDTOResponse>.SuccessResult(socialMediaDTOResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(SocialMediaDTOUpdateRequest entity)
        {
            var socialMedia = await _uow.SocialMediaRepository.GetAsync(x=>x.Id == entity.Id && x.IsActive == true && x.IsDeleted == false);

            if (socialMedia is null)
            {
                var error = new ErrorResult(new List<string> { $"{entity.Id}'sine sahip veri bulunamadı."});
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }
            entity.Id = socialMedia.Id;
            entity.Guid = socialMedia.Guid;
            _mapper.Map(entity, socialMedia);

            _uow.SocialMediaRepository.Update(socialMedia);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }
    }
}
