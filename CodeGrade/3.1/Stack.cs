using System.Diagnostics.Contracts;

namespace Solution;

public class Stack<T> : IStack<T>
{
    public Stack<T> stack;
    public bool Empty => Count == 0;

    public bool Full => Count == Size;

    public int Count => stack.Count;

    public int Size { get; }

    public Stack(int size = 4)
    {
        Size = size;
        stack = new Stack<T>();
    }

    public T? Peek()
    {
        if (Empty) { return default; }
        return stack.Peek();
    }

    public T? Pop()
    {
        if (Empty) { return default; }
        return stack.Pop();
    }

    public void Push(T Item)
    {
        if (Full) { return; }
        stack.Push(Item);
    }
}
