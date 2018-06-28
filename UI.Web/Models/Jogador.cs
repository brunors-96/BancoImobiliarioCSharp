using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UI.Web.Models
{
    // Add profile data for application users by adding properties to the Jogador class
    public class Jogador : IdentityUser
    {
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public string Nome { get; set; }

        public IList<JogadorPartida> JogadorPartidas { get; set; }
    }
}
