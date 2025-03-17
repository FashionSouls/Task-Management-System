using System.Text.Json;

public class Data 
{
    public void Save(Task task) 
    {
        // Save task to JSON
        
    }
    
    public List<Task> Load() 
    {
        // Get the list of tasks from the JSON file and store it as a list.
        List<Task> tasks = new List<Task>();
        Task task = new Task("Test", "This is a test task", 2, 1);
    
        tasks.Add(task);
        
        return tasks;
    }
    
    public void Order() 
    {
        // Order list of tasks based on priority and difficulty
    }
}