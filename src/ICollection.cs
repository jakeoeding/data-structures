namespace DataStructures
{
    public interface ICollection<T>
    {
        int Count { get; }

        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }
}
