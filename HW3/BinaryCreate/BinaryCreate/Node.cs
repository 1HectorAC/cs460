/// <summary>
/// Singly linked node class
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{
    public T data;
    public Node<T> next;

    /// <summary>
    /// Singly linked node constructor
    /// </summary>
    /// <param name="data"></param>
    /// <param name="next"></param>
    public Node(T data, Node<T> next)
	{
        this.data = data;
        this.next = next;
        
	}
}
