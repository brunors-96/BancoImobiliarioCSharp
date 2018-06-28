namespace UI.Web.Models
{
    public class Pino
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(50, MinimumLength = 2)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Descricao { get; set; }


        public System.Collections.Generic.IList<JogadorPartida> JogadorPartidas { get; set; }
    }
}