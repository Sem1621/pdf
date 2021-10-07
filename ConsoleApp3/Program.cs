using System;
using System.IO;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp3
{
    class Program
    {
        public struct Form
        {
            public string name;
            public string surname;
            public int age;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Form form;
            form.name = "sem";
            form.surname = "leon";
            form.age = 21;
            migraPdf(form);
        }

        bool IsAuthenticated() { return true; }

        static PdfDocument CreatePdf()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "TEST PDF";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana",20, XFontStyle.BoldItalic);

            gfx.DrawString("Hello World", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.Center);
            const string filename = "test.pdf";
            document.Save("C:\\Users\\a.leon\\source\\repos\\ConsoleApp3\\ConsoleApp3\\"+filename);
            //Process.Start(filename);
            return document;
        }

        bool CheckSignature(PdfDocument doc) {

            
            return true; 
        }

        void sendPdf() { }

        static PdfDocument CreatePdf(Form form)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "TEST PDF";
                
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana",11, XFontStyle.BoldItalic);

            string content = "name: " + form.name + " surname: " + form.surname + " age: " + form.age;
            gfx.DrawString(content, font, XBrushes.Black,
                new XRect(0, 20, page.Width, 0),
                XStringFormats.BaseLineLeft);
            const string filename = "test.pdf";
            document.Save("C:\\Users\\a.leon\\source\\repos\\ConsoleApp3\\ConsoleApp3\\"+filename);
            //Process.Start(filename);
            return document;
        }

        static void migraPdf(Form form)
        {
            Document document = new Document();
            string content = "name: " + form.name + " surname: " + form.surname + " age: " + form.age;
            document.Info.Title = "TEST PDF";

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph();
            //paragraph.Format.Font.Color = Color.FromCmyk(100, 30, 20, 50);
            paragraph.Format.Font.Color = Color.FromRgb(0, 0, 0);
            paragraph.Format.Font.Size = 16;
            paragraph.AddFormattedText(content);
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(false)
            {
                Document = document
            };
            renderer.RenderDocument();
            string filename = "helloWorld.pdf";
            renderer.PdfDocument.Save("C:\\Users\\a.leon\\source\\repos\\ConsoleApp3\\ConsoleApp3\\" + filename);
        }

    }
}
