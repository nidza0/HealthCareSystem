﻿using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DoctorAddingPage2.xaml
    /// </summary>
    public partial class DoctorAddingPage2 : Page
    {
        private bool home = false;
        private bool cell = false;
        private bool email1 = false;
        private bool email2 = false;

        private String username;
        private string password;
        private DateTime created;
        private Dictionary<WorkingDaysEnum, Util.TimeInterval> dict;
        private TimeTable timeTable;


        private String Name;
        private String Surname;
        String MiddleName;
        Sex Sex;
        DateTime Birth;
        String Jmbg;
        String Addressa;

        private AppResources appResources;

        public DoctorAddingPage2(String name, String surname, String middlename, Sex sex, DateTime birth, String jmbg, String addressString)
        {
            InitializeComponent();

            finishButton.IsEnabled = false;
            appResources = AppResources.getInstance();
            initCombo();

            username = name + " " + surname;
            password = name + surname + "123";
            created = DateTime.Now;

            
            Name = name;
            Surname = surname;
            MiddleName = middlename;
            Sex = sex;
            Birth = birth;
            Jmbg = jmbg;
            Addressa = addressString;
        }

        private void initCombo()
        {
            docTypeCombo.Items.Add("Pordični lekar");
            docTypeCombo.Items.Add("Hirurg");
            docTypeCombo.Items.Add("Kardiolog");
            docTypeCombo.Items.Add("Dermatolog");
            docTypeCombo.Items.Add("Infektolog");
            docTypeCombo.Items.Add("Oftamolog");
            docTypeCombo.Items.Add("Endokrinolog");
            docTypeCombo.Items.Add("Gastroenterolog");
            docTypeCombo.SelectedIndex = 1;

            foreach(Room room in appResources.roomController.GetAll())
            {
                roomCombo.Items.Add(room.RoomNumber);
            }
            roomCombo.SelectedIndex = 0;
        }

        private void homePhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyPhone(homePhone.Text.ToString()))
            {
                homePhone.Background = Brushes.PaleVioletRed;
                home = false;
            }
            else
            {
                homePhone.Background = Brushes.Transparent;
                home = true;
                checkButton();
            }
        }

        private void cellPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyPhone(cellPhone.Text.ToString()))
            {
                cellPhone.Background = Brushes.PaleVioletRed;
                cell = false;
            }
            else
            {
                cellPhone.Background = Brushes.Transparent;
                cell = true;
                checkButton();
            }
        }

        private bool verifyPhone(String phone)
        {
            if (!Regex.Match(phone, Regexes.phoneRegex).Success || string.IsNullOrWhiteSpace(phone))
                return true;
            return false;
        }

        private void email1Input_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyMail(email1Input.Text.ToString()))
            {
                email1Input.Background = Brushes.PaleVioletRed;
                email1 = false;
            }
            else
            {
                email1Input.Background = Brushes.Transparent;
                email1 = true;
                checkButton();
            }
        }

        private void email2Input_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyMail(email2Input.Text.ToString()))
            {
                email2Input.Background = Brushes.PaleVioletRed;
                email2 = false;
            }
            else
            {
                email2Input.Background = Brushes.Transparent;
                email2 = true;
                checkButton();
            }
        }

        private bool verifyMail(String phone)
        {
            if (!Regex.Match(phone, Regexes.emailRegex).Success || string.IsNullOrWhiteSpace(phone))
                return true;
            return false;
        }

        private void checkButton()
        {
            if (home && cell && email1 && email2)
                finishButton.IsEnabled = true;
            else
                finishButton.IsEnabled = false;
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            String[] tokens = Addressa.Split('/');
            Address address = new Address(tokens[0],new Location(tokens[2],tokens[1]));
            DoctorType doctype =(DoctorType) docTypeCombo.SelectedIndex;

            dict = new Dictionary<WorkingDaysEnum, Util.TimeInterval>();
            dict[WorkingDaysEnum.MONDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.TUESDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.WEDNESDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.THURSDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.FRIDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.SATURDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 8, 0, 0));
            dict[WorkingDaysEnum.SUNDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 8, 0, 0));

            timeTable = new TimeTable(dict);

            Console.WriteLine(timeTable.WorkingHours[WorkingDaysEnum.MONDAY]);
            timeTable = appResources.timeTableRepository.Create(timeTable);

            Doctor doc = new Doctor(username, password, created, Name, Surname, MiddleName, Sex, Birth, Jmbg, address, homePhone.Text, cellPhone.Text, email1Input.Text, email2Input.Text, timeTable, null, appResources.roomController.GetRoomByName(roomCombo.SelectedItem.ToString()), doctype);


            appResources.doctorController.Create(doc);

            NavigationService.Navigate(new DoctorsOverviewPage());

        }
    }
}
