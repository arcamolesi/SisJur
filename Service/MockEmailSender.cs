using Microsoft.AspNetCore.Identity.UI.Services;

namespace SisJur.Service
{
    public class MockEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Você pode logar no console para ver o que seria enviado
            Console.WriteLine($"--- NOVO E-MAIL (MOCK) ---");
            Console.WriteLine($"Para: {email}");
            Console.WriteLine($"Assunto: {subject}");
            // Console.WriteLine(htmlMessage); // Descomente se quiser ver o corpo do e-mail

            // Retorna uma tarefa completa, fingindo que o e-mail foi enviado.
            return Task.CompletedTask;
        }
    }
}
