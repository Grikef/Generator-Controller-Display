using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Monitor.pages
{
    /// <summary>
    /// Логика взаимодействия для PageWithGraphic.xaml
    /// </summary>
    public partial class PageWithGraphic : Page
    {
        private DispatcherTimer timer;

        private List<Point> points = new List<Point>();
        private Rectangle scale = new Rectangle();
        private Label valueOfParameter = new Label();

        private int graphicWidth;
        private int graphicHeight;
        private int graphicToScale = 10;
        private int scaleWidth = 20;
        private int betweenPoints;
        private int countOfPoints = 50;

        private int maxValue;



        public PageWithGraphic()
        {
            InitializeComponent();

            graphicHeight = (int)grid.Height-20;
            graphicWidth = (int)grid.Width - graphicToScale - scaleWidth;
            betweenPoints = graphicWidth / countOfPoints;

            //создание шкалы и значение параметра
            scale.Width = scaleWidth;
            scale.Height = 0;
            scale.Fill = new SolidColorBrush(Colors.LightGreen);
            scale.HorizontalAlignment = HorizontalAlignment.Left;
            scale.VerticalAlignment = VerticalAlignment.Bottom;
            scale.Margin = new Thickness(graphicWidth + graphicToScale, 0, 0, grid.Height - graphicHeight);
            grid.Children.Add(scale);

    

            Rectangle r = new Rectangle();
            r.Width = scaleWidth;
            r.Height = graphicHeight;
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.HorizontalAlignment = HorizontalAlignment.Left;
            r.VerticalAlignment = VerticalAlignment.Top;
            r.Margin = new Thickness(graphicWidth + graphicToScale, 0, 0, 0);
            grid.Children.Add(r);

            //Line yAxis = new Line();
            //yAxis.Stroke = Brushes.Black;
            //yAxis.StrokeThickness = 1.5;
            //yAxis.X1 = 0;
            //yAxis.Y1 = 0;
            //yAxis.X2 = 0;
            //yAxis.Y2 = canvas.Height;
            //canvas.Children.Add(yAxis);

            //Line yAxis = new Line();
            //yAxis.Stroke = Brushes.Black;
            //yAxis.StrokeThickness = 1.5;
            //yAxis.X1 = 0;
            //yAxis.Y1 = 0;
            //yAxis.X2 = 0;
            //yAxis.Y2 = canvas.Height;
            //canvas.Children.Add(yAxis);

            valueOfParameter.Name = "valueOfParameter";
            valueOfParameter.HorizontalAlignment = HorizontalAlignment.Left;
            valueOfParameter.VerticalAlignment = VerticalAlignment.Top;
            valueOfParameter.Margin = new Thickness(graphicWidth + graphicToScale + scaleWidth, 0, 0, 0);
            grid.Children.Add(valueOfParameter);

            //points.Add(new Point(0, 100));
            //points.Add(new Point(betweenPoints, 100));
            //points.Add(new Point(betweenPoints * 2, 150));
            //points.Add(new Point(betweenPoints * 3, 100));
            //points.Add(new Point(betweenPoints * 4, 80));
            //points.Add(new Point(betweenPoints * 5, 120));
            //points.Add(new Point(betweenPoints * 6, 63));
            //points.Add(new Point(betweenPoints * 7, 89));
            //points.Add(new Point(betweenPoints * 8, 150));
            //points.Add(new Point(betweenPoints * 9, 200));

            //valueOfParameter.Content = points[points.Count - 1].Y.ToString();

            PlotGraph(points);
            //ColorForScale(points[points.Count - 1].Y, 200, 20);
            //AnimationForScale(points[points.Count-1].Y);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.4); // Обновление каждую секунду
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private double GetRandomSpeed()
        {
            // Генерируем случайное значение скорости для демонстрации (правило нормального распределения)
            Random random = new Random();

            double u1 = 1 - random.NextDouble(); // Генерируем случайное число в диапазоне (0, 1] (исключая 0)
            double u2 = 1 - random.NextDouble(); // Генерируем еще одно случайное число в диапазоне (0, 1] (исключая 0)

            double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
            double x = 200 + 50 * z1;

            if (x > 300.0)
                x = 300;

            return Math.Round(x);
        }

        //#region стрелка
        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rn = new Random();

            if (points.Count == countOfPoints)
            {
                points.RemoveAt(0);
                for (int i = 0; i < points.Count; i++)
                    points[i] = new Point(betweenPoints * i, points[i].Y);
                points.Add(new Point(betweenPoints * points.Count, GetRandomSpeed()*graphicHeight/300));
            }
            else
            {
                points.Add(new Point(betweenPoints * points.Count, GetRandomSpeed() * graphicHeight / 300));
            }

            PlotGraph(points);
            ColorForScale(points[points.Count - 1].Y, 200, 20);
            AnimationForScale(points[points.Count - 1].Y);
            valueOfParameter.Content = points[points.Count - 1].Y.ToString();
        }

        //private double GetRandomSpeed()
        //{
        //    // Генерируем случайное значение скорости для демонстрации
        //    Random random = new Random();
        //    return random.Next(0, 201);
        //}

        //private double MapValue(double value, double fromMin, double fromMax, double toMin, double toMax)
        //{
        //    // Преобразуем значение из одного диапазона в другой
        //    return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
        //}
        //#endregion

        private void PlotGraph(List<Point> points)
        {
            // Создаем канвас
            Canvas canvas = new Canvas();
            canvas.Width = graphicWidth;
            canvas.Height = graphicHeight;
            canvas.Background = Brushes.White;


            for (int i = 0; i < points.Count - 1; i++)
            {
                Line line = new Line();
                //if (points[points.Count - 1].Y <= 200 + 20 && points[points.Count - 1].Y >= 200 - 20)
                //{
                //    line.Stroke = Brushes.LightGreen;
                //}
                //else
                //{
                //    line.Stroke = Brushes.Red;
                //}
                line.Stroke = Brushes.Blue;
                line.StrokeThickness = 1.7;

                line.X1 = points[i].X;
                line.Y1 = canvas.Height - points[i].Y;
                line.X2 = points[i + 1].X;
                line.Y2 = canvas.Height - points[i + 1].Y;

                canvas.Children.Add(line);
            }

            // Добавляем оси
            Line xAxis = new Line();
            xAxis.Stroke = Brushes.Black;
            xAxis.StrokeThickness = 1.5;
            xAxis.X1 = 0;
            xAxis.Y1 = canvas.Height;
            xAxis.X2 = canvas.Width;
            xAxis.Y2 = canvas.Height;
            canvas.Children.Add(xAxis);

            Line yAxis = new Line();
            yAxis.Stroke = Brushes.Black;
            yAxis.StrokeThickness = 1.5;
            yAxis.X1 = 0;
            yAxis.Y1 = 0;
            yAxis.X2 = 0;
            yAxis.Y2 = canvas.Height;
            canvas.Children.Add(yAxis);

            canvas.HorizontalAlignment = HorizontalAlignment.Left;
            canvas.VerticalAlignment = VerticalAlignment.Top;
            grid.Children.Add(canvas);
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rn = new Random();

            if (points.Count == countOfPoints)
            {
                points.RemoveAt(0);
                for (int i = 0; i < points.Count; i++)
                    points[i] = new Point(betweenPoints * i, points[i].Y);
                points.Add(new Point(betweenPoints * points.Count, rn.Next(0, graphicHeight)));
            }
            else
            {
                points.Add(new Point(betweenPoints * points.Count, rn.Next(0, graphicHeight)));
            }

            PlotGraph(points);
            ColorForScale(points[points.Count - 1].Y, 200, 20);
            AnimationForScale(points[points.Count - 1].Y);
            valueOfParameter.Content = points[points.Count - 1].Y.ToString();
        }

        private void ColorForScale(double value, double normal, double deviation)
        {
            if (value <= normal + deviation && value >= normal - deviation)
            {
                scale.Fill = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                scale.Fill = new SolidColorBrush(Colors.Red);
            }
        }

        private void AnimationForScale(double n)
        {
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = scale.Height;
            anim.To = n;
            anim.Duration = TimeSpan.FromSeconds(1);
            anim.EasingFunction = new QuadraticEase();
            scale.BeginAnimation(HeightProperty, anim);
        }
    }
}

