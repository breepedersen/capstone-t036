using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IPictureRepository
    {
        bool PictureExists(int picId);
        Picture GetPicture(int picId);
        ICollection<Picture> GetPicturesByAlbum(int albumId);
        ICollection<Picture> GetPicturesByPost(int postId);
    }
}
