﻿namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class OrderHistoryDto
    {
        public Guid OrderHistoryId { get; set; }

        public Guid PlayerId { get; set; }

        public List<Guid> GameId { get; set; }

        public PlayerDto Player { get; set; }

        public List<GameDto> Games { get; set; }

        public DateTime PurchaseDate { get; set; }

        public float PurchaseAmmount { get; set; }
    }
}
