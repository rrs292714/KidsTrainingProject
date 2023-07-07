namespace KidsGaming.Interface
{
    public interface IGeneric<T>
    {
        List<T> getall();

        List<T> getbyId(int id);

        List<T> Insert(T item);

        List<T> delete(int id);
    }
}
