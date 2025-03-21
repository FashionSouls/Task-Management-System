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
    
    public string GetUserInput() 
    {
        bool check = false;
        while (!check) 
        {
            string value;
            value = Console.ReadLine() ?? "";
            
            if (value.Equals("")) 
            {
                check = false;
                Console.WriteLine("Nothingt entered, try again.");
            }
            else
            {
                return value;
            }
        }
        
        return "";
    }
    
    public bool GetConfirmation() 
    {
        bool check = false;
        while (!check) 
        {
            string value;
            value = Console.ReadLine() ?? "";
            
            if (value.Equals("")) 
            {
                check = false;
                Console.WriteLine("Nothing entered, try again.");
            }
            else if (value == "y" || value == "Y")
            {
                return true;
            } else if (value == "n" || value == "N") 
            {
                return false;
            } else 
            {
                check = false;
                Console.WriteLine("Invalid input, try again.");
            }
        }
        
        return false;
    }
}