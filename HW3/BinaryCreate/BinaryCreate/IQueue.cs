using System;

interface IQueue<T>
{
    T Push(T element);

    //need exception
    T Pop();

    bool IsEmpty();
}
