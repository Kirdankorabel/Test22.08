public interface IStateSaver<T>
{
    public T UpdateState();
    public void LoadState(T info);
}