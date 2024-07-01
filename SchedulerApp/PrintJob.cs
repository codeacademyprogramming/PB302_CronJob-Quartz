using Quartz;

namespace SchedulerApp
{
    public class PrintJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("======="+DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")+"========");
            return Task.CompletedTask;
        }
    }
}
