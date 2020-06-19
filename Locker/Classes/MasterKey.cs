using Locker.Enums;
using Locker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locker.Classes
{
    class MasterKey : IPickLock
    {
        public string Unlock(IDigitalLock digitalLock)
        {
            string value = "Can't unlock it! :(";
            int keyOptionNumber = 0;
            char firstChar = digitalLock.Read(0);
            do
            {
                keyOptionNumber = keyOptionNumber + 1;
                digitalLock.Turn(TurnDirection.Forward, 0, 1);
            } while (firstChar != digitalLock.Read(0));




            digitalLock.Reset();
            while (digitalLock.IsLocked())
            {
                for (int i0 = 0; i0 < keyOptionNumber; i0++)
                {
                    for (int i1 = 0; i1 < keyOptionNumber; i1++)
                    {
                        for (int i2 = 0; i2 < keyOptionNumber; i2++)
                        {
                            for (int i3 = 0; i3 < keyOptionNumber; i3++)
                            {
                                digitalLock.Lock(false);

                                if (digitalLock.IsLocked())
                                {
                                    digitalLock.Turn(TurnDirection.Forward, 3, 1);
                                }
                                else
                                {
                                    value = "The Password is \"" + digitalLock.ReadAll() + "\"";
                                    break;
                                }
                            }

                            if (digitalLock.IsLocked())
                            {
                                digitalLock.Turn(TurnDirection.Forward, 2, 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (digitalLock.IsLocked())
                        {
                            digitalLock.Turn(TurnDirection.Forward, 1, 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (digitalLock.IsLocked())
                    {
                        digitalLock.Turn(TurnDirection.Forward, 0, 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return value;
        }
    }
}
