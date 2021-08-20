using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Validacoes;
using FluentAssertions;
using System;
using Xunit;

namespace ArquiteturaLimpaMVC.Dominio.Testes
{
    public class TesteUnidadeCategoria
    {
        [Fact(DisplayName = "CriarCategoriaValida")]
        public void CriarCategoriaValida()
        {
            Action acao = () => new Categoria(1, "Motos");
            acao.Should()
                .NotThrow<ValidacaoDominioException>();
        }

        [Fact(DisplayName = "CriarCategoriaInvalidaIdNegativo")]
        public void CriarCategoriaInvalidaIdNegativo()
        {
            Action acao = () => new Categoria(-1, "Motos");
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("Id inválido!");
        }

        [Fact(DisplayName = "CriarCategoriaInvalidaNomePequeno")]
        public void CriarCategoriaInvalidaNomePequeno()
        {
            Action acao = () => new Categoria(-1, "Mo");
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("O nome deve ser maior que 3 caracteres!");
        }

        [Fact(DisplayName = "CriarCategoriaInvalidaNomeNulo")]
        public void CriarCategoriaInvalidaNomeNulo()
        {
            Action acao = () => new Categoria(-1, null);
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("O nome é obrigatório!");
        }

        [Fact(DisplayName = "CriarCategoriaInvalidaNomeVazio")]
        public void CriarCategoriaInvalidaNomeVazio()
        {
            Action acao = () => new Categoria(-1, string.Empty);
            acao.Should()
                .Throw<ValidacaoDominioException>()
                .WithMessage("O nome é obrigatório!");
        }
    }
}