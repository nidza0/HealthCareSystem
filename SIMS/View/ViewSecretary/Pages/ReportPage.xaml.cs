using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewSecretary.Pages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private string _html = "";
        public ReportPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().CentralFrame.CanGoBack)
                FrameManager.getInstance().CentralFrame.GoBack();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (!DatesAreValid())
                return;

            string html = GetHtml();

            webBrowser.NavigateToString(html);
            webBrowser.Visibility = Visibility.Visible;
            btnSave.IsEnabled = true;

            System.Windows.Controls.PrintDialog printD = new System.Windows.Controls.PrintDialog();


        }

        private string GetHtml()
        {
            DateTime start = dateStart.SelectedDate.Value;
            DateTime end = dateEnd.SelectedDate.Value.AddHours(24).AddSeconds(-1);
            TimeInterval time = new TimeInterval(start, end);
            string dateFormat = "dd.MM.yyyy.";
            string timeFormat = "HH.mm";
            string dateTimeFormat = "dd.MM.yyyy. HH.mm";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "../../View/ViewSecretary/Resources/Images";
            string baseUrl = "file:///" + appPath.Replace("\\", "/") + "/";

            string pageTitle = "Report generated on " + DateTime.Now.ToString(dateFormat);
            string imgSource = "healthcare.jpg";
            string companyName = "Zdravo!";
            string companyName2 = "zdravstvena ustanova";
            string telephone = "Tel. 0123456789";
            string website = "www.zdravo-bolnica.rs";
            string title = "Report";
            string totalNumOfAppointments = "Total number of appointments: ";
            string totalTime = "Total time: ";
            string itemNum = "#";
            string startDate = "Start Date";
            string startTime = "Start Time";
            string endDate = "End Date";
            string endTime = "End Time";
            string doctor = "Doctor";
            string type = "Type";
            string hours = "hours";
            string minutes = "minutes";

            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html><html lang=\"en\"><head>");
            html.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"/>");
            html.Append("<meta charset=\"UTF-8\"><title>");
            html.Append(pageTitle);
            html.Append("</title>");
            html.Append("<base href=\"" + baseUrl + "\">");
            html.Append(GetHtmlStyle());
            html.Append("</head><body>");
            html.Append("<div class=\"header\"><img src=\"");
            html.Append(imgSource);
            html.Append("\" height=\"100px\"><div class=\"logo\"><h1 class=\"logo\">");
            html.Append(companyName);
            html.Append("</h1><p class=\"logo\">");
            html.Append(companyName2);
            html.Append("</p></div><div class=\"info\"><p class=\"info\">");
            html.Append(telephone);
            html.Append("</p><a href=\"http://");
            html.Append(website);
            html.Append("\" class=\"info\">");
            html.Append(website);
            html.Append("</a><p class=\"info\">");
            html.Append(DateTime.Now.ToString(dateTimeFormat));
            html.Append("</p></div></div>");

            html.Append("<h1 class=\"title\">");
            html.Append(title);
            html.Append("</h1><p class=\"title\">");
            html.Append(start.ToString(dateFormat));
            if (!start.ToString(dateFormat).Equals(end.ToString(dateFormat)))
            {
                html.Append(" - ");
                html.Append(end.ToString(dateFormat));
            }
            html.Append("</p>");
            html.Append("<ul>");

            var appointments = SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time).Where(ap => !ap.Canceled);
            var rooms = SecretaryAppResources.GetInstance().roomRepository.GetAll().OrderBy(r => r.RoomNumber);

            foreach(Room room in rooms)
            {
                html.Append("<li><p class=\"rooms\"><b>");
                html.Append(room.RoomNumber);
                html.Append("</b></p>");

                var roomAppointments = appointments.Where(a => a.Room.GetId() == room.GetId()).OrderBy(ap => ap.TimeInterval.StartTime);
                TimeSpan totalAppointmentTime = TimeSpan.Zero;
                
                if(roomAppointments.Count() > 0)
                {
                    html.Append("<table><thead><tr>");
                    html.Append("<th class=\"numcol\">");
                    html.Append(itemNum);
                    html.Append("</th><th class=\"timecol\">");
                    html.Append(startDate);
                    html.Append("</th><th class=\"timecol\">");
                    html.Append(startTime);
                    html.Append("</th><th class=\"timecol\">");
                    html.Append(endDate);
                    html.Append("</th><th class=\"timecol\">");
                    html.Append(endTime);
                    html.Append("</th><th>");
                    html.Append(doctor);
                    html.Append("</th><th>");
                    html.Append(type);
                    html.Append("</th></tr></thead>");
                    html.Append("<tbody>");

                    int counter = 0;

                    foreach(Appointment a in roomAppointments)
                    {
                        counter++;
                        html.Append("<tr><td>");
                        html.Append(counter);
                        html.Append("</td>");
                        html.Append("<td class=\"timedata\">");
                        html.Append(a.TimeInterval.StartTime.ToString(dateFormat));
                        html.Append("</td><td class=\"timedata\">");
                        html.Append(a.TimeInterval.StartTime.ToString(timeFormat));
                        html.Append("</td><td class=\"timedata\">");
                        html.Append(a.TimeInterval.EndTime.ToString(dateFormat));
                        html.Append("</td><td class=\"timedata\">");
                        html.Append(a.TimeInterval.EndTime.ToString(timeFormat));
                        html.Append("</td><td>");
                        html.Append(a.DoctorInAppointment == null ? "" : a.DoctorInAppointment.FullName);
                        html.Append("</td><td>");
                        html.Append(a.AppointmentType);
                        html.Append("</td>");

                        html.Append("</tr>");

                        totalAppointmentTime += a.TimeInterval.EndTime - a.TimeInterval.StartTime;
                    }
                    html.Append("</tbody></table>");
                }

                html.Append("<p>");
                html.Append(totalNumOfAppointments);
                html.Append(roomAppointments.Count());
                html.Append("</p><p>");
                html.Append(totalTime);
                if(totalAppointmentTime.Hours != 0)
                {
                    html.Append(totalAppointmentTime.Hours + " ");
                    html.Append(hours + " ");
                }
                html.Append(totalAppointmentTime.Minutes + " ");
                html.Append(minutes);
                html.Append("</p></li>");
            }

            html.Append("</ul>");
            html.Append("</body></html>");

            return  _html = html.ToString();
        }

        private string GetHtmlStyle()
        {
            return "<style>div.header{ display: flex; align-items: center; background-color: aliceblue; width: 100%; height: 100px; }" +
                    "div.logo{ margin-left: 20px; }" +
                    "h1.logo, p.logo { font-family: sans-serif; color: royalblue; }" +
                    "div.info{ align-items: center; margin-left: auto; margin-right: 25px; text-align: right; }" +
                    "p.info, a.info{ font-family: sans-serif; }" +
                    ".title { text-align: center; }" +
                    ".rooms{ font-size: 24px; margin-top: 20px; list-style-type: square; }" +
                    ".dates{ font-size: 20px; margin-top: 20px; list-style-type: none; }" +
                    ".appointments{ font-size: 10px; }" +
                    "table{ width: 100%; margin-top: 20px; border-collapse: collapse; }" +
                    "th{ border: solid 2px black; background-color: aliceblue; font-size: 18px}" +
                    ".numcol{ width: 30px; }" +
                    ".timecol{}" +
                    "tr:nth-child(even){ background-color: aliceblue; }" +
                    ".timedata{text-align: center;}" +
                    "td {font-size: 15px}" +
                    "</style>";
        }

        private bool DatesAreValid()
        {
            if (dateStart.SelectedDate.Value <= dateEnd.SelectedDate.Value)
                return true;
            return false;
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dateStart == null || dateEnd == null || errDate == null)
                return;

            if (DatesAreValid())
            {
                errDate.Visibility = Visibility.Collapsed;
                btnGenerate.IsEnabled = true;
            }
            else
            {
                errDate.Visibility = Visibility.Visible;
                btnGenerate.IsEnabled = false;
                btnSave.IsEnabled = false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!_html.Equals(""))
            {
                var dialog = new SaveFileDialog();
                dialog.AddExtension = true;
                dialog.DefaultExt = "pdf";
                dialog.Filter = "PDF File (*.pdf)|*.pdf";
                dialog.FileName = "report" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Thread t = new Thread(() => WritePdf(dialog.FileName, _html));
                    t.Start();
                }
            }

        }

        public void WritePdf(string filename, string html)
        {
            ConverterProperties properties = new ConverterProperties();
            properties.SetFontProvider(new DefaultFontProvider(true, true, true));
            Console.WriteLine(filename);
            Stream stream = new FileStream(filename, FileMode.CreateNew);
            HtmlConverter.ConvertToPdf(html, stream, properties);

            stream.Close();
        }
    }
}
