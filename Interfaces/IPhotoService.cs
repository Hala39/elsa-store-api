using System.Collections.Generic;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ELSAPI.Interfaces
{
    public interface IPhotoService
    {
         Task<ImageUploadResult> AddPhoto(IFormFile file);
         Task<DeletionResult> DeletePhoto(string photoId);
    }
}