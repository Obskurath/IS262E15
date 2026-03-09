public class Figura262E15 {
public static double Perimetro(double lado, int numeroLados) {
return lado * numeroLados;
}
public static double Area(double lado, double apotema, int numeroLados) {
double perimetro = Perimetro(lado, numeroLados);
return perimetro * apotema/2;
}
public static double Volumen(double area, double altura) {
return area * altura;
}
}