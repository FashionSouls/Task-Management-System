Console.Clear();

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
    Console.WriteLine("Tasks");
    Console.ReadLine();
}

void Exit() 
{
    Environment.Exit(0);
}