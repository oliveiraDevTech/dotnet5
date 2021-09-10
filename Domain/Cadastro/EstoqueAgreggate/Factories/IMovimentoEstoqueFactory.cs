namespace Domain.Cadastro.EstoqueAgreggate.Factories
{
    public interface IMovimentoEstoqueFactory
    {
        MovimentoEstoque Criar(double quantidadeAntiga, double quantidadeNova, bool perda = false);
    }
}