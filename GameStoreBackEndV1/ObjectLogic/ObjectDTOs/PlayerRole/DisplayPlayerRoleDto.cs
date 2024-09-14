namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayPlayerRoleDto
    {
        public Guid PlayerRoleId { get; set; }

        public DisplayPlayerDto Player { get; set; }

        public DisplayRoleDto Role { get; set; }
    }
}
