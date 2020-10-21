using System;
using System.Threading;

namespace Exercise_04_S02
{
    class Program
    {
        static void Main(string[] args)
        {
            var waitingRoom = new WaitingRoom();
            var patient1 = new Patient(waitingRoom);
            var patient2 = new Patient(waitingRoom);
            var patient3 = new Patient(waitingRoom);
            var patient4 = new Patient(waitingRoom);

            waitingRoom.RunWaitingRoom();

        }
    }
}
