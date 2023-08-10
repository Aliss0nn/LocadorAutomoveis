using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Color = iText.Kernel.Colors.Color;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using LocadorAutomoveis.Dominio.ModuloAluguel;

namespace LocadorAutomoveis.Infra.Arquivos
{
    public class PdfEmail
    {


        public static void EnviarEmail(Aluguel aluguel, string email, string senha)
        {
            MemoryStream ms = new MemoryStream();
            string fileName = aluguel.ToString() + ".pdf";
            PdfWriter writer = new PdfWriter(ms);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            document.Add(new Paragraph($"Cliente: {aluguel.Cliente}").SetFontSize(24));
            document.Add(new Paragraph($"Automovel: {aluguel.Automovel}").SetFontSize(24));
            document.Add(new Paragraph($"Data Locação: {aluguel.DataLocacao.ToString()}").SetFontSize(24));
            document.Add(new Paragraph($"Data Prevista: {aluguel.DataPrevisao.ToString()}").SetFontSize(24));
            document.Add(new Paragraph($"Data Devolução: {aluguel.DataDevolucao.ToString()}").SetFontSize(24));
            document.Add(new Paragraph($"Valor a Pagar R$: {aluguel.Preco}").SetFontSize(24));
            document.Flush();
            writer.Flush();
            ms.Position = 0;

            var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(email, senha);

            var mailMessage = new MailMessage(email, aluguel.Cliente.Email, "PDF Aluguel", "Veja o PDF em anexo.");
            var attachment = new Attachment(ms, fileName, "application/pdf");
            mailMessage.Attachments.Add(attachment);

            smtpClient.Send(mailMessage);
                 
            
        }
    }
}
