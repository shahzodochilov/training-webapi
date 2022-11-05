namespace Treaning.WebAPI.Models
{
    public class TreaningInfo
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateOnly StartedDate { get; set; }

        public int Duration { get; set; }

        public int NumberLesson { get; set; }

        public string? Theme { get; set; }

        public double Price { get; set; }
    }
}
