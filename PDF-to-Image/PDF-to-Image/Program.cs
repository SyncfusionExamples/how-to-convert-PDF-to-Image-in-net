using Syncfusion.PdfToImageConverter;

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
                File.WriteAllBytes("sample-" + i + ".png", (outputStream[i] as MemoryStream).ToArray());                
            }
        }
    }
}