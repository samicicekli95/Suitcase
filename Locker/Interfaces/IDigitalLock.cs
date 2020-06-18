using Locker.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locker.Interfaces
{
    public interface IDigitalLock
    {
        int GetCipherLength();
        bool Turn(TurnDirection direction, int circleIndex, int step);
        string ReadAll();
        char Read(int circleIndex);
        bool Lock(bool garbleAfterLock);
        bool IsLocked();
        bool Reset();
    }
}
