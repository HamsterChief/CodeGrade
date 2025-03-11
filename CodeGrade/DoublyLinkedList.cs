using System.Collections;

namespace Solution;

public class DoublyLinkedList<T> : IDoublyLinkedList<T> where T : IComparable<T>
{
    public DoubleNode<T>? First, Last;
    public DoublyLinkedList() => First = Last = null;
    public void Clear() => First = Last = null;

    //Search
    public DoubleNode<T>? Search(T value)
    {
        DoubleNode<T>? current = First;

        while (current != null)
        {
            if (current.Value.CompareTo(value) == 0)
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    #region "addNode=> first, last, sorted" 
    public void AddFirst(T value)
    {
        DoubleNode<T> newNode = new DoubleNode<T>(value);
        if (First == null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            newNode.Next = First;
            First.Previous = newNode;
            First = newNode;
        }
    }

    public void AddLast(T value)
    {
        DoubleNode<T> newNode = new DoubleNode<T>(value);

        if (First == null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            Last!.Next = newNode;
            newNode.Previous = Last;
            Last = newNode;
        }
    }

    public void AddSorted(T value)
    {
        DoubleNode<T> newNode = new DoubleNode<T>(value);

        if (First == null || First.Value.CompareTo(value) >= 0)
        {
            newNode.Next = First;
            First!.Previous = newNode;
            First = newNode;
        }

        else
        {
            DoubleNode<T>? current = First;
            while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            newNode.Previous = current;
            current.Next = newNode;
        }
    }
    #endregion

    public bool Remove(T value)
    {
        DoubleNode<T>? current = First;

        while (current != null)
        {
            if (current.Value.CompareTo(value) == 0)
            {
                // Case 1: Removing the First node
                if (current.Previous == null)
                {
                    First = current.Next;
                    if (First != null)
                    {
                        First.Previous = null;
                    }
                    else
                    {
                        Last = null;
                    }
                }
                // Case 2: Removing the Last node
                else if (current.Next == null)
                {
                    Last = current.Previous;
                    Last!.Next = null;
                }
                // Case 3: Removing a middle node
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }

                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void Delete(DoubleNode<T> node)
    {
        // Case 1: The node to delete is the First node
        if (node.Previous == null)
        {
            First = node.Next; // Update First to the next node
            if (First != null)
            {
                First.Previous = null; // Remove the Previous pointer of the new First node
            }
            else
            {
                Last = null; // If the list becomes empty, update Last to null
            }
        }
        // Case 2: The node to delete is the Last node
        else if (node.Next == null)
        {
            Last = node.Previous; // Update Last to the previous node
            Last!.Next = null; // Remove the Next pointer of the new Last node
        }
        // Case 3: The node to delete is in the middle
        else
        {
            node.Previous.Next = node.Next; // Bypass the node to delete
            node.Next.Previous = node.Previous; // Update the Previous pointer of the next node
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        DoubleNode<T>? current = First;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
