namespace IELCadastroEstudante.Core.Services.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity FindById(int id);
    }
}
