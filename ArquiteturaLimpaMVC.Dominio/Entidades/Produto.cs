using ArquiteturaLimpaMVC.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Dominio.Entidades
{
    public sealed class Produto:Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private  set; }
        public string Imagem { get; private  set; }      

        public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Imagem = imagem;
            ValidarDominio();
        }

        public Produto(int id, string nome, string descricao, decimal preco, int estoque, string imagem) : 
                 this (nome,descricao,preco,estoque,imagem)
        {                       
            Id = id;
            ValidacaoDominioException.Validar(id < 0, "Id inválido!");
        }

        public void Atualizar(string nome, string descricao, decimal preco, int estoque, string imagem)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Imagem = imagem;
            ValidarDominio();
        }

        protected override void ValidarDominio()
        {            
            ValidacaoDominioException.Validar(string.IsNullOrEmpty(Nome),
                                             "O nome é obrigatório!");

            ValidacaoDominioException.Validar(Nome.Length < 3,
                                              "O nome deve ser maior que 3 caracteres!");

            ValidacaoDominioException.Validar(string.IsNullOrEmpty(Descricao),
                                            "A descrição é obrigatório!");

            ValidacaoDominioException.Validar(Descricao.Length < 5,
                                            "A descrição deve ser maior que 3 caracteres!");

            ValidacaoDominioException.Validar(Preco < 0, "O valor do preço é inválido!");

            ValidacaoDominioException.Validar(Estoque < 0, "O valor do estoque é inválido!");

            ValidacaoDominioException.Validar(string.IsNullOrEmpty(Imagem), "A imagem deve é obrigatória!");

            ValidacaoDominioException.Validar(Imagem.Length > 250, "A imagem deve ser menor que 250 caracteres!");

              
        }

        public int CategoriaId { get;  set; }
        public Categoria Categoria { get; set; }
    }
}
