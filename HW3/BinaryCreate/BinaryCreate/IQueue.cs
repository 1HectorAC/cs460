using System;

/// <summary>
/// A FIFO queue interface.
/// </summary>
/// <typeparam name="T"></typeparam>
interface IQueue<T>
{

    /// <summary>
    /// Add an element to the rear of the queue.
    /// </summary>
    /// <param name="element"> The value that will be placed into the LinkedQueue. </param>
    /// <returns> The element that was enqueued. </returns>
    T Push(T element);

    /// <summary>
    /// Remove the front element from Queue.
    /// </summary>
    /// <returns> The element that was removed. </returns>
    T Pop();

    /// <summary>
    /// Test if the queue is empty.
    /// </summary>
    /// <returns> True if queue is empty and false otherwise. </returns>
    bool IsEmpty();
}
