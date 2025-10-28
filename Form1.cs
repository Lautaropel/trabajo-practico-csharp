using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        Figura[] figuras;

        public Form1()
        {
            InitializeComponent();
            figuras = new Figura[5]     
            {
                new Circulo(60),
                new Rectangulo(30,50),
                new Cuadrado(45),
                new TrianguloIsosceles(60, 80),
                new TrianguloEquilatero(60)
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            
            Random rand = new Random();
            
            Color[] colores = new Color[figuras.Length];
            
            for (int i = 0; i < figuras.Length; i++) {
                colores[i] = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            for (int i = 0; i < figuras.Length; i++) {

                float crecimiento = 1 + 0.5f * i;
                figuras[i].Escalar(crecimiento);
                using (Pen pen = new Pen(colores[i])) {
                    figuras[i].Dibujar(pen, gr, i * 120, 50);
                }
            }

        }
    }
}
