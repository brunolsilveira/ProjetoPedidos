using System.Linq.Expressions;
using AutoMapper;
using ProjPedidos.Application;
using ProjPedidos.Application.Common.Models;
using ProjPedidos.Application.Common.Models.Pedido;
using ProjPedidos.Application.Services;
using ProjPedidos.Domain.Entities;
using Moq;

namespace ProjPedidos.Unittest.Application.Services;

public class PedidoTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
    private PedidoService _pedidoService;

    private List<ItensPedidoResultDTO> _ItensPedido1 = new List<ItensPedidoResultDTO>()
    {
        new ItensPedidoResultDTO
        {
            Id = 1,
            IdProduto = 1,
            NomeProduto = "",
            ValorUnitario = 19.99M,
            Quantidade = 1
        },
        new ItensPedidoResultDTO
        {
            Id = 1,
            IdProduto =2,
            NomeProduto = "",
            ValorUnitario = 29.99M,
            Quantidade = 2
        }
    };

    private Pedido _Pedido1 = new Pedido
    {
        Id = 1,
        NomeCliente = "Cliente 1",
        EmailCliente = "Email 1",
        DataCriacao = new DateTime(2024, 10, 1),
        Pago = true,
        ItensPedido = new List<ItensPedido>()
        {
            new ItensPedido
            {
                Id = 1,
                IdProduto = 1,
                Quantidade = 1,
                Produto = new Produto()
                {
                    Valor = 1
                }
            },
            new ItensPedido
            {
                Id = 1,
                IdProduto =2,
                Quantidade = 2,
                Produto = new Produto()
                {
                    Valor = 2
                }
            }
        }
    };

    private PedidoResultDTO _PedidoResultDTO1 = new PedidoResultDTO
    {
        Id = 1,
        NomeCliente = "Cliente 1",
        EmailCliente = "Email 1",
        Pago = true,
        ValorTotal = 10,
        ItensPedido = new List<ItensPedidoResultDTO>()
        {
            new ItensPedidoResultDTO
            {
                Id = 1,
                IdProduto = 1,
                NomeProduto = "",
                ValorUnitario = 19.99M,
                Quantidade = 1
            },
            new ItensPedidoResultDTO
            {
                Id = 1,
                IdProduto =2,
                NomeProduto = "",
                ValorUnitario = 29.99M,
                Quantidade = 2
            }
        }
    };

    [Fact]
    public async Task PedidoService_GetById_ShouldReturnAPedido()
    {
        // Arrange
        int pedidoId = 1;
        var expectedResult = _Pedido1;
        string[] includes = { "ItensPedido", "ItensPedido.Produto" };
        _unitOfWorkMock.Setup(u => u.PedidoRepository.FirstOrDefaultAsync(b => b.Id == pedidoId, includes))
                       .ReturnsAsync(expectedResult);

        _pedidoService = new PedidoService(_unitOfWorkMock.Object, _mapperMock.Object);


        // Act
        var actualResult = await _pedidoService.Get(pedidoId);

        // Assert
        Assert.Equal(expectedResult.Id, actualResult.Id);
        Assert.Equal(expectedResult.NomeCliente, actualResult.NomeCliente);
        Assert.Equal(expectedResult.EmailCliente, actualResult.EmailCliente);
        Assert.Equal(expectedResult.Pago, actualResult.Pago);
    }

    [Fact]
    public async Task PedidoService_Get_ShouldReturnPedidos()
    {
        // Arrange
        var expected = new List<PedidoResultDTO>
        {
            _PedidoResultDTO1,
            new PedidoResultDTO
            {
                Id = 2,
                NomeCliente =  "ASP.NET Core Development",
                EmailCliente =  "Learn how to build web applications using ASP.NET Core.",
                Pago = true
            }
        };

        var expectedResult = new Pagination<PedidoResultDTO>
        {
            TotalItemsCount = expected.Count,
            PageSize = 2,
            PageIndex = 0,
            Items = expected
        };

        // Setup the mock for the repository's ToPagination method
        _unitOfWorkMock
            .Setup(u => u.PedidoRepository.GetAsync<PedidoResultDTO>(
                It.IsAny<Expression<Func<Pedido, bool>>>(),
                It.IsAny<Expression<Func<Pedido, PedidoResultDTO>>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Expression<Func<Pedido, object>>>(),
                It.IsAny<bool>()))
            .ReturnsAsync(expectedResult);

        _pedidoService = new PedidoService(_unitOfWorkMock.Object, _mapperMock.Object);

        // Act
        var actualResult = await _pedidoService.Get(0, 2, _Pedido1.DataCriacao.Year);

        // Assert
        Assert.NotNull(actualResult);
        Assert.Equal(expectedResult.TotalItemsCount, actualResult.TotalItemsCount);
        Assert.Equal(expectedResult.TotalPagesCount, actualResult.TotalPagesCount);
        Assert.Equal(expectedResult.Items.Count, actualResult.Items.Count);


        var expect = expectedResult.Items.ToList();
        var actual = actualResult.Items.ToList();

        for (int i = 0; i < expectedResult.Items.Count; i++)
        {
            Assert.Equal(expect[i].Id, actual[i].Id);
            Assert.Equal(expect[i].NomeCliente, actual[i].NomeCliente);
            Assert.Equal(expect[i].EmailCliente, actual[i].EmailCliente);
            Assert.Equal(expect[i].Pago, actual[i].Pago);
        }
    }

    [Fact]
    public async Task PedidoService_Add_ShouldAddPedido()
    {
        // Arrange
        var pedidoDTO = new PedidoDTO
        {
            NomeCliente = "New Pedido",
            EmailCliente = "A new pedido description.",
            Pago = true
        };

        var pedido = _Pedido1;

        _mapperMock.Setup(m => m.Map<Pedido>(pedidoDTO)).Returns(pedido);

        _unitOfWorkMock.Setup(u => u.PedidoRepository.AddAsync(It.IsAny<Pedido>())).Returns(Task.CompletedTask);

        // Initialize the PedidoService with the mocked unit of work and mapper
        _pedidoService = new PedidoService(_unitOfWorkMock.Object, _mapperMock.Object);

        // Act
        await _pedidoService.Add(pedidoDTO, CancellationToken.None);

        // Assert
        //_unitOfWorkMock.Verify(u => u.PedidoRepository.AddAsync(It.Is<Pedido>(b => b.NomeCliente = = pedidoDTO.Title)), Times.Once);
        _unitOfWorkMock.Verify(u => u.ExecuteTransactionAsync(It.IsAny<Func<Task>>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task PedidoService_Update_ShouldUpdatePedido()
    {
        // Arrange
        var existingPedido = _Pedido1;

        var updateRequest = new Pedido
        {
            Id = 1,
            NomeCliente = "Updated Pedido",
            EmailCliente = "An updated pedido description.",
            Pago = true
        };

        _unitOfWorkMock.Setup(u => u.PedidoRepository.FirstOrDefaultAsync(It.IsAny<Expression<Func<Pedido, bool>>>(), null))
                       .ReturnsAsync(existingPedido);

        //_unitOfWorkMock.Setup(u => u.PedidoRepository.Update(It.IsAny<Pedido>())).Returns(Task.CompletedTask);

        // Initialize the PedidoService with the mocked unit of work
        _pedidoService = new PedidoService(_unitOfWorkMock.Object, _mapperMock.Object);

        // Act
        await _pedidoService.Update(updateRequest, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(u => u.PedidoRepository.FirstOrDefaultAsync(It.IsAny<Expression<Func<Pedido, bool>>>(), null), Times.Once);
        //_unitOfWorkMock.Verify(u => u.PedidoRepository.Update(It.Is<Pedido>(b => b.Id == updateRequest.Id)), Times.Once);
        //_unitOfWorkMock.Verify(u => u.ExecuteTransactionAsync(It.IsAny<Func<Task>>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task PedidoService_Delete_ShouldRemovePedido()
    {
        // Arrange
        var pedidoId = 1;
        var pedidoToDelete = _Pedido1;

        _unitOfWorkMock.Setup(u => u.PedidoRepository.FirstOrDefaultAsync(It.IsAny<Expression<Func<Pedido, bool>>>(), null))
                       .ReturnsAsync(pedidoToDelete);

        //_unitOfWorkMock.Setup(u => u.PedidoRepository.Delete(It.IsAny<Pedido>())).Returns(Task.CompletedTask);

        // Initialize the PedidoService with the mocked unit of work
        _pedidoService = new PedidoService(_unitOfWorkMock.Object, _mapperMock.Object);

        // Act
        await _pedidoService.Delete(pedidoId, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(u => u.PedidoRepository.FirstOrDefaultAsync(It.IsAny<Expression<Func<Pedido, bool>>>(), null), Times.Once);
        //_unitOfWorkMock.Verify(u => u.PedidoRepository.Delete(It.Is<Pedido>(b => b.Id == pedidoId)), Times.Once);
        //_unitOfWorkMock.Verify(u => u.ExecuteTransactionAsync(It.IsAny<Func<Task>>(), CancellationToken.None), Times.Once);
    }
}
