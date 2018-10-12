using System;

/// <summary>
/// A Singly Linked FIFO Queue.
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedQueue<T> : IQueue<T>
{

    private Node<T> front;
    private Node<T> rear;

    /// <summary>
    /// Constructor
    /// </summary>
	public LinkedQueue()
	{
        front = null;
        rear = null;
	}

    /// <summary>
    /// Add an element to the rear of the queue
    /// </summary>
    /// <param name="element"></param>
    /// <returns>The element that was enqueued</returns>
    public T Push(T element)
    {
        if(element == null)
        {
            throw new NullReferenceException();
        }
        if (IsEmpty())
        {
            Node<T> tmp = new Node<T>(element, null);
            rear = front = tmp;
        }
        else
        {
            Node<T> tmp = new Node<T>(element, null);
            rear.next = tmp;
            rear = tmp;

        }
        return element;
    }

    /// <summary>
    /// Remove the front element from Queue.
    /// </summary>
    /// <returns>The element that was removed </returns>
    public T Pop()
    {
        //default istead of null
        T tmp = default(T);
        if (IsEmpty())
        {
            throw new QueueUnderFlowException("The queue was empty when pop was invoked");
        }
        else if(front == rear)
        {
            //one item in queue
            tmp = front.Data;
            front = null;
            rear = null;
        }
        else
        {
            //general case
            tmp = front.Data;
            front = front.next;
        }
        return tmp;
    }

    /// <summary>
    /// Test if the queue is empty
    /// </summary>
    /// <returns>True if queue is empty and false otherwise</returns>
    public bool IsEmpty()
    {
        if(front == null && rear == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
