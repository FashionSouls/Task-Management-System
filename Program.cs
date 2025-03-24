Input input = new();
Data data = new();

Main();

void Main() 
{
    Console.Clear();
    
    string currentTaskName = "";
    
    try 
    {
        List<Task> tasks = data.Load();
        
        for (int i = 0; i < tasks.Count; i++) 
        {
            if (tasks[i].IsCurrent) 
            {
                currentTaskName = tasks[i].TaskName;
                break;
            }
        }
    } catch 
    {
        Console.WriteLine("Failed to get current task.");
    }
    
    Console.WriteLine("Task Management System\n\nYour current task is: " + currentTaskName);
    
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
    
    List<Task> tasks =new List<Task>();
    try 
    {
        tasks = data.Load();
    
        Console.WriteLine("Tasks\n");
        
        for (int i = 0; i < tasks.Count; i++) 
        {
            Task currentTask = tasks[i];
            if (currentTask.IsCurrent) 
            {
                Console.WriteLine(i + ". " + currentTask.TaskName + " (current)");
            } else 
            {
                Console.WriteLine(i + ". " + currentTask.TaskName);
            }
        }
        
        int max = tasks.Count - 1;
        
        Console.WriteLine("---\n1. Select a task");
        Console.WriteLine("2. Add a new task");
        Console.WriteLine("\n3. Go back");
        
        int value = input.GetIntUserInput(1, 3);
        
        if (value == 1) 
        {
            Console.WriteLine("\nSelect the task number (0-" + max + "):");
            int index = input.GetIntUserInput(0, tasks.Count);
            
            TaskSelected(tasks[index]);
        } else if (value == 2)
        {
            CreateTask();
        } else 
        {
            Main();
        }
        
        
    } catch 
    {
        Console.WriteLine("Failed to load tasks");
    }
    
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
    
    if (value == 1) 
    {
        data.DeleteTask(task.Id);
        task.IsCurrent = !task.IsCurrent;
        data.SaveTask(task);
        TaskSelected(task);
    } else if (value == 2) 
    {
        EditTask(task);
    } else if (value == 3) 
    {
        data.DeleteTask(task.Id);
        Tasks();
    } else if (value == 4) 
    {
        Tasks();
    }
    
    Console.ReadLine();
}

void CreateTask() 
{
    Console.Clear();
    Console.WriteLine("Create a task");
    Console.WriteLine("\nEnter the name of the task:");
    string taskName = input.GetUserInput();
    
    Console.WriteLine("Enter the task description:");
    string taskDescription = input.GetUserInput();  
    
    Console.WriteLine("Enter the task difficulty (0-2):");
    Console.WriteLine("0 - Easy / 1 - Medium / 2 - Hard");
    int difficulty = input.GetIntUserInput(0, 2);
    
    Console.WriteLine("Enter the task priority (0-2):");
    Console.WriteLine("0 - Low / 1 - Medium / 2 - High");
    int priority = input.GetIntUserInput(0, 2);
    
    Console.WriteLine("\nCreate task (y/n)?");
    bool confirmation = input.GetConfirmation();
    
    if (confirmation) 
    {
        Task newTask = new Task(data.NextId(), taskName, taskDescription, difficulty, priority); 
        
        try 
        {
            data.SaveTask(newTask);
            Console.WriteLine("Saved new task! Press any key to return to the Tasks list.");
        } catch 
        {
            Console.WriteLine("Failed to save new task. Press any key to return to the Tasks list.");
        }
        
    } else 
    {
        Console.WriteLine("New task creation cancelled. Press any key to return to the Tasks list.");
    }
    
    Console.ReadKey();
    Tasks();
}

void EditTask(Task task) 
{
    Console.Clear();
    Console.WriteLine("Edit task - " + task.TaskName + "\n");
    Console.WriteLine("Name: " + task.TaskName);
    Console.WriteLine("Description: " + task.TaskDescription);
    Console.WriteLine("Priority: " + task.GetPriority());
    Console.WriteLine("Difficulty: " + task.GetDifficulty());
    
    Console.WriteLine("\nActions:");
    Console.WriteLine("1. Change name");
    Console.WriteLine("2. Change description");
    Console.WriteLine("3. Change priority");
    Console.WriteLine("4. Change difficulty\n");
    Console.WriteLine("5. Save");
    Console.WriteLine("6. Go back\n");
    
    Console.WriteLine("Select an action (1-6)");
    int action = input.GetIntUserInput(1, 6);
    
    if (action == 1) 
    {
        Console.WriteLine("Enter new name:");
        task.TaskName = input.GetUserInput();
        EditTask(task);
    } else if (action == 2) 
    {
        Console.WriteLine("Enter new description:");
        task.TaskDescription = input.GetUserInput();
        EditTask(task);
    } else if (action == 3) 
    {
        Console.WriteLine("Enter the task priority (0-2):");
        Console.WriteLine("0 - Low / 1 - Medium / 2 - High");
        task.Priority = input.GetIntUserInput(0, 2);
        EditTask(task);
    } else if (action == 4)
    {
        Console.WriteLine("Enter the task difficulty (0-2):");
        Console.WriteLine("0 - Easy / 1 - Medium / 2 - Hard");
        task.Difficulty = input.GetIntUserInput(0, 2);
    } else if (action == 5) 
    {
        Console.WriteLine("Save this task? (y/n)");
        bool confirmation = input.GetConfirmation();
        if (confirmation) 
        {
            data.DeleteTask(task.Id);
            data.SaveTask(task);
            TaskSelected(task);
        } else 
        {
            EditTask(task);
        }
    } else 
    {
        Console.WriteLine("Are you sure you want to go back? You will lose any unsaved progress. (y/n)");
        bool confirmation = input.GetConfirmation();
        if (confirmation) 
        {
            Task oldTask = data.GetTask(task.Id);
            TaskSelected(oldTask);
        }
    }
}

void Exit() 
{
    Environment.Exit(0);
}