public class TaskInfo
{
    public int TaskId { get; set; }
    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public long Duration => EndTime - StartTime;
}