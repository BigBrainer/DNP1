using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_04_S02
{
    public class Patient
    { 
        private int PatientNo { get; set; }
        private WaitingRoom WaitingRoom;

        public Patient(WaitingRoom waitingRoom)
        {
            PatientNo = waitingRoom.PatientEntersRoom();
            waitingRoom.NumberChanged += OnNumberChanged;
            WaitingRoom = waitingRoom;
        }
        public void OnNumberChanged(int patientNo)
        {
            Console.WriteLine($"Patient {PatientNo} looks up");
            if(PatientNo == patientNo)
            {
                Console.WriteLine($"Patient {PatientNo} walks into the doctors office.");
                WaitingRoom.NumberChanged -= OnNumberChanged;
            }
            else Console.WriteLine($"Patient {PatientNo} goes back to playing with his FLACCID DICK");

        }
    }
}
