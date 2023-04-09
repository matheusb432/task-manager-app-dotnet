using System.Net;
using AutoMapper;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Utils;
using TaskManagerApp.Application.ViewModels.Photo;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TaskManagerApp.Application.Services
{
    public sealed class PhotoService : Service, IPhotoService
    {
        private readonly IPhotoRepository _repo;
        private readonly ICardRepository _cardRepo;

        public PhotoService(IPhotoRepository repo, ICardRepository cardRepo, IMapper mapper) : base(mapper)
        {
            _repo = repo;
            _cardRepo = cardRepo;
        }

        public OperationResult Query() => Success(Mapper.ProjectTo<PhotoViewModel>(_repo.Query()));

        public async Task<OperationResult> Insert(IFormFile image)
        {
            if (!(image?.Length > 0))
                return Error();

            var photo = Photo.FromBase64(ApplicationUtils.ConvertImageToBase64(image));

            await _repo.InsertAsync(photo);

            return Success(photo.Id);
        }

        public async Task<OperationResult> Update(int id, IFormFile image)
        {
            if (!(image?.Length > 0))
                return Error();

            var photoBase64 = ApplicationUtils.ConvertImageToBase64(image);

            var entity = await _repo.GetByIdAsNoTrackingAsync(id);

            if (entity is null)
                return Error(HttpStatusCode.NotFound);

            entity.Base64 = photoBase64;

            await _repo.UpdateAsync(entity);
            return Success();
        }

        public async Task<OperationResult> Delete(int id)
        {
            var entity = await _repo.GetByIdAsNoTrackingAsync(id);

            if (entity is null)
                return Error(HttpStatusCode.NotFound);

            var card = await _cardRepo.GetByPhotoIdAsync(id);

            if (card is not null)
                return Error(HttpStatusCode.Conflict);

            await _repo.DeleteAsync(entity);
            return Success();
        }
    }
}
