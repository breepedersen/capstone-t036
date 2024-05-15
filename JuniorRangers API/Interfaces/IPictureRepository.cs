using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IPictureRepository
    {
        bool PictureExists(int picId);
        ICollection<Picture> GetPictures();
        Picture GetPicture(int picId);
        ICollection<Picture> GetPicturesByAlbum(int albumId);
        ICollection<Picture> GetPicturesByPost(int postId);
        bool CreatePicture(Picture picture);
        bool UpdatePicture(Picture picture);
        bool Save();
    }
}
