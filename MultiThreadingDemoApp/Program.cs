// See https://aka.ms/new-console-template for more information
using MultiThreadingDemoLib;

var myClass = new Class1();

Console.WriteLine("Starting app on thread: " + Environment.CurrentManagedThreadId);

//await Task.Run(() => myClass.DoWork()).ConfigureAwait(false);
//  var thread = new Thread(myClass.DoWork);
//  thread.IsBackground = true; 
//  thread.Start();

//  thread.Join();

var doneEvent = new ManualResetEvent(false);

ThreadPool.QueueUserWorkItem((state) => {
    myClass.DoWork();
    
    callback(state);

    doneEvent.Set();
});

void callback(object? state)
{
    Console.WriteLine("Callback called on thread: " + Environment.CurrentManagedThreadId);
}

doneEvent.WaitOne();

Console.WriteLine("App finished on thread: " + Environment.CurrentManagedThreadId);