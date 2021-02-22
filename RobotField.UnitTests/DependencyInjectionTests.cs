using System.IO;
using RobotField.Abstractions;
using RobotField.Infrastructure;
using SimpleInjector.Lifestyles;
using Xunit;

namespace RobotField.UnitTests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void Bootstrapper_Should_ReturnValidContainer()
        {
            var bootstrapper = new Bootstrapper();
            var input = new MemoryStream();
            var output = new MemoryStream();
            var container = bootstrapper.Bootstrap(input, output);

            using (AsyncScopedLifestyle.BeginScope(container))
            {
                var processor = container.GetInstance<IRobotsProcessor>();
            }

        }
    }
}
