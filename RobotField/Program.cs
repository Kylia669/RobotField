using System;
using RobotField.Abstractions;
using RobotField.Infrastructure;
using SimpleInjector.Lifestyles;

namespace RobotField
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (var input = Console.OpenStandardInput())
                {
                    using (var output = Console.OpenStandardOutput())
                    {
                        var bootstrapper = new Bootstrapper();
                        var container = bootstrapper.Bootstrap(input, output);
                        using (AsyncScopedLifestyle.BeginScope(container))
                        {
                            var processor = container.GetInstance<IRobotsProcessor>();
                            processor.Process();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                //output to console
                Console.WriteLine("FAIL: {0}", ex.Message);
            }
        }
    }
}
