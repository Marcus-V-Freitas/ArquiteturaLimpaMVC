using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Aplicacao.Produtos.Commands;
using AutoMapper;

namespace ArquiteturaLimpaMVC.Aplicacao.Mappings
{
    public class DTOParaDominioMappingProfile : Profile
    {
        public DTOParaDominioMappingProfile()
        {
            CreateMap<ProdutoDTO, CriarProdutoCommand>();
            CreateMap<ProdutoDTO, AtualizarProdutoCommand>();
        }
    }
}