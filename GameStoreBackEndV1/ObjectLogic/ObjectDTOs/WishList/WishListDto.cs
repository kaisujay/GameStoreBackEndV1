﻿namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class WishListDto
    {
        public Guid WishListId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public PlayerDto Player { get; set; }

        public GameDto Game { get; set; }
    }
}
