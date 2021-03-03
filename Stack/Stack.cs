public class Stack<T>
{ 
    public StackItem<T> Head { get; set; }
    public int Count { get; set; }

    public bool IsEmpty => Count == 0;

    public Stack()
    {
        Head = null;
        Count = 0;
    }

    public Stack(T data)
    {
        Head = new StackItem<T>(data);
        Count = 1;
    }

    public void Push(T data)
    {
        var item = new StackItem<T>(data);
        item.Previous = Head;
        Head = item;
        Count++;
    }

    public T Pop()
    {
        if (!IsEmpty)
        {
            var item = Head;
            Head = Head.Previous;
            Count--;
            return item.Data;
        }
        else
        {
            throw new NullReferenceException("Стек пуст.");
        }

    }

    public T Top()
    {
        if (!IsEmpty)
        {
            return Head.Data;
        }
        else
        {
            throw new NullReferenceException("Стек пуст.");
        }

    }
}
