using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

public class Data 
{
    const string taskFile = "data/tasks.json";
    
    public void SaveTask(Task task) 
    {
        // Save task to JSON
        List<Task> tasks = Load();
        
        tasks.Add(task);
        
        if (File.Exists(taskFile)) 
        {
            string jsonString = JsonSerializer.Serialize<List<Task>>(tasks);
            
            File.WriteAllText(taskFile, jsonString);
        } else 
        {
            // Create new JSON file
        }
    }
    
    public List<Task> Load() 
    {
        // Get the list of tasks from the JSON file and store it as a list.
        List<Task> tasks = new List<Task>();
        
        try 
        {
            if (File.Exists(taskFile)) 
            {
                if (new FileInfo(taskFile).Length == 0) 
                {
                    Console.WriteLine("There are currently no tasks.");
                    return tasks;
                } else 
                {
                    string jsonString = File.ReadAllText(taskFile);
                    tasks = JsonSerializer.Deserialize<List<Task>>(jsonString) ?? new List<Task>();
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("HTTP Request Error: " + ex.Message);
        }
        catch (JsonException ex)
        {
            Console.WriteLine("JSON Parsing Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        
        return tasks;
    }
    
    public void DeleteTask(int id) 
    {
        List<Task> tasks = Load();
        
        int index = tasks.FindIndex(a => a.Id == id);
        
        tasks.RemoveAt(index);
        
        try 
        {
            if (File.Exists(taskFile)) 
            {
                string jsonString = JsonSerializer.Serialize(tasks);
                
                File.WriteAllText(taskFile, jsonString);
            }
        } catch 
        {
            Console.WriteLine("Delete Task Error");
        }
        
    }
    
    public Task GetTask(int id) 
    {
        List<Task> tasks = Load();
        
        int index = tasks.FindIndex(a => a.Id == id);
        
        Task newTask = tasks[index];
        
        return newTask;
    }
    
    public int NextId() 
    {
        List<Task> tasks = Load();
        
        return tasks.Count + 1;
    }
    
    public void Order() 
    {
        // Order list of tasks based on priority and difficulty
    }
}