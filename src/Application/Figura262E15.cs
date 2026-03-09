public class Figura262E15
{
    public const double Lado = 5;
    public const double Apotema = 3.5;
    public const int NumeroLados = 6;
    public const double Altura = 10;
    

    public static double Perimetro(double lado, int numeroLados)
    {
        return lado * numeroLados;
    }
    public static double Area(double lado, double apotema, int numeroLados)
    {
        double perimetro = Perimetro(lado, numeroLados);
        return perimetro * apotema / 2;
    }
    public static double Volumen(double area, double altura)
    {
        return area * altura;
    }

      public static (double perimetro, double area, double volumen) CalcularTodo() {
        var p = Perimetro(Lado, NumeroLados);
        var a = Area(Lado, Apotema, NumeroLados);
        var v = Volumen(a, Altura);
        return (p, a, v);
      }
}