using ArquiteturaLimpaMVC.Dominio.Validacoes;
using System.Collections.Generic;

namespace ArquiteturaLimpaMVC.Dominio.Entidades
{
    public sealed class Categoria: Entity
    {
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            Nome = nome;
            ValidarDominio();
        }

        public Categoria(int id, string nome): 
                    this(nome)
        {
            Id = id;
            ValidacaoDominioException.Validar(id < 0, "Id inválido!");                       
        }       
        
        public void Atualizar(string nome)
        {
            Nome = nome;
            ValidarDominio();
        }

        public ICollection<Produto> Produtos { get; set; }

        protected override void ValidarDominio()
        {
            ValidacaoDominioException.Validar(string.IsNullOrEmpty(Nome), 
                                              "O nome é obrigatório!");

            ValidacaoDominioException.Validar(Nome.Length < 3, 
                                              "O nome deve ser maior que 3 caracteres!");

        }
    }
}
