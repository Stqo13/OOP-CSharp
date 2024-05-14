namespace AuthorProblem
{
    [Author("Viktor")]
    public class StartUp
    {
        [Author("Georgi")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}