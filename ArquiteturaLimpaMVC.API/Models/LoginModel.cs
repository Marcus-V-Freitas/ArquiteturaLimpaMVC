using System.ComponentModel.DataAnnotations;

namespace ArquiteturaLimpaMVC.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato Inválido do Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "A {0} deve ter no mínimo {1} e no máximo {2} caracteres!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public string UrlRetorno { get; set; }
    }
}