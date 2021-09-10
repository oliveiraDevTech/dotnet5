using AutoMapper;

namespace Application.Test.Cadastro.Dto
{
    public class EmpresaDtoMapTest
    {
        private readonly IMapper _mapper;

        public EmpresaDtoMapTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[Fact]
        //public void dadsasa()
        //{
        //    var _empresa = new EmpresaBuilder().Build();

        //    var empresaDto = _mapper.Map<Empresa, EmpresaDto>(_empresa);

        //    Assert.Equal(_empresa.RazaoSocial, empresaDto.RazaoSocial);
        //    Assert.Equal(_empresa.Cnpj.Codigo, empresaDto.Cnpj);
        //    Assert.Equal(_empresa.Nome, empresaDto.NomeEmpresa);
        //    Assert.Equal(_empresa.Tipo.ToString(), empresaDto.TipoEmpresa);
        //}
    }
}