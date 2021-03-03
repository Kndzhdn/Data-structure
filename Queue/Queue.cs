public class Queue<T>
{
    private QueueItem<T> _head;
    private QueueItem<T> _tail;

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public Queue()
    {
    }

    public Queue(T data)
    {
        SetHeadItem(data);
    }

    private void SetHeadItem(T data)
    {
        var item = new QueueItem<T>(data);
        _head = item;
        _tail = item;
        Count = 1;
    }

    public void Enqueue(T data)
    {
        if (IsEmpty)
        {
            SetHeadItem(data);
            return;
        }

        var item = new QueueItem<T>(data)
        {
            Next = _tail
        };
        _tail = item;
        Count++;
    }

    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Очередь пуста.");
        }

        var data = _head.Data;

        var current = _tail.Next;
        var previous = _tail;
        while (current != null && current.Next != null)
        {
            previous = current;
            current = current.Next;
        }

        _head = previous;
        _head.Next = null;
        Count--;
        return data;
    }

    public T Top()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Очередь пуста.");
        }
        return _head.Data;
    }
}
