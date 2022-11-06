using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Repositories;
using FindMyPubApi.BusinessLogic.Services;
using FluentAssertions;
using Moq;

namespace FindMyPubApi.BusinessLogic.Tests.Services;

public class EntityServiceTests : AutoFixtureTestBase
{
    private readonly EntityService<Entity> _sut;
    private readonly Mock<IEntityRepository<Entity>> _mockRepository;

    public EntityServiceTests()
    {
        _mockRepository = FreezeMock<IEntityRepository<Entity>>();
        _mockRepository.Setup(repository => repository.Get()).ReturnsAsync(MockEntities);
        _mockRepository.Setup(repository => repository.GetById(It.IsAny<long>()))!.ReturnsAsync((long id) => MockEntities.FirstOrDefault(entity => entity.Id == id));
        _sut = Create<EntityService<Entity>>();
    }

    [Fact]
    public async Task Create_CallsRepositoryCreate()
    {
        var entity = new Entity();
        await _sut.Create(entity);

        _mockRepository.Verify(repository => repository.Create(entity), Times.Once);
    }

    [Fact]
    public async Task Update_CallsRepositoryUpdate()
    {
        var entity = new Entity() { Id = 3 };
        await _sut.Update(entity.Id, entity);

        _mockRepository.Verify(repository => repository.Update(entity.Id, entity), Times.Once);
    }

    [Fact]
    public async Task Get_GetsAllEntities()
    {
        var actual = await _sut.Get();

        actual.Should().BeEquivalentTo(MockEntities);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 2)]
    [InlineData(3, 1)]
    public async Task GetById_GetsEntityWithGivenId(long id, int mockListIndex)
    {
        var expected = MockEntities[mockListIndex];
        var actual = await _sut.GetById(id);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Delete_CallsRepositoryDelete()
    {
        const long entityId = 3;
        await _sut.Delete(entityId);

        _mockRepository.Verify(repository => repository.Delete(entityId), Times.Once);
    }

    private static readonly List<Entity> MockEntities = new()
    {
        new Entity() { Id = 1 },
        new Entity() { Id = 3 },
        new Entity() { Id = 2 },
    };
}
