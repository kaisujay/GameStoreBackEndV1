namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayPlayerDto
    {
        public Guid PlayerId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public float Wallet { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }
    }
}
