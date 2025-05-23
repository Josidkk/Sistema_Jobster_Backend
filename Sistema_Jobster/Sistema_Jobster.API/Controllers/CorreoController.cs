using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace Sistema_Jobster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreoController : ControllerBase
    {
        [HttpPost("Verificacion")]
        public IActionResult EnviarCodigoVerificacion([FromBody] EmailRequest request)
        {
            try
            {
                // Generar el token
                string token = GenerarTokenAleatorio();

                // Configurar cliente SMTP
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("credirapid112@gmail.com", "xdfc blgg vnfm ioje")
                };

                // Crear un cuerpo de correo más atractivo con HTML que incluya el token
                string bodyHtml = $@" 
                <!DOCTYPE html> 
                <html> 
                <head> 
                    <style> 
                        body {{ 
                            font-family: Arial, sans-serif; 
                            line-height: 1.6; 
                            color: #333; 
                        }} 
                        .container {{ 
                            max-width: 600px; 
                            margin: 0 auto; 
                            padding: 20px; 
                            border: 1px solid #ddd; 
                            border-radius: 5px; 
                        }} 
                        .header {{ 
                            background-color: #0066cc; 
                            color: white; 
                            padding: 15px; 
                            text-align: center; 
                            border-radius: 5px 5px 0 0; 
                        }} 
                        .content {{ 
                            padding: 20px; 
                        }} 
                        .token-container {{ 
                            background-color: #f5f5f5; 
                            border: 1px solid #ddd; 
                            border-radius: 5px; 
                            padding: 15px; 
                            margin: 20px 0; 
                            text-align: center; 
                        }} 
                        .token {{ 
                            font-size: 24px; 
                            font-weight: bold; 
                            color: #0066cc; 
                            letter-spacing: 2px; 
                        }} 
                        .footer {{ 
                            text-align: center; 
                            margin-top: 20px; 
                            font-size: 12px; 
                            color: #777; 
                        }} 
                    </style> 
                </head> 
                <body> 
                    <div class='container'> 
                        <div class='header'> 
                            <h2>Sistema Jobster</h2> 
                        </div> 
                        <div class='content'> 
                            <p>Estimado(a) usuario,</p> 
                            <p>Gracias por utilizar nuestros servicios. A continuación, encontrará su código de verificación:</p> 
            
                            <div class='token-container'> 
                                <p>Su código es:</p> 
                                <p class='token'>{token}</p> 
                            </div> 
            
                            <p>Este código es válido por un tiempo limitado. Por favor, no comparta este código con nadie.</p> 
                            <p>Si usted no solicitó este código, por favor ignore este mensaje.</p> 
                        </div> 
                        <div class='footer'> 
                            <p>Este es un correo automático, por favor no responda a este mensaje.</p> 
                            <p>&copy; {DateTime.Now.Year} Sistema Jobster. Todos los derechos reservados.</p> 
                        </div> 
                    </div> 
                </body> 
                </html>";

                // Crear mensaje de correo
                MailMessage correo = new MailMessage
                {
                    From = new MailAddress("credirapid112@gmail.com"),
                    Subject = "Jobster - Codigo Verificacion",
                    Body = bodyHtml,
                    IsBodyHtml = true
                };
                correo.To.Add(request.Destinatario);

                // Enviar correo
                smtp.Send(correo);

                // Retornar el código generado
                return Ok(new
                {
                    success = true,
                    message = "Código enviado correctamente",
                    codigo = token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = $"Error al enviar el correo: {ex.Message}"
                });
            }
        }

        public class EmailRequest
        {
            public string Destinatario { get; set; }
            public string Asunto { get; set; }
        }

        private string GenerarTokenAleatorio()
        {
            Random random = new Random();
            int codigo = random.Next(100000, 999999);
            return codigo.ToString();
        }
    }
}