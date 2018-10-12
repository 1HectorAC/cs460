using System;

/// <summary>
/// A custom unchecked exception to represent situations where an illegal operation was performed on an empty queue.
/// </summary>
public class QueueUnderFlowException : SystemException
{
    /// <summary>
    /// Constructor
    /// </summary>
	public QueueUnderFlowException() : base()
	{
	}

    /// <summary>
    /// Contructor with message
    /// </summary>
    /// <param name="message"></param>
    public QueueUnderFlowException(string message) : base(message)
    {
    }
}
