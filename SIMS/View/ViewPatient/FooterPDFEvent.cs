using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewPatient
{
    class FooterPDFEvent : PdfPageEventHelper
    {
        Font font = new Font(Font.FontFamily.HELVETICA, 14, Font.ITALIC);

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte canvas = writer.DirectContent;
            ColumnText.ShowTextAligned(
              canvas, Element.ALIGN_LEFT,
              new Paragraph("Appointments are a subject to change. Please double check the appointments. This report for was generated on " + DateTime.Now.ToString("MM-dd-yy HH:mm"), font),30, 10, 0
            );
        }
    }
}
