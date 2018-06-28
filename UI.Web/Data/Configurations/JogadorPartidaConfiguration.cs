using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Web.Models;

namespace UI.Web.Data.Configurations
{
    public class JogadorPartidaConfiguration : IEntityTypeConfiguration<Models.JogadorPartida>
    {
        public void Configure(EntityTypeBuilder<JogadorPartida> builder)
        {
            builder
                .HasKey(jp => new { jp.JogadorId, jp.PartidaId, jp.PinoId });

            builder
                .HasOne(sc => sc.Jogador)
                .WithMany(s => s.JogadorPartidas)
                .HasForeignKey(sc => sc.JogadorId);

            builder
                .HasOne(sc => sc.Partida)
                .WithMany(s => s.JogadorPartidas)
                .HasForeignKey(sc => sc.PartidaId);

            builder
                .HasOne(sc => sc.Pino)
                .WithMany(s => s.JogadorPartidas)
                .HasForeignKey(sc => sc.PinoId);
        }
    }
}
