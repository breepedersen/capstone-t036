using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private DataContext _context;

        public AlbumRepository(DataContext context)
        {
            _context = context;
        }

        public bool AlbumExists(int albumId)
        {
            return _context.Albums.Any(a => a.AlbumId == albumId);
        }

        public bool CreateAlbum(Album album)
        {
            _context.Add(album);
            return Save();
        }

        public Album GetAlbum(int albumId)
        {
            return _context.Albums.Where(a => a.AlbumId == albumId).FirstOrDefault();
        }

        public ICollection<Album> GetAlbums()
        {
            return _context.Albums.OrderBy(a => a.AlbumId).ToList();
        }

        public ICollection<Album> GetAlbumsByClassroom(int classId)
        {
            return _context.Albums.Where(a => a.Classroom.ClassId == classId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAlbum(Album album)
        {
            _context.Update(album);
            return Save();
        }
    }
}
