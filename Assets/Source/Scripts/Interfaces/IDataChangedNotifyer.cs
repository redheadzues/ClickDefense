using System;

public interface IDataChangedNotifyer
{
    event Action DataChanged;
}
