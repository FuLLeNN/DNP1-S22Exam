using System.Collections;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebAPI.Data;

public class AlbumContext : DbContext, IDataAccess
{
    
    public DbSet<Album> albums { get; set; }
    public DbSet<Image> images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../WebAPI/album.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>().HasKey(album => album.title);
        modelBuilder.Entity<Image>().HasKey(image => image.id);
    }
    
    public async Task<Album> AddAlbumAsync(Album album)
    {
        Album tocreate = new Album()
        {
            title = album.title,
            description = album.description,
            createdBy = album.createdBy,
        };

        EntityEntry<Album> newAlbum = await albums.AddAsync(tocreate);
        await SaveChangesAsync();
        return newAlbum.Entity;
    }

    public async Task<ICollection<string>> GetAlbumTitlesAsync()
    {
        return await albums.Select(a => a.title).ToListAsync();
    }

    public async Task AddImageToAlbum(Image img, string albumTitle)
    {

        Album album = await albums.FirstOrDefaultAsync(a => a.title == albumTitle);
        
        Image toCreate = new Image()
        {
            title = img.title,
            description = img.description,
            topic = img.topic,
            url = img.url,
            album_title = album.title
        };

        await images.AddAsync(toCreate);
        await SaveChangesAsync();
    }

    public async Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic)
    {
        if (albumCreator != null && topic != null)
        { 
            return await images.Join(albums, i => i.album_title, a => a.title, (i, a) => new { Image = i, Album = a })
                .Where(i => i.Image.topic == topic && i.Album.createdBy == albumCreator).Select(i => i.Image).ToListAsync();
        }

        if (albumCreator != null && topic == null)
            return await images.Join(albums, i => i.album_title, a => a.title, (i, a) => new { Image = i, Album = a })
                .Where(i => i.Album.createdBy == albumCreator).Select(i => i.Image).ToListAsync();

        if (albumCreator == null && topic != null)
            return await images.Where(i => i.topic == topic).ToListAsync();

        if (albumCreator == null && topic == null)
            return await images.ToListAsync();
        
        return null;
    }
}