using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace WebApp.IntegrationTest;

public class WebAppIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WebAppIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// Verifica que la aplicación web se puede crear correctamente.
    /// </summary>
    [Fact]
    public void WebApp_DebeCrearseCorrectamente()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act & Assert
        Assert.NotNull(client);
        Assert.NotNull(_factory);
    }

    /// <summary>
    /// Prueba de integración: La página de inicio (Index) debe devolver status 200 OK.
    /// </summary>
    [Fact]
    public async Task Index_DebeDevolverStatus200OK()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response.Content);
    }

    /// <summary>
    /// Prueba de integración: La página Index debe contener contenido HTML válido.
    /// </summary>
    [Fact]
    public async Task Index_DebeContenerContenidoHTML()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.NotEmpty(content);
        Assert.True(content.Contains("<") && content.Contains(">"),
            "La respuesta no contiene HTML válido");
    }

    /// <summary>
    /// Prueba de integración: La página Privacy debe devolver status 200 OK.
    /// </summary>
    [Fact]
    public async Task Privacy_DebeDevolverStatus200OK()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/Privacy");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// Prueba de integración: Una ruta inexistente debe devolver 404 Not Found.
    /// </summary>
    [Fact]
    public async Task RutaInexistente_DebeDevolverStatus404NotFound()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/ruta-que-no-existe");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
