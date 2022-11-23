using ChallengeAlura.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Tls;

namespace ChallengeAlura.Data {
    public class VideoDbContext : DbContext{

        public VideoDbContext(DbContextOptions<VideoDbContext> opt) : base(opt){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Video>()
                .HasOne(video => video.Categoria)
                .WithMany(categoria => categoria.Videos)
                .HasForeignKey(video => video.CategoriaId);
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
