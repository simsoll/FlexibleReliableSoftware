namespace PayStation.Observer
{
    public interface IObserver<T>
    {
        void Update(T state);
    }
}