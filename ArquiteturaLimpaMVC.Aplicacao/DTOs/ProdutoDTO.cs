using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArquiteturaLimpaMVC.Aplicacao.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MinLength(3, ErrorMessage = "O nome deve ser maior que 3 caracteres!")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória!")]
        [MinLength(5, ErrorMessage = "A descrição deve ser maior que 5 caracteres!")]
        [MaxLength(250, ErrorMessage = "A descrição deve ter no máximo 250 caracteres!")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório!")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor do estoque deve estar entre 1 e 2147483647")]
        [DisplayName("Estoque")]
        public int Estoque { get; set; }

        [MaxLength(250, ErrorMessage = "A Imagem deve ter no máximo 250 caracteres!")]
        [DisplayName("Imagem do Produto")]
        public string Imagem { get; set; }

        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }

        public CategoriaDTO Categoria { get; set; }
    }
}