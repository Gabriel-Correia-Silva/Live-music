using Back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Data;

public class LiveMusicDbContext : DbContext
{
    public LiveMusicDbContext(DbContextOptions<LiveMusicDbContext> options) : base(options)
    {
        
    }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<MusicModel> Musics { get; set; }
    public DbSet<PlaylistModel> Playlists { get; set; }
    public DbSet<GroupModel> Groups { get; set; }   
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");
    }
    
}