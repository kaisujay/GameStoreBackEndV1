namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class PlayerRoleTableDto     //This DTO is used for Mapping with Table for Save data.
    {
        public Guid PlayerRoleId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid RoleId { get; set; }
    }
}
