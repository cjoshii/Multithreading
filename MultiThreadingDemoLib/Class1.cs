namespace MultiThreadingDemoLib;

public class Class1
{
    public void DoWork()
    {
       
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine("Doing work " +i+1+ " on thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
        }
       
    }
}
