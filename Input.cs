public class Input 
{
    public int GetIntUserInput(int min, int max) 
    {
        bool check = false;
        while (!check) 
        {
            int value;
            check = int.TryParse(Console.ReadLine() ?? "0", out value);
            
            if (!check || (check && (value > max || value < min))) 
            {
                check = false;
                Console.WriteLine("Invalid input, try again.");
            }
            else
            {
                return value;
            }
        }
        
        return 0;
    }
}