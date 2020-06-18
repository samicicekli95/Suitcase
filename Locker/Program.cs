using Locker.Classes;
using Locker.Enums;
using Locker.Interfaces;
using System;

namespace Locker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Suitcase Locker
            IDigitalLock mySuitcaseLocker = new SuitcaseLocker();
            // Passcode Finder
            IPickLock maymuncuk = new MasterKey();
            //maymuncuk.Unlock()


            mySuitcaseLocker.Reset();
            mySuitcaseLocker.Turn(TurnDirection.Forward, 0, 1);
            mySuitcaseLocker.Turn(TurnDirection.Forward, 1, 2);
            mySuitcaseLocker.Turn(TurnDirection.Backward, 2, 27);
            mySuitcaseLocker.Turn(TurnDirection.Backward, 3, 55);
            mySuitcaseLocker.Lock(false);
            Console.WriteLine(mySuitcaseLocker.ReadAll());

            //Console.ReadLine();
        }
    }
}
