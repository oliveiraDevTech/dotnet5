namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();

        void RollbackBack();
    }
}