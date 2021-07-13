using Core.Domain.Enumerator;
using Domain.Cadastro.ProdutoAggregate.ValueObject;

namespace Domain.Cadastro.ProdutoAggregate.Factory
{
    public class ImpostoFactory : IImpostoFactory
    {
        public Imposto Criar(Estado estado)
        {
            switch (estado)
            {
                case Estado.AC:
                    return new Imposto();

                case Estado.AL:
                    break;

                case Estado.AP:
                    break;

                case Estado.AM:
                    break;

                case Estado.BA:
                    break;

                case Estado.CE:
                    break;

                case Estado.DF:
                    break;

                case Estado.ES:
                    break;

                case Estado.GO:
                    break;

                case Estado.MA:
                    break;

                case Estado.MT:
                    break;

                case Estado.MS:
                    break;

                case Estado.MG:
                    break;

                case Estado.PA:
                    break;

                case Estado.PB:
                    break;

                case Estado.PR:
                    break;

                case Estado.PE:
                    break;

                case Estado.PI:
                    break;

                case Estado.RJ:
                    break;

                case Estado.RN:
                    break;

                case Estado.RS:
                    break;

                case Estado.RO:
                    break;

                case Estado.RR:
                    break;

                case Estado.SC:
                    break;

                case Estado.SP:
                    break;

                case Estado.SE:
                    break;

                case Estado.TO:
                    break;
            }
            return new Imposto();
        }
    }
}