namespace Lesson5;

public class TestService
{
    private readonly SecondTestService _secondTestService;

    public TestService(SecondTestService secondTestService)
    {
        _secondTestService = secondTestService;
    }

    public void Foo()
    {
        Console.WriteLine("TestService is doing some work...");
        _secondTestService.SecondFoo();
    }
}