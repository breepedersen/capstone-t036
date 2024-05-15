using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IAlbumRepository
    {
        bool AlbumExists(int albumId);
        Album GetAlbum(int albumId);
        ICollection<Album> GetAlbums();
        ICollection<Album> GetAlbumsByClassroom(int classId);
        bool CreateAlbum(Album album);
        bool UpdateAlbum(Album album);
        bool Save();
    }
}
