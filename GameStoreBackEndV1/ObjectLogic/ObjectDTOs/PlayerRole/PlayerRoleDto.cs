namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class PlayerRoleDto
    {
        public Guid PlayerRoleId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid RoleId { get; set; }

        public PlayerDto Player { get; set; }

        public RoleDto Role { get; set; }
    }
}
