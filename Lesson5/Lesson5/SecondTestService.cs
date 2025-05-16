namespace Lesson5;

public class SecondTestService
{
    public void SecondFoo()
    {
            Console.WriteLine("SecondTestService is doing some work...");
            throw new Exception("An error occurred in SecondTestService.");
    }
}