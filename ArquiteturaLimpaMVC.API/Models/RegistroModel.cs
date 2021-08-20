using System.ComponentModel.DataAnnotations;

namespace ArquiteturaLimpaMVC.API.Models
{
    public class RegistroModel
    {
        [Required(ErrorMessage = "O email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato Inválido do Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "A {0} deve ter no mínimo {1} e no máximo {2} caracteres!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não conferem!")]
        public string ConfirmarSenha { get; set; }
    }
}