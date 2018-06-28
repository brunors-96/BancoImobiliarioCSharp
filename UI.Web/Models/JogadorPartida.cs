using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Web.Models
{
    public class JogadorPartida
    {
        public string JogadorId { get; set; }
        public Jogador Jogador { get; set; }

        public long PartidaId { get; set; }
        public Partida Partida { get; set; }

        public int PinoId { get; set; }
        public Pino Pino { get; set; }
    }
}
