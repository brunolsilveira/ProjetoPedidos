using AutoFixture;
using AutoMapper;
using ProjPedidos.Application.Common.Interfaces;
using ProjPedidos.Application;
using ProjPedidos.Infrastructure.Data;
using ProjPedidos.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjPedidos.Application.Common.Mappings;
using System.Diagnostics.CodeAnalysis;

namespace ProjPedidos.Unittest;

[ExcludeFromCodeCoverage]
public class SetupTest : IDisposable
{

    protected readonly IMapper _mapperConfig;
    protected readonly Fixture _fixture;
    protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
    protected readonly ApplicationDbContext _dbContext;
    protected readonly Mock<IPedidoService> _pedidoServiceMock;
    protected readonly Mock<ICurrentTime> _currentTimeMock;
    protected readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
    protected readonly Mock<IUserRepository> _userRepository;

    public SetupTest()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapProfile());
        });
        _mapperConfig = mappingConfig.CreateMapper();
        _fixture = new Fixture();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _pedidoServiceMock = new Mock<IPedidoService>();
        _currentTimeMock = new Mock<ICurrentTime>();
        _pedidoRepositoryMock = new Mock<IPedidoRepository>();
        _userRepository = new Mock<IUserRepository>();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _dbContext = new ApplicationDbContext(options);

        _currentTimeMock.Setup(x => x.GetCurrentTime()).Returns(DateTime.UtcNow);
    }
    public void Dispose() => _dbContext.Dispose();
}
