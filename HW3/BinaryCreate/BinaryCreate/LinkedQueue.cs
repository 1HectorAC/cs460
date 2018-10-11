using System;

public class LinkedQueue<T> : IQueue<T>
{
    //make nullable?
    private Node<T> front;
    private Node<T> rear;

	public LinkedQueue()
	{
        front = null;
        rear = null;
	}
    public T Push(T element)
    {
        if(element = null)
        {

        }


        return tmp;
    }
    public T Pop()
    {
        T tmp = null;

        return tmp;
       
    }
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
