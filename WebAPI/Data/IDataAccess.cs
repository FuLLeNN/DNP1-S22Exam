using Entities;

namespace WebAPI.Data;

public interface IDataAccess
{
    Task<Album> AddAlbumAsync(Album album);
    Task<ICollection<string>> GetAlbumTitlesAsync();
    Task AddImageToAlbum(Image img, string albumTitle);
    Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic);
}