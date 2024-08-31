namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class RatingDto
    {
        public Guid RatingId { get; set; }

        public string? Comment { get; set; }

        public byte Star { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public PlayerDto Player { get; set; }

        public GameDto Game { get; set; }
    }
}
