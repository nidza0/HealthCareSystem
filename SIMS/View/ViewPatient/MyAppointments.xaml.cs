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
using System.Windows.Shapes;

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Model.PatientModel;
using System.Collections.ObjectModel;
using SIMS.Util;
using System.ComponentModel;
using SIMS.View.ViewPatient.RepoSimulator;
using Microsoft.Win32;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;
using System.Data;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for MyAppointments.xaml
    /// </summary>
    public partial class MyAppointments : Window
    {

        private MyAppointmentsRepo myAppointmentsRepo = MyAppointmentsRepo.Instance;
        private DoctorAppointmentsRepo doctorAppointmentsRepo = DoctorAppointmentsRepo.Instance;

        private DoctorType selectedFilterDoctorType;
        private Doctor selectedFilterDoctor;
        private DateTime firstAllowedDate;
        private AppointmentType selectedFilterAppointmentType;
        private ObservableCollection<Appointment> allAppointments;
        private Appointment selectedAppointment;

        private DateTime selectedStartDate = DateTime.Now;

        private DateTime selectedEndDate = DateTime.Now;

        

        public MyAppointments()
        {
            firstAllowedDate = DateTime.Now.AddDays(1);
            AllAppointments = GetAllObservablePatientAppointments();
            this.DataContext = this;
            InitializeComponent();

            doctorTypeComboBox.ItemsSource = Enum.GetValues(typeof(DoctorType)).Cast<DoctorType>();
            appointmentTypeComboBox.ItemsSource = Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>();
        }

        public DoctorType SelectedFilterDoctorType { get => selectedFilterDoctorType; set => selectedFilterDoctorType = value; }
        public Doctor SelectedFilterDoctor { get => selectedFilterDoctor; set => selectedFilterDoctor = value; }

        public ObservableCollection<Doctor> PatientDoctors
        {
            get { 
                List<Doctor> patientDoctors = GetAllPatientAppointments().ToList().Select(appointment => appointment.DoctorInAppointment).Distinct().ToList();
                ObservableCollection<Doctor> retVal = new ObservableCollection<Doctor>();
                foreach(Doctor doctor in patientDoctors)
                {
                    retVal.Add(doctor);
                }

                return retVal;
            }
        }

        public DateTime FirstAllowedDate { get => firstAllowedDate; set => firstAllowedDate = value; }
        public DateTime SelectedStartDate { get => selectedStartDate; set => selectedStartDate = value; }
        public DateTime SelectedEndDate { get => selectedEndDate; set => selectedEndDate = value; }
        public AppointmentType SelectedFilterAppointmentType { get => selectedFilterAppointmentType; set => selectedFilterAppointmentType = value; }
        public ObservableCollection<Appointment> AllAppointments { get => allAppointments; set => allAppointments = value; }
        public Appointment SelectedAppointment { get => selectedAppointment; set => selectedAppointment = value; }

        private ObservableCollection<Appointment> GetAllObservablePatientAppointments()
        {
            ObservableCollection<Appointment> retVal = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in GetAllPatientAppointments())
                retVal.Add(appointment);

            return retVal;
        }
        
        private IEnumerable<Appointment> GetAllPatientAppointments()
        {
            //call controller
            return myAppointmentsRepo.MyAppointments;
            
           
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "appointment_export.pdf";
            // set filters - this can be done in properties as well
            savefile.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            Nullable<bool> result = savefile.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = savefile.FileName;


                Console.WriteLine(filename);

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                
                }

                PerformAppointmentExport(savefile.FileName);
            }
        }

        private void PerformAppointmentExport(string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
            Document document = new Document(PageSize.A3, 25, 25, 30, 50);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, fileStream);

            document.AddAuthor("Health care clinic Zdravo");
            document.AddCreator("Health care clinic Zdravo");
            document.AddSubject("Appointment report " + SelectedStartDate.ToString("MM-dd-yy") + " - " + SelectedEndDate.ToString("MM-dd-yy"));
            document.AddTitle("Appointment report");
            document.Open();
            //pdfWriter.PageEvent = new FooterPDFEvent();
            pdfWriter.PageEvent = new PDFWaterMarkEvent("Health clinic Zdravo");
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font titleFont = new Font(baseFont, 22);

            
            Paragraph title = new Paragraph("Appointment report", titleFont);
            title.Alignment = Element.ALIGN_CENTER;

            document.Add(title);

            Font dateInfoFont = new Font(baseFont, 18, 0);

            string text = SelectedStartDate.ToString("MM-dd-yy") + "      " + "to      " + SelectedEndDate.ToString("MM-dd-yy");
            Paragraph dateSubtitle = new Paragraph(text, dateInfoFont);
            dateSubtitle.Alignment = Element.ALIGN_CENTER;

            document.Add(dateSubtitle);

            Paragraph separator = new Paragraph(Chunk.NEWLINE);
            document.Add(separator);
            document.Add(separator);
            document.Add(separator);

            List<Appointment> appointments = GetAllPatientAppointments().ToList();

            if(appointments.Count >= 0)
            {
                //odavde na dole je generisanje tabele
                float[] pointColumnWidths = { 10F, 10F, 9F, 20F, 5F, 10F, 8F };

                PdfPTable table = new PdfPTable(pointColumnWidths);
                DataTable dataTable = new DataTable();


                string[] tableHeaders = { "Date", "Time", "Location", "Type", "Doctor", "Phone number", "Ordination" };


                foreach (string header in tableHeaders)
                {
                    table.AddCell(new PdfPCell(new Phrase(header)));
                }

                table.HeaderRows = 1;

                foreach (Appointment appointment in GetAllPatientAppointments())
                {
                    PdfPCell timeCell = new PdfPCell();
                    PdfPCell dateCell = new PdfPCell();
                    PdfPCell locationCell = new PdfPCell();
                    PdfPCell typeCell = new PdfPCell();
                    PdfPCell doctorCell = new PdfPCell();
                    PdfPCell phoneNumberCell = new PdfPCell();
                    PdfPCell ordinationCell = new PdfPCell();
                    dateCell.AddElement(new Phrase(appointment.TimeInterval.StartTime.ToString("MM-dd-yy")));
                    timeCell.AddElement(new Phrase(appointment.TimeInterval.StartTime.ToString("HH:mm")));
                    locationCell.AddElement(new Phrase(appointment.DoctorInAppointment.Hospital.Address.Location.City + ", " + appointment.DoctorInAppointment.Hospital.Address.Location.Country + ", " + appointment.DoctorInAppointment.Office.RoomNumber));
                    typeCell.AddElement(new Phrase(appointment.AppointmentType.ToString()));
                    doctorCell.AddElement(new Phrase(appointment.DoctorInAppointment.Name + ", " + appointment.DoctorInAppointment.Surname));
                    phoneNumberCell.AddElement(new Phrase(appointment.DoctorInAppointment.CellPhone));
                    ordinationCell.AddElement(new Phrase(appointment.Room.RoomNumber));




                    table.AddCell(timeCell);
                    table.AddCell(dateCell);
                    table.AddCell(locationCell);
                    table.AddCell(typeCell);
                    table.AddCell(doctorCell);
                    table.AddCell(phoneNumberCell);
                    table.AddCell(ordinationCell);
                }

                document.Add(table);
            }
            else
            {
                document.Add(separator);
                document.Add(separator);
                document.Add(separator);
                document.Add(separator);
                document.Add(separator);
                document.Add(separator);
                Paragraph error = new Paragraph("No appointments to show!", titleFont);
                document.Add(error);

            }



            document.Close();
            pdfWriter.Close();
            fileStream.Close();
         
         
        }

        

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditAnAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Appointment appointment = button.DataContext as Appointment;

            if (!CheckIfAppointmentEditable(appointment))
            {
                MessageBox.Show("Appointment can't be changed now!");
                return;
            }



            EditAnAppointment editAnAppointment = new EditAnAppointment(appointment);
            editAnAppointment.ShowDialog();



            refreshAppointmentList();

            
        }

        private void refreshAppointmentList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(AllAppointments);
            view.Refresh();
        }

        private bool CheckIfAppointmentEditable(Appointment appointment)
        {
            if (appointment.TimeInterval.StartTime < DateTime.Now.AddDays(1)) //ako je manje od 24 sata, ovo ce se proveravati na backendu ali i ovde ajde
                return false;

            return true;
        }

        private void CancelAnAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Appointment appointment = button.DataContext as Appointment;

            if (!CheckIfAppointmentEditable(appointment))
            {
                MessageBox.Show("Appointment can't be canceled now!");
                return;
            }
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to cancel this appointment?", "Cancel appointment confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                myAppointmentsRepo.cancelAppointment(appointment);
                AllAppointments.Remove(appointment);

                doctorAppointmentsRepo.cancelAnAppointment(appointment);

                MessageBox.Show("Appointment successfully canceled!");
            }




           

            refreshAppointmentList();
        }



        //cancel an appointment
        //-> call update(set appointment.canceled = true)
    }
}
