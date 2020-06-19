using Locker.Classes;
using Locker.Enums;
using Locker.Interfaces;
using System;
using System.Threading.Tasks;

namespace Locker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Suitcase Locker
            IDigitalLock mySuitcaseLocker = new SuitcaseLocker();
            // Passcode Finder
            IPickLock myLittleMonkey = new MasterKey();
            //maymuncuk.Unlock()


            mySuitcaseLocker.Reset();
            mySuitcaseLocker.Turn(TurnDirection.Forward, 0, 18);
            mySuitcaseLocker.Turn(TurnDirection.Forward, 1, 0);
            mySuitcaseLocker.Turn(TurnDirection.Forward, 2, 12);
            mySuitcaseLocker.Turn(TurnDirection.Forward, 3, 8);
            mySuitcaseLocker.Turn(TurnDirection.Forward, 4, 3);     // When you try to Turn non exist digits
            Console.WriteLine(mySuitcaseLocker.ReadAll());
            Console.WriteLine(mySuitcaseLocker.IsLocked());
            mySuitcaseLocker.Lock(true);
            Console.WriteLine(mySuitcaseLocker.ReadAll());
            Console.WriteLine(mySuitcaseLocker.IsLocked());


            string key = "?";
            key = myLittleMonkey.Unlock(mySuitcaseLocker);
            Console.WriteLine(key);

            //Console.ReadLine();
        }
    }
}
