using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Source https://stackoverflow.com/questions/2372041/c-sharp-itextsharp-pdf-creation-with-watermark-on-each-page
namespace SIMS.View.ViewPatient
{
    class PDFWaterMarkEvent : IPdfPageEvent
    {
        string watermarkText = string.Empty;

        public PDFWaterMarkEvent(string watermark)
        {
            watermarkText = watermark;
        }

        public void OnOpenDocument(PdfWriter writer, Document document) { }
        public void OnCloseDocument(PdfWriter writer, Document document) { }
        public void OnStartPage(PdfWriter writer, Document document)
        {
            float fontSize = 80;
            float xPosition = 200;
            float yPosition = 300;
            float angle = 45;
            try
            {
                PdfContentByte under = writer.DirectContentUnder;
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                under.BeginText();
                under.SetColorFill(BaseColor.LIGHT_GRAY);
                under.SetFontAndSize(baseFont, fontSize);
                under.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, xPosition, yPosition, angle);
                under.EndText();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
        public void OnEndPage(PdfWriter writer, Document document) {
            Font font = new Font(Font.FontFamily.HELVETICA, 14, Font.ITALIC);
            PdfContentByte canvas = writer.DirectContent;
            ColumnText.ShowTextAligned(
              canvas, Element.ALIGN_LEFT,
              new Paragraph("Appointments are a subject to change. Please double check the appointments. This report for was generated on " + DateTime.Now.ToString("MM-dd-yy HH:mm"), font), 30, 10, 0
            );
        }
        public void OnParagraph(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title) { }
        public void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title) { }
        public void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, String text) { }

     
    }
}
