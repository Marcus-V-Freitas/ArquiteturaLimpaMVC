using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Dominio.Entidades;
using AutoMapper;

namespace ArquiteturaLimpaMVC.Aplicacao.Mappings
{
    public class DominioParaDTOMappingProfile : Profile
    {
        public DominioParaDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}