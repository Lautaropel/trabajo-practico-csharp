using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
        { 
            
        }

        public virtual void Escalar(float crecimiento) { }
    }


    public class Rectangulo : Figura
    {
        protected int alto;
        protected int ancho;
        
        // Constructor
        public Rectangulo(int ancho, int alto) 
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            Point[] points = new Point[4]
            { 
                new Point(x,y), 
                new Point(x+ancho,y), 
                new Point(x+ancho,y+alto), 
                new Point(x,y+alto) 
            };
            // DrawPolygon dibuja un poligono dado un conjunto de puntos y un lapiz
            graphics.DrawPolygon(pen, points);
        }

        public override void Escalar(float crecimiento) {
            ancho = (int)(ancho * crecimiento);
            alto = (int)(alto * crecimiento);
        }
    }

    public class Cuadrado : Rectangulo
    {
        // Constructor. Un cuadrado es un rectangulo con ancho = alto
        public Cuadrado(int lado) : base(lado,lado)
        {
        }

        public override void Escalar(float crecimiento) {
            ancho = (int)(ancho * crecimiento);
            alto = (int)(alto * crecimiento);
        }

    }


    public class Circulo : Figura
    {
        private int radio;

        // Constructor
        public Circulo(int radio)
        {
            this.radio= radio;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            graphics.DrawEllipse(pen,x,y, radio, radio);
        }

        public override void Escalar(float crecimiento) {
            radio = (int)(radio * crecimiento);
        }
    }

    public class TrianguloIsosceles : Figura {
    
        private int baseTriangulo;
        private int altura;

        public TrianguloIsosceles(int baseTriangulo, int altura) {
            this.baseTriangulo = baseTriangulo;
            this.altura = altura;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)  {
            Point[] puntos =
            {
                new Point(x, y + altura),
                new Point(x + baseTriangulo / 2, y),
                new Point(x + baseTriangulo, y + altura)
            };
            graphics.DrawPolygon(pen, puntos);
        }
    }

    public class TrianguloEquilatero : Figura {
        private int lado;

        public TrianguloEquilatero(int lado)
        {
            this.lado = lado;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            double altura = Math.Sqrt(3) / 2 * lado;
            Point[] puntos =
            {
                new Point(x, (int)(y + altura)),
                new Point(x + lado / 2, y),
                new Point(x + lado, (int)(y + altura))
            };
            graphics.DrawPolygon(pen, puntos);
        }
    }
}
