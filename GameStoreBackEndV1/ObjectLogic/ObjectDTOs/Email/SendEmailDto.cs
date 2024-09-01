namespace GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Email
{
    public class SendEmailDto
    {
        public string EmailTo { get; set; }

        public string? EmailSubject { get; set; }

        public string? EmailBody { get; set; }
    }
}
