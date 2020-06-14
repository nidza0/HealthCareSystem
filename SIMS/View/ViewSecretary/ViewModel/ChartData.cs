using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class ChartData
    {
        private Dictionary<DocTypeEnum, int> doctorChart = new Dictionary<DocTypeEnum, int>();
        private Dictionary<string, int> maleChart = new Dictionary<string, int>();
        private Dictionary<string, int> femaleChart = new Dictionary<string, int>();
        private Dictionary<string, int> otherChart = new Dictionary<string, int>();
        private Dictionary<string, double> roomChart = new Dictionary<string, double>();

        public ChartData()
        {

        }

        public Dictionary<DocTypeEnum, int> DoctorChart { get => doctorChart; set => doctorChart = value; }
        public Dictionary<string, int> MaleChart { get => maleChart; set => maleChart = value; }
        public Dictionary<string, int> FemaleChart { get => femaleChart; set => femaleChart = value; }
        public Dictionary<string, int> OtherChart { get => otherChart; set => otherChart = value; }
        public Dictionary<string, double> RoomChart { get => roomChart; set => roomChart = value; }

        public void LoadDoctorChart()
        {
            doctorChart.Clear();
            var doctors = SecretaryAppResources.GetInstance().doctorRepository.GetAll();
            foreach(Doctor doc in doctors)
            {
                if (doctorChart.ContainsKey(doc.DocTypeEnum))
                    doctorChart[doc.DocTypeEnum] += 1;
                else
                    doctorChart.Add(doc.DocTypeEnum, 1);
            }
        }

        public void LoadPatientChart()
        {
            maleChart.Clear();
            femaleChart.Clear();
            otherChart.Clear();

            var patients = SecretaryAppResources.GetInstance().patientRepository.GetAll();

            foreach(Patient p in patients)
            {
                string category = AgeToCategory(p.DateOfBirth);
                switch (p.Sex)
                {
                    case Sex.MALE:
                        {
                            if (maleChart.ContainsKey(category))
                                maleChart[category] += 1;
                            else
                                maleChart.Add(category, 1);
                            break;
                        }
                    case Sex.FEMALE:
                        {
                            if (femaleChart.ContainsKey(category))
                                femaleChart[category] += 1;
                            else
                                femaleChart.Add(category, 1);
                            break;
                        }
                    case Sex.OTHER:
                        {
                            if (otherChart.ContainsKey(category))
                                otherChart[category] += 1;
                            else
                                otherChart.Add(category, 1);
                            break;
                        }
                }
            }
        }

        private string AgeToCategory(DateTime dateOfBirth)
        {
            int years = DateTime.Now.Year - dateOfBirth.Year;

            if (dateOfBirth.Month == DateTime.Now.Month &&// if the start month and the end month are the same
                DateTime.Now.Day < dateOfBirth.Day// AND the end day is less than the start day
                || DateTime.Now.Month < dateOfBirth.Month)// OR if the end month is less than the start month
            {
                years--;
            }

            if (years <= 20)
                return "0-20";
            else if (years <= 40)
                return "21-40";
            else if (years <= 60)
                return "41-60";
            else if (years <= 80)
                return "61-80";
            else
                return "over 80";
        }

        public void LoadRoomChart()
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime tomorrow = today.AddDays(1);
            TimeInterval time = new TimeInterval(today, tomorrow);
            var appointments = SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time).Where(ap => !ap.Canceled);

            Dictionary<string, TimeSpan> appointmentDuration = new Dictionary<string, TimeSpan>();
            TimeSpan total = TimeSpan.Zero;
            foreach(Appointment a in appointments)
            {
                TimeSpan roomSpan = a.TimeInterval.StartTime - a.TimeInterval.EndTime;
                total += roomSpan;

                if (appointmentDuration.ContainsKey(a.Room.RoomNumber))
                    appointmentDuration[a.Room.RoomNumber] += roomSpan;
                else
                    appointmentDuration.Add(a.Room.RoomNumber, roomSpan);
            }

            if (total.TotalMinutes == 0)
                return;

            foreach(string roomNumber in appointmentDuration.Keys)
            {
                TimeSpan roomSpan = appointmentDuration[roomNumber];
                roomChart.Add(roomNumber, 100 * roomSpan.TotalMinutes / total.TotalMinutes);
            }
        }

    }
}
