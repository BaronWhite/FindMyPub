using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Repositories;
using FindMyPubApi.BusinessLogic.Services;
using FluentAssertions;
using Moq;

namespace FindMyPubApi.BusinessLogic.Tests.Services;

public class PubServiceTests : AutoFixtureTestBase
{
    private readonly PubService _sut;

    public PubServiceTests()
    {
        var mockRepository = FreezeMock<IEntityRepository<Pub>>();
        mockRepository.Setup(repository => repository.Get()).ReturnsAsync(MockPubs);
        _sut = Create<PubService>();
    }

    [Theory]
    [InlineData(null, new[] { 0, 1, 2 })]
    [InlineData("", new[] { 0, 1, 2 })]
    [InlineData("QU", new[] { 0 })]
    [InlineData("qu", new[] { 0 })]
    [InlineData("aD", new[] { 0 })]
    [InlineData("s h", new[] { 0 })]
    [InlineData("AW", new[] { 1, 2 })]
    public async Task GetWithName_ReturnsPubsContainingSearchStringInName(string searchString, int[] expectedPubIndexes)
    {
        var expected = MockPubs.Where((pub, i) => expectedPubIndexes.Contains(i));
        var actual = await _sut.GetWithName(searchString);

        actual.Should().Contain(expected);
    }

    private readonly List<Pub> MockPubs = new()
    {
        new Pub() { Name = "Queens Head" },
        new Pub() { Name = "Foxes Paw" },
        new Pub() { Name = "Meaw meaw" },
    };
}
