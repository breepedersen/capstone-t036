using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Repository
{
    public class PictureRepository : IPictureRepository
    {
        private DataContext _context;

        public PictureRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePicture(Picture picture)
        {
            _context.Add(picture);
            return Save();
        }

        public Picture GetPicture(int picId)
        {
            return _context.Pictures.Where(p => p.PictureId == picId).FirstOrDefault();
        }

        public ICollection<Picture> GetPictures()
        {
            return _context.Pictures.OrderBy(p => p.PictureId).ToList();
        }

        public ICollection<Picture> GetPicturesByAlbum(int albumId)
        {
            return _context.Pictures.Where(p => p.Album.AlbumId == albumId).ToList();
        }

        public ICollection<Picture> GetPicturesByPost(int postId)
        {
            return _context.Pictures.Where(p => p.Post.PostId == postId).ToList();
        }

        public bool PictureExists(int picId)
        {
            return _context.Pictures.Any(p => p.PictureId == picId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePicture(Picture picture)
        {
            _context.Update(picture);
            return Save();
        }
    }
}
