namespace Treaning.WebAPI.Models
{
    public class RegisterDetail
    {
        public long Id { get; set; }

        public long?  TreaningInfoId { get; set; }
        public virtual TreaningInfo TreaningInfo { get; set; } = null!;

        public long? StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;

        public bool Payment { get; set; }

        public RegisterDetail()
        {
            Student = new Student();
            TreaningInfo = new TreaningInfo();
        }
    }
}
