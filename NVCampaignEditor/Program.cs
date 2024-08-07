using NVCampaignEditor.Command;
using NVCampaignEditor.Util;
using System.Reflection;

namespace NVCampaignEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EntryCommand entry = new EntryCommand();
            Startup();
            Loop();

            void Startup()
            {
                Assembly assembly = Assembly.GetEntryAssembly();
                if (assembly == null) { Environment.Exit(1); return; }

                AssemblyName name = assembly.GetName();
                Version v = name.Version;


                Console.WriteLine(name.Name + " Version " + v);
            }

            void Loop()
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter a command, or \"help\" for help");
                    Console.WriteLine();

                    string[] args = StringUtils.ParseArgs(Console.ReadLine());

                    try
                    {
                        entry.Invoke(args);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine();
                        Console.WriteLine($"Command failed due to {e.GetType()} with message {e.Message}");
                    }
                }
            }
        }
    }
}
