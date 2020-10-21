using System;
using System.Threading;

namespace Exercise_04_S02
{
    public class WaitingRoom : EventArgs
    {
        private int CurrentNumber{ get; set; }
        public int PatientCount { get; set; }

        public Action<int> NumberChanged;
        public WaitingRoom()
        {
            CurrentNumber = 0;
            PatientCount = 0;
        }


        public void RunWaitingRoom()
        {
            while (CurrentNumber < PatientCount)
            {
                CurrentNumber++;
                Console.WriteLine("Ding!!!");
                NumberChanged?.Invoke(CurrentNumber);
                Thread.Sleep(5000);
            }
        }
        

        public int PatientEntersRoom()
        {
            Console.WriteLine($"Patient {PatientCount} enters the room");
            PatientCount++;
            return PatientCount;
        }
    }
}
