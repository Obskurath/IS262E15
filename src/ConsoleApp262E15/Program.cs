//Formula de un Poligono regular 
//Variables
double lado = 5;
double apotema = 3.5;
double numeroLados = 6;
double altura = 10;
double perimetro = Figura262E15.Perimetro (lado,numeroLados);
double area = Figura262E15.Area(perimetro,apotema,numeroLados);
double volumen =Figura262E15.Volumen(area,altura);     

//Salida de datos
Console.WriteLine($"El perimetro de un Poligono regular con un lados de {lado} cm pero teniendo {numeroLados} lados, tiene un perimetro de {perimetro} cm\nEl area de de un Poligono Regular con un perimetro de {perimetro} cm y un apotema de {apotema} cm, su area es de {area} cm2\nEl volumen de un poligono regular con un area de {area} cm2 y una altura de {altura} cm es de {volumen} cm3");