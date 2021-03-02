public class QueueItem<T>
{
    public T Data { get; set; }
    public QueueItem<T> Next { get; set; }

    public QueueItem(T data)
    {
        Data = data;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}