using System;

//runtmeEx fix
public class QueueUnderFlowException : SystemException
{
	public QueueUnderFlowException() : base()
	{
	}

    public QueueUnderFlowException(string message) : base(message)
    {
    }
}
