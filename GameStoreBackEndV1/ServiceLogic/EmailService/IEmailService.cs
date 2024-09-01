using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Email;

namespace GameStoreBackEndV1.ServiceLogic.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailDto email);
    }
}