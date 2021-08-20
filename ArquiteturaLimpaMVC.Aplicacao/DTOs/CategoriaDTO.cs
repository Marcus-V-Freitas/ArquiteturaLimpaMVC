using System.ComponentModel.DataAnnotations;

namespace ArquiteturaLimpaMVC.Aplicacao.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MinLength(3, ErrorMessage = "O nome deve ser maior que 3 caracteres!")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
        public string Nome { get; set; }
    }
}