namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayRatingDto
    {
        public Guid RatingId { get; set; }

        public string? Comment { get; set; }

        public byte Star { get; set; }

        public Guid PlayerId { get; set; }

        public string PlayerName { get; set; }

        public string PlayerEmail { get; set; }

        public Guid GameId { get; set; }

        public string GameName { get; set; }
    }
}
