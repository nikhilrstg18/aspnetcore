using Org.Project.Application.Models.Mail;
using System.Threading.Tasks;

namespace Org.Project.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
