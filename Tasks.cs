public class Task 
{
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public bool IsCurrent { get; set; }
    public int Difficulty { get; set; } // 0 - Easy / 1 - Medium / 2 - Hard
    public int Priority { get; set; } // 0 - Low / 1 - Medium / 2 - High 
    
    public Task(string taskName, string taskDescription, int difficulty, int priority) 
    {
        this.TaskName = taskName;
        this.TaskDescription = taskDescription;
        this.IsCurrent = false;
        this.Difficulty = difficulty;
        this.Priority = priority;
    }
    
    public string GetDifficulty() 
    {
        switch (Difficulty)
        {
            case 0:
            return "Easy";
            
            case 1:
            return "Medium";
            
            case 2:
            return "Hard";
            
            default:
            return "Other";
        }
    }
    
    public string GetPriority() 
    {
        switch (Priority)
        {
            case 0:
            return "Low";
            
            case 1:
            return "Medium";
            
            case 2:
            return "High";
            
            default:
            return "Other";
        }
    } 
}