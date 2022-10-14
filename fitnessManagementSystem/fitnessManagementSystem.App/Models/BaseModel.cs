namespace fitnessManagementSystem.App.Models
{
    public class BaseModel
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual int? UpdatedBy { get; set; }
    }
}
