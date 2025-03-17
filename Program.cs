Input input = new Input();

Main();

void Main() 
{
    Console.Clear();
    Console.WriteLine("Task Management System\n\nYour current task is:");

    Console.WriteLine("1. Tasks\n2. Exit\n\nSelect a number from the list:");
    int value = input.GetIntUserInput(1, 2);
    
    switch (value)
    {
        case 1:
        Tasks();
        break;
        
        case 2:
        Exit();
        break;
        
        default:
        Main();
        break;
    }
}

void Tasks() 
{
    Console.Clear();
    
    Data data = new();
    List<Task> tasks = data.Load();
    
    Console.WriteLine("Tasks\n");
    
    for (int i = 0; i < tasks.Count; i++) 
    {
        Task currentTask = tasks[i];
        Console.WriteLine(i + ". " + currentTask.TaskName);
    }
    
    int max = tasks.Count - 1;
    
    Console.WriteLine("\nSelect a task (0-" + max + "):");
    int index = input.GetIntUserInput(0, max);
    
    TaskSelected(tasks[index]);
    
    Console.ReadLine();
}

void TaskSelected(Task task) 
{
    Console.Clear();
    Console.WriteLine("Task Selected - " + task.TaskName + "\n");
    Console.WriteLine("Name: " + task.TaskName);
    Console.WriteLine("Description: " + task.TaskDescription);
    Console.WriteLine("Priority: " + task.GetPriority());
    Console.WriteLine("Difficulty: " + task.GetDifficulty());
    
    Console.WriteLine("\nActions:");
    if (!task.IsCurrent) 
    {
        Console.WriteLine("1. Set current Task");
    } else 
    {
        Console.WriteLine("1. Deactivate current Task");
    }
    Console.WriteLine("2. Edit Task");
    Console.WriteLine("3. Delete Task\n");
    Console.WriteLine("4. Go Back\n");

    Console.WriteLine("Select an action (1-4)");
    int value = input.GetIntUserInput(1, 4);
    
    if (value == 4) 
    {
        Tasks();
    }
    
    Console.ReadLine();
}

void Exit() 
{
    Environment.Exit(0);
}