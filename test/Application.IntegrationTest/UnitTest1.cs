namespace Application.IntegrationTest;

public class Figura262E15Tests
{
    /// <summary>
    /// Pruebas para el método Perimetro de un polígono regular.
    /// Fórmula: P = n * b (número de lados * lado)
    /// </summary>
    [Theory]
    [InlineData(5, 6, 30)]        // Hexágono: 6 lados * 5 = 30
    [InlineData(4, 4, 16)]        // Cuadrado: 4 lados * 4 = 16
    [InlineData(3.5, 8, 28)]      // Octágono: 8 lados * 3.5 = 28
    [InlineData(7.15, 5, 35.75)]  // Pentágono: 5 lados * 7.15 = 35.75
    public void Perimetro_DebeDevolverValorCorrecto(double lado, int numeroLados, double esperado)
    {
        // Arrange
        // Act
        double resultado = Figura262E15.Perimetro(lado, numeroLados);

        // Assert
        Assert.Equal(esperado, resultado, 3);
    }

    /// <summary>
    /// Pruebas para el método Area de un polígono regular.
    /// Fórmula: A = (Perímetro * Apotema) / 2
    /// </summary>
    [Theory]
    [InlineData(5, 3.5, 6, 52.5)]           // Hexágono: (30 * 3.5) / 2 = 52.5
    [InlineData(4, 2, 4, 16)]               // Cuadrado: (16 * 2) / 2 = 16
    [InlineData(3.5, 2.5, 8, 35)]           // Octágono: (28 * 2.5) / 2 = 35
    [InlineData(6.2, 4.8, 5, 74.4)]         // Pentágono: (31 * 4.8) / 2 = 74.4
    public void Area_DebeDevolverValorCorrecto(double lado, double apotema, int numeroLados, double esperado)
    {
        // Arrange
        // Act
        double resultado = Figura262E15.Area(lado, apotema, numeroLados);

        // Assert
        Assert.Equal(esperado, resultado, 3);
    }

    /// <summary>
    /// Pruebas para el método Volumen de un sólido.
    /// Fórmula: V = Area * Altura
    /// </summary>
    [Theory]
    [InlineData(52.5, 10, 525)]           // Área 52.5 * Altura 10 = 525
    [InlineData(16, 8, 128)]              // Área 16 * Altura 8 = 128
    [InlineData(35, 15, 525)]             // Área 35 * Altura 15 = 525
    [InlineData(45.75, 6.2, 283.65)]      // Área 45.75 * Altura 6.2 = 283.65
    public void Volumen_DebeDevolverValorCorrecto(double area, double altura, double esperado)
    {
        // Arrange
        // Act
        double resultado = Figura262E15.Volumen(area, altura);

        // Assert
        Assert.Equal(esperado, resultado, 3);
    }

    /// <summary>
    /// Prueba integral para CalcularTodo con los valores por defecto.
    /// Valida que los cálculos de perímetro, área y volumen sean correctos en conjunto.
    /// Constantes: Lado=5, Apotema=3.5, NumeroLados=6, Altura=10
    /// Perímetro esperado: 6 * 5 = 30
    /// Área esperada: (30 * 3.5) / 2 = 52.5
    /// Volumen esperado: 52.5 * 10 = 525
    /// </summary>
    [Fact]
    public void CalcularTodo_DebeDevolverValoresCorrectosParaHexagono()
    {
        // Arrange
        double perimetroEsperado = 30;
        double areaEsperada = 52.5;
        double volumenEsperado = 525;

        // Act
        var (perimetro, area, volumen) = Figura262E15.CalcularTodo();

        // Assert
        Assert.Equal(perimetroEsperado, perimetro, 3);
        Assert.Equal(areaEsperada, area, 3);
        Assert.Equal(volumenEsperado, volumen, 3);
    }

    /// <summary>
    /// Prueba de coherencia: El perímetro calculado dentro de CalcularTodo
    /// debe ser igual al calculado directamente con Perimetro().
    /// </summary>
    [Fact]
    public void CalcularTodo_PerimetroDebeCoincidirConMetodoPerimetro()
    {
        // Arrange
        var perimetroDirecto = Figura262E15.Perimetro(Figura262E15.Lado, Figura262E15.NumeroLados);

        // Act
        var (perimetroTodo, _, _) = Figura262E15.CalcularTodo();

        // Assert
        Assert.Equal(perimetroDirecto, perimetroTodo, 3);
    }

    /// <summary>
    /// Prueba de coherencia: El área calculada dentro de CalcularTodo
    /// debe ser igual al calculado directamente con Area().
    /// </summary>
    [Fact]
    public void CalcularTodo_AreaDebeCoincidirConMetodoArea()
    {
        // Arrange
        var areaDirecta = Figura262E15.Area(Figura262E15.Lado, Figura262E15.Apotema, Figura262E15.NumeroLados);

        // Act
        var (_, areaTodo, _) = Figura262E15.CalcularTodo();

        // Assert
        Assert.Equal(areaDirecta, areaTodo, 3);
    }

    /// <summary>
    /// Prueba de coherencia: El volumen calculado dentro de CalcularTodo
    /// debe ser igual al calculado directamente con Volumen().
    /// </summary>
    [Fact]
    public void CalcularTodo_VolumenDebeCoincidirConMetodoVolumen()
    {
        // Arrange
        var areaDirecta = Figura262E15.Area(Figura262E15.Lado, Figura262E15.Apotema, Figura262E15.NumeroLados);
        var volumenDirecto = Figura262E15.Volumen(areaDirecta, Figura262E15.Altura);

        // Act
        var (_, _, volumenTodo) = Figura262E15.CalcularTodo();

        // Assert
        Assert.Equal(volumenDirecto, volumenTodo, 3);
    }
}
