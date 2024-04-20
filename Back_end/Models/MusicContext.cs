namespace Back_end.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class MusicContext : DbContext
    {
        public DbSet<MusicModel> Musics { get; set; }

        public MusicContext(DbContextOptions<MusicContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui você pode configurar o modelo de banco de dados, como chaves primárias, índices, etc.
            // Por exemplo:
            // modelBuilder.Entity<Music>().HasKey(m => m.Id);
        }
    }

}
