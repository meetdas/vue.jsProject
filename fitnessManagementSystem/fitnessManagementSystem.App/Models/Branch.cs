namespace fitnessManagementSystem.App.Models
{
    public class Branch : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TenantId { get; set; }

    }
}
