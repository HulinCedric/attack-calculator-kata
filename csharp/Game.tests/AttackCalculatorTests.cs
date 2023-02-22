using FluentAssertions;
using Xunit;

namespace Game.tests
{
    public class AttackCalculatorTests 
    {
        [Fact]
        public void ThisTestShouldPass()
        {
            0.Should().Be(0);
        }

       [Fact]
        public void ThisTestShouldFail()
        {          
            0.Should().Be(42);
        }
    }
}
