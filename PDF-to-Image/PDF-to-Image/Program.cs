using Syncfusion.PdfToImageConverter;
using Syncfusion.Drawing;

namespace PDF_to_Image {
    internal class Program {
        static void Main(string[] args) {
            //Initialize PDF to Image converter.
            PdfToImageConverter imageConverter = new PdfToImageConverter();
            //Load the PDF document as a stream.
            FileStream inputStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.ReadWrite);
            imageConverter.Load(inputStream);
            //Convert PDF to Image.
            Stream[] outputStream = imageConverter.Convert(0, imageConverter.PageCount - 1, false, false);
            for (int i = 0; i < outputStream.Length; i++) {
                Image image = Image.FromStream(outputStream[i]);
                using (FileStream stream = new FileStream("sample-" + i + ".png", FileMode.Create, FileAccess.Write)) {
                    byte[] data = image.ImageData;
                    stream.Write(data, 0, data.Length);
                }
            }
        }
    }
}