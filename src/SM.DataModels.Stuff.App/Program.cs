using Microsoft.Extensions.CommandLineUtils;

namespace SM.DataModels.Stuff.App
{
	public class Program
    {
        public static void Main(string[] args)
        {
	        var app = new CommandLineApplication();

	        app.Execute(args);
        }
    }
}