using Locker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locker.Classes
{
    class MasterKey : IPickLock
    {
        public string Unlock(IDigitalLock digitalLock)
        {
            throw new NotImplementedException();
        }
    }
}
