using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for DoctorDetailPage.xaml
    /// </summary>
    public partial class DoctorDetailPage : Page
    {
        private Doctor sDoc;

        public DoctorDetailPage(Model.UserModel.Doctor doc)
        {
            InitializeComponent();


            usernameLabel.Content = doc.UserName;
            telefonLabel.Content = doc.CellPhone;
            titulaLabel.Content = doc.Sex;
            datumLabel.Content = doc.DateOfBirth.ToString();
            roomLabel.Content = doc.Office.GetId();
            NameLabel.Content = doc.FullName;
            radnovremeLabel.Content = generateTime(doc);

            sDoc = doc;
        }

        private String generateTime(Doctor doc)
        {
            DateTime now = DateTime.Now;

            WorkingDaysEnum day = WorkingDaysEnum.MONDAY;

            Console.WriteLine(now.DayOfWeek);

            switch(now.DayOfWeek.ToString())
            {
                case "Sunday":
                    day = WorkingDaysEnum.SUNDAY;
                    break;
                case "Monday":
                    day = WorkingDaysEnum.MONDAY;
                    break;
                case "Tuesday":
                    day = WorkingDaysEnum.TUESDAY;
                    break;
                case "Wednesday":
                    day = WorkingDaysEnum.WEDNESDAY;
                    break;
                case "Thursday":
                    day = WorkingDaysEnum.THURSDAY;
                    break;
                case "Friday":
                    day = WorkingDaysEnum.FRIDAY;
                    break;
                case "Saturday":
                    day = WorkingDaysEnum.SATURDAY;
                    break;
            }

            String startHour = doc.TimeTable.WorkingHours[day].StartTime.Hour.ToString();
            String startMinute = doc.TimeTable.WorkingHours[day].StartTime.Minute.ToString();
            if (doc.TimeTable.WorkingHours[day].StartTime.Minute == 0)
                startMinute += "0";
            String endHour = doc.TimeTable.WorkingHours[day].EndTime.Hour.ToString();
            String endMinute = doc.TimeTable.WorkingHours[day].EndTime.Minute.ToString();
            if (doc.TimeTable.WorkingHours[day].EndTime.Minute == 0)
                endMinute += "0";

            String retVal =startHour+ ":" + startMinute + " - " + endHour + ":" + endMinute;

            return retVal;
        }

        //Menu buttons
        private void MenuSmene_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/ShiftsOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuLekari_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/DoctorsOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuInventar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/InventoryOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuLekovi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/MedicineOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuSale_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/RoomsOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuDodavanje_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/DoctorAddingPage.xaml", UriKind.Relative));
        }
        //END REGION
        
        // Home Button
        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/ManagerMainPage.xaml", UriKind.Relative));
        }
        //END REGION

        //Back button
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void shiftButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorWorkingHoursPage(sDoc));
        }

        private void reportButton_Click(object sender, RoutedEventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = sDoc.Name + sDoc.Surname;
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 30, XFontStyle.Bold);
            XFont font2 = new XFont("Verdana", 20, XFontStyle.Regular);

            graph.DrawString("Izveštaj za doktora: ", font, XBrushes.Black, new XRect(0, 40, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString(sDoc.Name+" "+sDoc.Surname, font, XBrushes.Black, new XRect(0,80, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);


            //ponedeljak
            String ponedeljakBegin = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY].StartTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY].StartTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY].StartTime.Minute == 0)
                ponedeljakBegin += "0";

            String ponedeljakEnd = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY].EndTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY].EndTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY].EndTime.Minute == 0)
                ponedeljakEnd += "0";

            String ponedeljak = ponedeljakBegin + " - " + ponedeljakEnd;

            if (ponedeljakBegin.Equals(ponedeljakEnd))
                ponedeljak = "Ne radi";

            graph.DrawString("Ponedeljak: ", font2, XBrushes.Black, new XRect(10, 150, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString( ponedeljak, font2, XBrushes.Black, new XRect(30, 180, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);


            //utorak
            String utorakBegin = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.TUESDAY].StartTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.TUESDAY].StartTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.TUESDAY].StartTime.Minute == 0)
                utorakBegin += "0";

            String utorakEnd = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.TUESDAY].EndTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.TUESDAY].EndTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.TUESDAY].EndTime.Minute == 0)
                utorakEnd += "0";

            String utorak = utorakBegin + " - " + utorakEnd;

            if (utorakBegin.Equals(utorakEnd))
                utorak = "Ne radi";

            graph.DrawString("Utorak: ", font2, XBrushes.Black, new XRect(10, 220, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(utorak, font2, XBrushes.Black, new XRect(30, 250, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

      
            //sreda
            String sredaBegin = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY].StartTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY].StartTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY].StartTime.Minute == 0)
                sredaBegin += "0";

            String sredaEnd = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY].EndTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY].EndTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY].EndTime.Minute == 0)
                sredaEnd += "0";

            String sreda = sredaBegin + " - " + sredaEnd;

            if (sredaBegin.Equals(sredaEnd))
                sreda = "Ne radi";

            graph.DrawString("Sreda: ", font2, XBrushes.Black, new XRect(10, 290, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(sreda, font2, XBrushes.Black, new XRect(30, 320, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);


            //cetvrtak
            String cetvrtakBegin = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.THURSDAY].StartTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.THURSDAY].StartTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.THURSDAY].StartTime.Minute == 0)
                cetvrtakBegin += "0";

            String cetvrtakkEnd = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.THURSDAY].EndTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.THURSDAY].EndTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.THURSDAY].EndTime.Minute == 0)
                cetvrtakkEnd += "0";

            String cetvrtak = cetvrtakBegin + " - " + cetvrtakkEnd;

            if (cetvrtakBegin.Equals(cetvrtakkEnd))
                cetvrtak = "Ne radi";

            graph.DrawString("Četvrtak: ", font2, XBrushes.Black, new XRect(10, 360, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(cetvrtak, font2, XBrushes.Black, new XRect(30, 390, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);


            //petak
            String petakBegin = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.FRIDAY].StartTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.FRIDAY].StartTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.FRIDAY].StartTime.Minute == 0)
                petakBegin += "0";

            String petakEnd = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.FRIDAY].EndTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.FRIDAY].EndTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.FRIDAY].EndTime.Minute == 0)
                petakEnd += "0";

            String petak = petakBegin + " - " + petakEnd;

            if (petakBegin.Equals(petakEnd))
                petak = "Ne radi";

            graph.DrawString("Petak: ", font2, XBrushes.Black, new XRect(10, 430, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(petak, font2, XBrushes.Black, new XRect(30, 460, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);


            //subota
            String subotaBegin = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SATURDAY].StartTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SATURDAY].StartTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SATURDAY].StartTime.Minute == 0)
                subotaBegin += "0";

            String subotaEnd = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SATURDAY].EndTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SATURDAY].EndTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SATURDAY].EndTime.Minute == 0)
                subotaEnd += "0";

            String subota = subotaBegin + " - " + subotaEnd;

            if (subotaBegin.Equals(subotaEnd))
                subota = "Ne radi";

            graph.DrawString("Subota: ", font2, XBrushes.Black, new XRect(10, 500, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(subota, font2, XBrushes.Black, new XRect(30, 530, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);


            //nedelja
            String nedeljaBegin = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SUNDAY].StartTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SUNDAY].StartTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY].StartTime.Minute == 0)
                nedeljaBegin += "0";

            String nedeljaEnd = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SUNDAY].EndTime.Hour.ToString() + ":" + sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SUNDAY].EndTime.Minute.ToString();
            if (sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SUNDAY].EndTime.Minute == 0)
                nedeljaEnd += "0";

            String nedelja = nedeljaBegin + " - " + nedeljaEnd;

            if (nedeljaBegin.Equals(nedeljaEnd))
                nedelja = "Ne radi";

            graph.DrawString("Nedelja: ", font2, XBrushes.Black, new XRect(10, 570, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(nedelja, font2, XBrushes.Black, new XRect(30, 600, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            TimeInterval pon = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.MONDAY];
            TimeInterval uto = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.TUESDAY];
            TimeInterval sre = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.WEDNESDAY];
            TimeInterval cet = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.THURSDAY];
            TimeInterval pet = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.FRIDAY];
            TimeInterval sub = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SATURDAY];
            TimeInterval ned = sDoc.TimeTable.WorkingHours[WorkingDaysEnum.SUNDAY];

            int ponMin = minutes(pon);
            int utoMin = minutes(uto);
            int sreMin = minutes(sre);
            int cetMin = minutes(cet);
            int petMin = minutes(pet);
            int subMin = minutes(sub);
            int nedMin = minutes(ned);

            int ukupno = ponMin + utoMin + sreMin + cetMin + petMin + subMin + nedMin;
            Console.WriteLine(ukupno);

            String sati = (ukupno / 60).ToString();
            String minuti = ((ukupno % 60) * 60).ToString();

            graph.DrawString("Ukupno radnih časova u nedelji: ", font2, XBrushes.Black, new XRect(10, 640, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(sati+" sati i "+minuti+ " minuta.", font2, XBrushes.Black, new XRect(30, 670, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            if(ukupno/60 > 40)
            {
                sati = ((ukupno / 60) - 40).ToString();
                minuti = ((ukupno % 60) * 60).ToString();
                graph.DrawString("Ukupno prekovremenih sati: ", font2, XBrushes.Black, new XRect(10, 710, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(sati + " sati i " + minuti + " minuta.", font2, XBrushes.Black, new XRect(30, 740, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            }
            else
            {
                sati = ((ukupno / 60) - 40).ToString();
                minuti = ((ukupno % 60) * 60).ToString();
                graph.DrawString("Sati manje od uobičajne radne nedelje: ", font2, XBrushes.Black, new XRect(10, 710, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(sati + " sati i " + minuti + " minuta.", font2, XBrushes.Black, new XRect(30, 740, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            }

            pdf.Save("C:/Users/vule/Desktop/"+sDoc.Name + sDoc.Surname+".pdf");
            //Process.Start(sDoc.Name + sDoc.Surname);
        }

        private int minutes(TimeInterval day)
        {
            int retVal = 0;

            String[] parts = day.Duration().ToString().Split(':');

            int hour = int.Parse(parts[0]);
            int minute = int.Parse(parts[1]);

            retVal += 60 * hour + minute;

            return retVal;
        }
        //END REGION

    }
}
