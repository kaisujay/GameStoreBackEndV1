namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayPlayerRoleDto
    {
        public Guid PlayerRoleId { get; set; }

        public PlayerRoleDto Player { get; set; }

        public DisplayRoleDto Role { get; set; }
    }
}
