﻿namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayWishListDto
    {
        public DisplayPlayerDto Player { get; set; }

        public List<DisplayGameDto> Games { get; set; }
    }
}
