using System;
using System.Collections.Generic;
using System.Text;

namespace Locker.Interfaces
{
    public interface IPickLock
    {
        string Unlock(IDigitalLock digitalLock);
    }
}
