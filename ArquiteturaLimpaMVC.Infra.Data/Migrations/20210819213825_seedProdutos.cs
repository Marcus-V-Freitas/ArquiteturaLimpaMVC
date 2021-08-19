using Microsoft.EntityFrameworkCore.Migrations;

namespace ArquiteturaLimpaMVC.Infra.Data.Migrations
{
    public partial class seedProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,Estoque,Imagem,CategoriaId) " +
           "VALUES('Caderno espiral','Caderno espiral 100 fôlhas',7.45,50,'caderno1.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,Estoque,Imagem,CategoriaId) " +
            "VALUES('Estojo escolar','Estojo escolar cinza',5.65,70,'estojo1.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,Estoque,Imagem,CategoriaId) " +
            "VALUES('Borracha escolar','Borracha branca pequena',3.25,80,'borracha1.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,Estoque,Imagem,CategoriaId) " +
            "VALUES('Calculadora escolar','Calculadora simples',15.39,20,'calculadora1.jpg',2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
