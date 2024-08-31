namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayRatingDto
    {
        public Guid RatingId { get; set; }

        public string? Comment { get; set; }

        public byte Star { get; set; }

        public DisplayPlayerDto Player { get; set; }

        public DisplayGameDto Game { get; set; }
    }
}
