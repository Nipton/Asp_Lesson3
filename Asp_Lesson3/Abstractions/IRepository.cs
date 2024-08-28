namespace Asp_Lesson3.Abstractions
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        int Create(T item);

        T? GetById(int id);
    }
}
