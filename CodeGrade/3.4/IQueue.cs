// Queue Data Structure

// A Queue data structure can be define as a collection with Enqueue, and Dequeue methods.IQueue<T> is a generic interface for a standard Queue

// public interface IQueue<T>{
//   void Enqueue(T Item);
//   T? Dequeue();

//   bool Empty { get; }
//   bool Full { get; }
//   int Count { get; }
//   int Size { get; }
// }

//     Implement the interface methods using Array now and Later maybe using linked list

public interface IQueue<T>{
  void Enqueue(T Item);
  T? Dequeue();

  bool Empty { get; }
  bool Full { get; }
  int Count { get; }  
  int Size { get; }  
}