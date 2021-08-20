using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Validacoes;
using FluentAssertions;
using System;
using Xunit;

namespace ArquiteturaLimpaMVC.Dominio.Testes
{
    public class TesteUnidadeProduto
    {
        [Fact(DisplayName = "CriarProdutoValido")]
        public void CriarProdutoValido()
        {
            Action acao = () => new Produto(1, "Argo", "Carro novo", 9.99m, 99, "Imagem Produto");
            acao.Should()
                .NotThrow<ValidacaoDominioException>();
        }

        [Fact(DisplayName = "CriarProdutoInvalidoIdNegativo")]
        public void CriarProdutoInvalidoIdNegativo()
        {
            Action acao = () => new Produto(-1, "Argo", "Carro novo", 9.99m, 99, "Imagem Produto");
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("Id inválido!");
        }

        [Fact(DisplayName = "CriarProdutoInvalidoNomePequeno")]
        public void CriarProdutoInvalidoNomePequeno()
        {
            Action acao = () => new Produto(1, "Ar", "Carro novo", 9.99m, 99, "Imagem Produto");
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("O nome deve ser maior que 3 caracteres!");
        }

        [Fact(DisplayName = "CriarProdutoInvalidoImagemGrande")]
        public void CriarProdutoInvalidoImagemGrande()
        {
            Action acao = () => new Produto(1, "Argo", "Carro novo", 9.99m, 99, "Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto Imagem Produto ");
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("A imagem deve ser menor que 250 caracteres!");
        }

        [Fact(DisplayName = "CriarProdutoInvalidoImagemNula")]
        public void CriarProdutoInvalidoImagemNula()
        {
            Action acao = () => new Produto(1, "Argo", "Carro novo", 9.99m, 99, null);
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("A imagem deve é obrigatória!");
        }

        [Fact(DisplayName = "CriarProdutoInvalidoPrecoNegativo")]
        public void CriarProdutoInvalidoPrecoNegativo()
        {
            Action acao = () => new Produto(1, "Argo", "Carro novo", -99m, 99, null);
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("O valor do preço é inválido!");
        }

        [Theory(DisplayName = "CriarProdutoInvalidoEstoqueNegativo")]
        [InlineData(-1)]
        public void CriarProdutoInvalidoEstoqueNegativo(int value)
        {
            Action acao = () => new Produto(1, "Argo", "Carro novo", 9.99m, value, "Imagem Produto");
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("O valor do estoque é inválido!");
        }
    }
}