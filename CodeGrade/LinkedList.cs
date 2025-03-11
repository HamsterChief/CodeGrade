using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Solution;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int count;

    public SinglyLinkedList()
    {
        Head = null;
        count = 0;
    }

    public int Count => count;

    public void AddFirst(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value);
        newNode.Next = Head;
        Head = newNode;
        count++;
    }

    public void AddLast(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            SingleNode<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }

    public bool Remove(T value)
    {
        SingleNode<T>? current = Head;
        SingleNode<T>? previous = null;

        // Traverse the list to find the node to remove
        while (current != null)
        {
            if (current.Value.CompareTo(value) == 0) // Check if current node's data matches the value
            {
                if (previous == null) // If the node to remove is the Head
                {
                    Head = current.Next; // Update Head to the next node
                }
                else // If the node to remove is not the Head
                {
                    previous.Next = current.Next; // Bypass the current node
                }

                count--; // Decrement the count of nodes
                return true; // Return true to indicate successful removal
            }

            // Move to the next node
            previous = current;
            current = current.Next;
        }

        return false; // Return false if the value was not found
    }

    public SingleNode<T>? Search(T value)
    {
        SingleNode<T>? current = Head;
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

    public bool Contains(T value) => Search(value) != null;

    public void AddSorted(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value);

        if (Head == null || Head.Value.CompareTo(value) >= 0)
        {
            newNode.Next = Head;
            Head = newNode;
        }
        else
        {
            SingleNode<T> current = Head;
            while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        count++;
    }

    public void Clear()
    {
        Head = null;
        count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SingleNode<T>? current = Head;
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

