using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint__windows_forms
{
    public partial class Form1 : Form
    {
        IFactory FigureFactory { get; set; }
        public Form1()
        {
            InitializeComponent();

            List<string> figures = new List<string> { "TriAngle", "Circle", "Rectangle" };
            comboBox1.Items.AddRange(figures.ToArray());
            comboBox1.SelectedIndex = 2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem.ToString();

            if (item == "TriAngle")
            {
                FigureFactory = new TriAngleFactory();
            }
            else if (item == "Rectangle")
            {
                FigureFactory = new RectangleFactory();
            }
            else if (item == "Circle")
            {
                FigureFactory = new CircleFactory();
            }
        }



        List<IFigure> Figures = new List<IFigure>();

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if (radioButton4.Checked)
            {


                if (FigureFactory.GetFigure() is Rectangle rect)
                {

                    rect.Color = FigureColor;
                    rect.Point = e.Location;
                    rect.Size = new Size(int.Parse(widthTxtb.Text), int.Parse(heightTxtb.Text));
                    if (radioButton1.Checked)
                    {
                        rect.isFilled = true;
                    }
                    else if (radioButton2.Checked)
                    {
                        rect.isFilled = false;
                    }



                    Figures.Add(rect);
                }
                if (FigureFactory.GetFigure() is Circle crc)
                {
                    crc.Color = FigureColor;
                    crc.Point = e.Location;
                    crc.Size = new Size(int.Parse(widthTxtb.Text), int.Parse(heightTxtb.Text));
                    if (radioButton1.Checked)
                    {
                        crc.isFilled = true;
                    }
                    else if (radioButton2.Checked)
                    {
                        crc.isFilled = false;
                    }
                    Figures.Add(crc);

                }
                if (FigureFactory.GetFigure() is TriAngle tri)
                {
                    tri.Color = FigureColor;
                    tri.Point = e.Location;
                    tri.Size = new Size(int.Parse(widthTxtb.Text), int.Parse(heightTxtb.Text));
                    if (radioButton1.Checked)
                    {
                        tri.isFilled = true;
                    }
                    else if (radioButton2.Checked)
                    {
                        tri.isFilled = false;
                    }
                    Figures.Add(tri);

                }
            }





            if (radioButton3.Checked)
            {

                if (FigureFactory.GetFigure() is Rectangle rect)
                {

                    rect.Color = FigureColor;
                    rect.Point = e.Location;
                    rect.Size = new Size(Math.Abs(endLocation.X - startLocation.X), Math.Abs(endLocation.Y - startLocation.Y));
                    if (radioButton1.Checked)
                    {
                        rect.isFilled = true;
                    }
                    else if (radioButton2.Checked)
                    {
                        rect.isFilled = false;
                    }



                    Figures.Add(rect);
                }
                if (FigureFactory.GetFigure() is Circle crc)
                {
                    crc.Color = FigureColor;
                    crc.Point = e.Location;
                    crc.Size = new Size(Math.Abs(endLocation.X - startLocation.X), Math.Abs(endLocation.Y - startLocation.Y));
                    if (radioButton1.Checked)
                    {
                        crc.isFilled = true;
                    }
                    else if (radioButton2.Checked)
                    {
                        crc.isFilled = false;
                    }
                    Figures.Add(crc);

                }
                if (FigureFactory.GetFigure() is TriAngle tri)
                {
                    tri.Color = FigureColor;
                    tri.Point = e.Location;
                    tri.Size = new Size(Math.Abs(endLocation.X - startLocation.X), Math.Abs(endLocation.Y - startLocation.Y));
                    if (radioButton1.Checked)
                    {
                        tri.isFilled = true;
                    }
                    else if (radioButton2.Checked)
                    {
                        tri.isFilled = false;
                    }
                    Figures.Add(tri);

                }

            }
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(FigureColor, 3);
            SolidBrush brush = new SolidBrush(FigureColor);
            using (var a = e.Graphics)
            {
                foreach (var item in Figures)
                {
                    if (item is Rectangle rect)
                    {

                        if (rect.isFilled)
                        {
                            a.FillRectangle(brush, rect.Point.X, rect.Point.Y, rect.Size.Width, rect.Size.Height);

                        }
                        else
                        {
                            a.DrawRectangle(pen, rect.Point.X, rect.Point.Y, rect.Size.Width, rect.Size.Height);
                        }
                    }

                    if (item is Circle crc)
                    {

                        if (crc.isFilled)
                        {
                            a.FillEllipse(brush, crc.Point.X, crc.Point.Y, crc.Size.Width, crc.Size.Height);

                        }
                        else
                        {
                            a.DrawEllipse(pen, crc.Point.X, crc.Point.Y, crc.Size.Width, crc.Size.Height);
                        }
                    }
                    if (item is TriAngle tri)
                    {
                        Point[] p = new Point[3]
                        {
                           new Point(tri.Point.X,tri.Point.Y),
                            new Point(tri.Point.X+tri.Size.Width/2,tri.Point.Y+tri.Size.Height),
                            new Point(tri.Point.X-tri.Size.Width/2,tri.Point.Y+tri.Size.Height)
                        };
                        if (tri.isFilled)
                        {
                            a.FillPolygon(brush, p);

                        }
                        else
                        {
                            a.DrawPolygon(pen, p);
                        }
                    }

                }
            }

        }
        public Color FigureColor { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            var result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FigureColor = colorDialog.Color;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Point startLocation;
        Point endLocation;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startLocation = e.Location;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            endLocation = e.Location;
        }
    }

    interface IFigure
    {
        Point Point { get; set; }
        Size Size { get; set; }
        Color Color { get; set; }
        bool isFilled { get; set; }
    }
    class Rectangle : IFigure
    {
        public Point Point { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public bool isFilled { get; set; }
    }

    class Circle : IFigure
    {
        public Point Point { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public bool isFilled { get; set; }
    }

    class TriAngle : IFigure
    {
        public Point Point { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public bool isFilled { get; set; }
    }

    interface IFactory
    {
        IFigure GetFigure();
    }
    class CircleFactory : IFactory
    {
        public IFigure GetFigure()
        {
            return new Circle();
        }
    }

    class RectangleFactory : IFactory
    {
        public IFigure GetFigure()
        {
            return new Rectangle();
        }
    }

    class TriAngleFactory : IFactory
    {
        public IFigure GetFigure()
        {
            return new TriAngle();
        }
    }


}
