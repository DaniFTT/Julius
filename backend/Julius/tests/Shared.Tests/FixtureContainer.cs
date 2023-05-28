using Ardalis.SmartEnum.AutoFixture;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace Julius.Shared.Tests;

public static class FixtureContainer
{
    public static Fixture GetFixtureContainer()
    {
        var output = new Fixture();

        output.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => output.Behaviors.Remove(b));
        output.Behaviors.Add(new OmitOnRecursionBehavior());

        output.Customize(new AutoMoqCustomization() { ConfigureMembers = false });
        output.Customize(new SmartEnumCustomization());

        return output;
    }
}