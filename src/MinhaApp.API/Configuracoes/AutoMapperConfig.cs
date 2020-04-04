using AutoMapper;
using MinhaApp.API.ViewModels;
using MinhaApp.Negocios.Entidades;

namespace MinhaApp.API.Configuracoes
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
