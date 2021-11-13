using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;

using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanelApi.EmailSender
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendWelcomeEmailAsync(MailRequest mailRequest);
    }
}
