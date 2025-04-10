namespace Solution;

public class Queue<T> : IQueue<T>
{
    private int front;
    private int back;
    private T[] data;
    private int _count = 0;

    public bool Empty => _count == 0;
    public bool Full => _count == data.Length;
    public int Count => _count;
    public int Size => data.Length;

    public Queue(int capacity = 5)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be positive", nameof(capacity));
        
        data = new T[capacity];
        front = 0;
        back = -1;
        _count = 0;
    }

    public void Enqueue(T element)
    {
        if (Full)
            throw new InvalidOperationException("Queue is full");
        
        back = (back + 1) % data.Length;
        data[back] = element;
        _count++;
    }

    public T? Dequeue()
    {
        if (Empty)
            return default(T);
        
        T item = data[front];
        front = (front + 1) % data.Length;
        _count--;
        return item;
    }
}