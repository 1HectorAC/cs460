using System;

/// <summary>
/// A custom unchecked exception to represent situations where an illegal operation was performed on an empty queue.
/// </summary>
public class QueueUnderFlowException : SystemException
{
    /// <summary>
    /// Constructor for QueueFlowException class.
    /// </summary>
	public QueueUnderFlowException() : base()
	{
	}

    /// <summary>
    /// Contructor for QueueFlowException class with message.
    /// </summary>
    /// <param name="message"> A message for user after exception. </param>
    public QueueUnderFlowException(string message) : base(message)
    {
    }
}
