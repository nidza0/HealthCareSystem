using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class UserViewModel
    {
        private static UserViewModel instance = null;

        private Secretary loggedInUser = null;
        private List<TimeInterval> shifts = new List<TimeInterval>();

        private UserViewModel() { }

        public Secretary LoggedInUser { get => loggedInUser; 
            set 
            { 
                loggedInUser = value;
                if(loggedInUser.TimeTable != null)
                {
                    TimeTable tt = SecretaryAppResources.GetInstance().timeTableRepository.GetByID(loggedInUser.TimeTable.GetId());
                    Dictionary<WorkingDaysEnum, TimeInterval> sh = tt.getWorkingHours();
                    shifts.Add(sh.ContainsKey(WorkingDaysEnum.MONDAY) ? sh[WorkingDaysEnum.MONDAY] : null);
                    shifts.Add(sh.ContainsKey(WorkingDaysEnum.TUESDAY) ? sh[WorkingDaysEnum.TUESDAY] : null);
                    shifts.Add(sh.ContainsKey(WorkingDaysEnum.WEDNESDAY) ? sh[WorkingDaysEnum.WEDNESDAY] : null);
                    shifts.Add(sh.ContainsKey(WorkingDaysEnum.THURSDAY) ? sh[WorkingDaysEnum.THURSDAY] : null);
                    shifts.Add(sh.ContainsKey(WorkingDaysEnum.FRIDAY) ? sh[WorkingDaysEnum.FRIDAY] : null);
                    shifts.Add(sh.ContainsKey(WorkingDaysEnum.SATURDAY) ? sh[WorkingDaysEnum.SATURDAY] : null);
                    shifts.Add(sh.ContainsKey(WorkingDaysEnum.SUNDAY) ? sh[WorkingDaysEnum.SUNDAY] : null);
                }
            } 
        }

        public List<TimeInterval> Shifts { get => shifts; set => shifts = value; }

        public static UserViewModel GetInstance()
        {
            if (instance == null)
                instance = new UserViewModel();
            return instance;
        }


    }
}
