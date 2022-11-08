using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace FindMyPubApi.BusinessLogic.Tests;

public abstract class AutoFixtureTestBase
{
    protected readonly IFixture _fixture;

    protected AutoFixtureTestBase()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
    }

    protected T Create<T>() where T : class
    {
        return _fixture.Create<T>();
    }

    protected Mock<T> FreezeMock<T>() where T : class
    {
        return _fixture.Freeze<Mock<T>>();
    }
}
