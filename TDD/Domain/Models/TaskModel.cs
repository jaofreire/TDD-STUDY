namespace Domain.Models
{
    public class TaskModel
    {
        public TaskModel(string? title, string? description, DateTime experateDate, int priority, List<string>? tickets)
        {
            Title = title;
            Description = description;
            ExperateDate = experateDate;
            Priority = priority;
            Tickets = tickets;
        }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime ExperateDate { get; set; }
        public int Priority { get; set; }
        public List<string>? Tickets { get; set; }


    }
}
