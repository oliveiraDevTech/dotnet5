using Application.Cadastro.Dto;
using AutoMapper;
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EnderecoAggregate;
using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.FornecedorAgreggate;
using Domain.Cadastro.ProdutoAggregate;

namespace Application.AutoMapper.Mappers
{
    public class CadastroDomainToDtoMapping : Profile
    {
        public CadastroDomainToDtoMapping()
        {
            CreateMap<Empresa, EmpresaDto>()
                .ForMember(cfg => cfg.Cnpj, (map) => map.MapFrom(o => o.Cnpj.Codigo))
                .ForMember(cfg => cfg.Endereco, (map) => map.MapFrom(o => o.Endereco))
                .ForMember(cfg => cfg.NomeEmpresa, (map) => map.MapFrom(o => o.Nome))
                .ForMember(cfg => cfg.TipoEmpresa, (map) => map.MapFrom(o => o.Tipo.ToString()));

            CreateMap<Endereco, EnderecoDto>()
                .ForMember(cfg => cfg.Pais, (map) => map.MapFrom(o => o.Pais))
                .ForMember(cfg => cfg.Estado, (map) => map.MapFrom(o => o.Estado))
                .ForMember(cfg => cfg.Cidade, (map) => map.MapFrom(o => o.Cidade))
                .ForMember(cfg => cfg.Bairro, (map) => map.MapFrom(o => o.Bairro))
                .ForMember(cfg => cfg.Rua, (map) => map.MapFrom(o => o.Rua))
                .ForMember(cfg => cfg.Referencia, (map) => map.MapFrom(o => o.Referencia))
                .ForMember(cfg => cfg.Complemento, (map) => map.MapFrom(o => o.Complemento));

            CreateMap<Produto, ProdutoDto>()
                .ForMember(cfg => cfg.Nome, (map) => map.MapFrom(o => o.Nome))
                .ForMember(cfg => cfg.Codigo, (map) => map.MapFrom(o => o.Codigo))
                .ForMember(cfg => cfg.Tipo, (map) => map.MapFrom(o => o.Tipo))
                .ForMember(cfg => cfg.Descricao, (map) => map.MapFrom(o => o.Descricao))
                .ForMember(cfg => cfg.Peso, (map) => map.MapFrom(o => o.Peso.Valor))
                .ForMember(cfg => cfg.Medida, (map) => map.MapFrom(o => o.Medida))
                .ForMember(cfg => cfg.Preco, (map) => map.MapFrom(o => o.Preco.Valor))
                .ForMember(cfg => cfg.Imposto, (map) => map.MapFrom(o => o.Preco.Imposto));

            CreateMap<Fornecedor, FornecedorDto>()
                .ForMember(cfg => cfg.Empresa, (map) => map.MapFrom(o => o.Empresa))
                .ForMember(cfg => cfg.Produtos, (map) => map.MapFrom(o => o.Produtos));

            CreateMap<Estoque, EstoqueDto>()
                .ForMember(cfg => cfg.Quantidade, (map) => map.MapFrom(o => o.Quantidade))
                .ForMember(cfg => cfg.Produto, (map) => map.MapFrom(o => o.Produto))
                .ForMember(cfg => cfg.Fornecedor, (map) => map.MapFrom(o => o.Fornecedor))
                .ForMember(cfg => cfg.Movimentos, (map) => map.MapFrom(o => o.Movimentos))
                .ForMember(cfg => cfg.Fabricacao, (map) => map.MapFrom(o => o.Fabricacao))
                .ForMember(cfg => cfg.Vencimento, (map) => map.MapFrom(o => o.Vencimento));

            CreateMap<MovimentoEstoque, MovimentoEstoqueDto>()
                .ForMember(cfg => cfg.Tipo, (map) => map.MapFrom(o => o.Tipo))
                .ForMember(cfg => cfg.Lancamento, (map) => map.MapFrom(o => o.Lancamento));
        }
    }
}