/// <summary>
/// Singly linked node class.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{
    private T data;

    public Node<T> next;

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    /// <summary>
    /// Singly linked node constructor.
    /// </summary>
    /// <param name="data"> The value this node will hold. </param>
    /// <param name="next"> The link to another node. </param>
    public Node(T data, Node<T> next)
	{
        this.data = data;
        this.next = next;
        
	}
}
