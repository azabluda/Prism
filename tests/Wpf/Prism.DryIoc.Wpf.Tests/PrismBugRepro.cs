using DryIoc;
using Prism.Ioc;
using Xunit;

namespace Prism.DryIoc.Wpf.Tests
{
    public class PrismBugRepro
    {
        [StaFact]
        public void TransientDelegateRegistration()
        {
            // Arrange
            global::DryIoc.Container container = new(Rules.Default.WithDefaultReuse(Reuse.Singleton));
            DryIocContainerExtension containerExtension = new(container);
            int counter = 0;
            containerExtension.Register<int>(_ => ++counter);

            // Act
            int a = containerExtension.Resolve<int>();
            int b = containerExtension.Resolve<int>();

            // Assert
            Assert.Equal(a + 1, b);
        }
    }
}
