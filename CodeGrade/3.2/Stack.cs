public class Stack<T> : SimpleStack<T>
{
    public override void Push(T item)
    {
        if (top == Capacity - 1)
        {
            // Double the capacity
            int newCapacity = Capacity * 2;
            T?[] newArr = new T[newCapacity];
            
            // Copy old array to new array
            for (int i = 0; i < Capacity; i++)
            {
                newArr[i] = arr[i];
            }
            
            // Update references
            arr = newArr;
            Capacity = newCapacity;
        }
        
        arr[++top] = item;
    }
    
    public override T Peek()
    {
        if (IsEmpty())
            throw new StackEmptyException("The Stack is empty.");
        return arr[top]!;
    }
    
    public override T Pop()
    {
        if (IsEmpty())
            throw new StackEmptyException("The Stack is empty.");
        T temp = arr[top]!;
        arr[top] = default(T);
        top--;
        return temp;
    }
}