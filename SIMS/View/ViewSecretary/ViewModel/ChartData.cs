using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
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

        public ChartData()
        {

        }

        public Dictionary<DocTypeEnum, int> DoctorChart { get => doctorChart; set => doctorChart = value; }
        public Dictionary<string, int> MaleChart { get => maleChart; set => maleChart = value; }
        public Dictionary<string, int> FemaleChart { get => femaleChart; set => femaleChart = value; }
        public Dictionary<string, int> OtherChart { get => otherChart; set => otherChart = value; }

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

    }
}
