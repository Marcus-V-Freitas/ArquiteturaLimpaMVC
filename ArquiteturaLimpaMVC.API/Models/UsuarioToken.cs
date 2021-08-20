using System;

namespace ArquiteturaLimpaMVC.API.Models
{
    public class UsuarioToken
    {
        public string Token { get; set; }
        public DateTime Expiracao { get; set; }
    }
}