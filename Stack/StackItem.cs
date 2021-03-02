public class StackItem<T>
{
    public T Data { get; set; }
    public StackItem<T> Previous { get; set; }

    public StackItem(T data)
    {
        Data = data;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}