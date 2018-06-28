using System;

namespace UI.Web.Models
{
    public class Partida
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(255, MinimumLength = 2)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Nome { get; set; }

        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public DateTime Data { get; set; }

        public int? Status { get; set; }

        public System.Collections.Generic.IList<JogadorPartida> JogadorPartidas { get; set; }
    }
}
