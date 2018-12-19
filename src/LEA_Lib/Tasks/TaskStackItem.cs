using System.Threading.Tasks;

namespace LEA.Lib.Tasks
{
    public class TaskStackItem
    {
        public double timestamp { get; set; }
        public string taskKey { get; set; }
        public Task task { get; set; }
    }
}
