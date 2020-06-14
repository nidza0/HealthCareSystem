using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewManager
{
    /// <summary>
    /// Interaction logic for DoctorWorkingHoursPage.xaml
    /// </summary>
    public partial class DoctorWorkingHoursPage : Page
    {
        private Doctor sDoc;

        public DoctorWorkingHoursPage(Doctor doc)
        {
            InitializeComponent();
            sDoc = doc;
            initCombo(doc);
            
        }

        private void initCombo(Doctor doc)
        {

            for(int i = 0; i<24;i++)
            {
                    ponOd.Items.Add(i.ToString() + ":00");
                    ponOd.Items.Add(i.ToString() + ":30");
                    ponDo.Items.Add(i.ToString() + ":00");
                    ponDo.Items.Add(i.ToString() + ":30");

                    utoOd.Items.Add(i.ToString() + ":00");
                    utoDo.Items.Add(i.ToString() + ":00");
                    utoOd.Items.Add(i.ToString() + ":30");
                    utoDo.Items.Add(i.ToString() + ":30");

                    sreOd.Items.Add(i.ToString() + ":00");
                    sreDo.Items.Add(i.ToString() + ":00");
                    sreOd.Items.Add(i.ToString() + ":30");
                    sreDo.Items.Add(i.ToString() + ":30");

                    cetOd.Items.Add(i.ToString() + ":00");
                    cetDo.Items.Add(i.ToString() + ":00");
                    cetOd.Items.Add(i.ToString() + ":30");
                    cetDo.Items.Add(i.ToString() + ":30");

                    petOd.Items.Add(i.ToString() + ":00");
                    petDo.Items.Add(i.ToString() + ":00");
                    petOd.Items.Add(i.ToString() + ":30");
                    petDo.Items.Add(i.ToString() + ":30");

                    subOd.Items.Add(i.ToString() + ":00");
                    subDo.Items.Add(i.ToString() + ":00");
                    subOd.Items.Add(i.ToString() + ":30");
                    subDo.Items.Add(i.ToString() + ":30");

                    nedOd.Items.Add(i.ToString() + ":00");
                    nedDo.Items.Add(i.ToString() + ":00");
                    nedOd.Items.Add(i.ToString() + ":30");
                    nedDo.Items.Add(i.ToString() + ":30");

            }

            

            initFirst(doc);

            

        }

        private void initFirst(Doctor doc)
        {
            TimeTable timeTable = doc.TimeTable;

            TimeInterval pon = timeTable.WorkingHours[WorkingDaysEnum.MONDAY];
            TimeInterval uto = timeTable.WorkingHours[WorkingDaysEnum.TUESDAY];
            TimeInterval sre = timeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY];
            TimeInterval cet = timeTable.WorkingHours[WorkingDaysEnum.THURSDAY];
            TimeInterval pet = timeTable.WorkingHours[WorkingDaysEnum.FRIDAY];
            TimeInterval sub = timeTable.WorkingHours[WorkingDaysEnum.SATURDAY];
            TimeInterval ned = timeTable.WorkingHours[WorkingDaysEnum.SUNDAY];

            String ponBeg = pon.StartTime.Hour.ToString() + ":" + pon.StartTime.Minute.ToString();
            if (pon.StartTime.Minute == 0)
                ponBeg += "0";


            //Ponedeljak
            int iter = 0;
            foreach (String vreme in ponOd.Items)
            {
                if (ponBeg.Equals(vreme))
                {
                    ponOd.SelectedIndex = iter;
                }
                iter++;
            }

            String ponEnd = pon.EndTime.Hour.ToString() + ":" + pon.EndTime.Minute.ToString();
            if (pon.EndTime.Minute == 0)
                ponEnd += "0";


            Console.WriteLine(ponEnd);

            iter = 0;
            foreach (String vreme in ponDo.Items)
            {
                if (ponEnd.Equals(vreme))
                {
                    ponDo.SelectedIndex = iter;
                }
                iter++;
            }
            
            //utorak
            String utoBeg = uto.StartTime.Hour.ToString() + ":" + uto.StartTime.Minute.ToString();
            if (uto.StartTime.Minute == 0)
                utoBeg += "0";

            iter = 0;
            foreach (String vreme in utoOd.Items)
            {
                if (utoBeg.Equals(vreme))
                {
                    utoOd.SelectedIndex = iter;
                }
                iter++;
            }

            String utoEnd = uto.EndTime.Hour.ToString() + ":" + uto.EndTime.Minute.ToString();
            if (uto.EndTime.Minute == 0)
                utoEnd += "0";

            iter = 0;
            foreach (String vreme in utoDo.Items)
            {
                if (utoEnd.Equals(vreme))
                {
                    utoDo.SelectedIndex = iter;
                }
                iter++;
            }

            //sreda
            String sreBeg = sre.StartTime.Hour.ToString() + ":" + sre.StartTime.Minute.ToString();
            if (sre.StartTime.Minute == 0)
                sreBeg += "0";

            iter = 0;
            foreach (String vreme in sreOd.Items)
            {
                if (sreBeg.Equals(vreme))
                {
                    sreOd.SelectedIndex = iter;
                }
                iter++;
            }

            String sreEnd = sre.EndTime.Hour.ToString() + ":" + sre.EndTime.Minute.ToString();
            if (sre.EndTime.Minute == 0)
                sreEnd += "0";

            iter = 0;
            foreach (String vreme in sreDo.Items)
            {
                if (sreEnd.Equals(vreme))
                {
                    sreDo.SelectedIndex = iter;
                }
                iter++;
            }

            //cetvrtak
            String cetBeg = cet.StartTime.Hour.ToString() + ":" + cet.StartTime.Minute.ToString();
            if (cet.StartTime.Minute == 0)
                cetBeg += "0";

            iter = 0;
            foreach (String vreme in cetOd.Items)
            {
                if (cetBeg.Equals(vreme))
                {
                    cetOd.SelectedIndex = iter;
                }
                iter++;
            }

            String cetEnd = cet.EndTime.Hour.ToString() + ":" + cet.EndTime.Minute.ToString();
            if (cet.EndTime.Minute == 0)
                cetEnd += "0";

            iter = 0;
            foreach (String vreme in cetDo.Items)
            {
                if (cetEnd.Equals(vreme))
                {
                    cetDo.SelectedIndex = iter;
                }
                iter++;
            }

            //petak
            String petBeg = pet.StartTime.Hour.ToString() + ":" + pet.StartTime.Minute.ToString();
            if (pet.StartTime.Minute == 0)
                petBeg += "0";

            iter = 0;
            foreach (String vreme in petOd.Items)
            {
                if (petBeg.Equals(vreme))
                {
                    petOd.SelectedIndex = iter;
                }
                iter++;
            }

            String petEnd = pet.EndTime.Hour.ToString() + ":" + pet.EndTime.Minute.ToString();
            if (pet.EndTime.Minute == 0)
                petEnd += "0";

            iter = 0;
            foreach (String vreme in petDo.Items)
            {
                if (petEnd.Equals(vreme))
                {
                    petDo.SelectedIndex = iter;
                }
                iter++;
            }

            //subota
            String subBeg = sub.StartTime.Hour.ToString() + ":" + sub.StartTime.Minute.ToString();
            if (sub.StartTime.Minute == 0)
                subBeg += "0";

            iter = 0;
            foreach (String vreme in subOd.Items)
            {
                if (subBeg.Equals(vreme))
                {
                    subOd.SelectedIndex = iter;
                }
                iter++;
            }

            String subEnd = sub.EndTime.Hour.ToString() + ":" + sub.EndTime.Minute.ToString();
            if (sub.EndTime.Minute == 0)
                subEnd += "0";

            iter = 0;
            foreach (String vreme in subDo.Items)
            {
                if (subEnd.Equals(vreme))
                {
                    subDo.SelectedIndex = iter;
                }
                iter++;
            }

            //nedelja
            String nedBeg = ned.StartTime.Hour.ToString() + ":" + ned.StartTime.Minute.ToString();
            if (ned.StartTime.Minute == 0)
                nedBeg += "0";

            iter = 0;
            foreach (String vreme in nedOd.Items)
            {
                if (nedBeg.Equals(vreme))
                {
                    nedOd.SelectedIndex = iter;
                }
                iter++;
            }

            String nedEnd = ned.EndTime.Hour.ToString() + ":" + ned.EndTime.Minute.ToString();
            if (ned.EndTime.Minute == 0)
                nedEnd += "0";

            iter = 0;
            foreach (String vreme in nedDo.Items)
            {
                if (nedEnd.Equals(vreme))
                {
                    nedDo.SelectedIndex = iter;
                }
                iter++;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            TimeInterval newMon = editTimeInterval(ponOd.SelectedItem.ToString(), ponDo.SelectedItem.ToString());
            TimeInterval newTue = editTimeInterval(utoOd.SelectedItem.ToString(), utoDo.SelectedItem.ToString());
            TimeInterval newWed = editTimeInterval(sreOd.SelectedItem.ToString(), sreDo.SelectedItem.ToString());
            TimeInterval newThu = editTimeInterval(cetOd.SelectedItem.ToString(), cetDo.SelectedItem.ToString());
            TimeInterval newFri = editTimeInterval(petOd.SelectedItem.ToString(), petDo.SelectedItem.ToString());
            TimeInterval newSat = editTimeInterval(subOd.SelectedItem.ToString(), subDo.SelectedItem.ToString());
            TimeInterval newSun = editTimeInterval(nedOd.SelectedItem.ToString(), nedDo.SelectedItem.ToString());

            Dictionary<WorkingDaysEnum, TimeInterval> newDict = new Dictionary<WorkingDaysEnum, TimeInterval>();

            newDict[WorkingDaysEnum.MONDAY] = newMon;
            newDict[WorkingDaysEnum.TUESDAY] = newTue;
            newDict[WorkingDaysEnum.WEDNESDAY] = newWed;
            newDict[WorkingDaysEnum.THURSDAY] = newThu;
            newDict[WorkingDaysEnum.FRIDAY] = newFri;
            newDict[WorkingDaysEnum.SATURDAY] = newSat;
            newDict[WorkingDaysEnum.SUNDAY] = newSun;


            TimeTable newTime = new TimeTable(newDict);

            int iter = 0;
            foreach(Doctor doc in Login.doctors)
            {
                if(doc.Equals(sDoc))
                {
                    Login.doctors[iter].TimeTable = newTime;
                }
                iter++;
            }

            NavigationService.Navigate(new DoctorDetailPage(sDoc));
        }


        private TimeInterval editTimeInterval(String startTime, String endTime)
        {
            TimeInterval retVal = null;

            String[] start = startTime.Split(':');
            String[] end = endTime.Split(':');

            retVal = new TimeInterval(new DateTime(1, 1, 1, int.Parse(start[0]), int.Parse(start[1]), 0), new DateTime(1, 1, 1, int.Parse(end[0]), int.Parse(end[1]), 0));

            return retVal;
        }
    }
}
