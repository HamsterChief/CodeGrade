
//-----This file HAS to be modified----

public class SimpleStack<T>
{
    protected T?[] arr;
    protected int top;
    public int Capacity { get; protected set; }
    
    public SimpleStack()
    {
        Capacity = 4;
        arr = new T[Capacity];
        top = -1;
    }
    
    public bool IsEmpty()
    {
        return top == -1;
    }
    
    public virtual void Push(T item)
    {
        if (top == Capacity - 1)
        {
            return;
        }
        arr[++top] = item;
    }
    
    public virtual T? Peek()
    {
        if (IsEmpty())
            return default(T);
        return arr[top];
    }
    
    public virtual T? Pop()
    {
        if (IsEmpty())
            return default(T);
        T? temp = arr[top];
        arr[top] = default(T);
        top--;
        return temp;
    }
}
// Push:
//     If the Stack is full (value of top is equal to Capacity - 1), the method Push creates an array of double the size of the inner array (Capacity is also doubled).
//     The old array is copied to the new array (which then becomes the Stack inner array),
//     the element to be pushed is written in the first available position of the inner array (after the previous elements), here the value of the top has to be modified.

//     Pop and Peek:
//     method Pop and Peek generate a StackEmptyException when the methods are called on an empty Stack.                                