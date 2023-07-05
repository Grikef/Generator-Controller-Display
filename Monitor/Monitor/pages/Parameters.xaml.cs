using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

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
using System.Xml.Linq;

namespace Monitor.pages
{
    /// <summary>
    /// Логика взаимодействия для Parameters.xaml
    /// </summary>
    public partial class Parameters : Page
    {
        private DispatcherTimer timer;

        private List<Point> points = new List<Point>();
        private Rectangle scale = new Rectangle();
        private Label valueOfParameter = new Label();

        private int graphicWidth = 400;
        private int graphicHeight = 300;
        private int graphicToScale = 100;
        private int scaleWidth = 20;
        private int betweenPoints = 40;



        public Parameters()
        {
            InitializeComponent();

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

            points.Add(new Point(0, 100));
            points.Add(new Point(betweenPoints, 100));
            points.Add(new Point(betweenPoints * 2, 150));
            points.Add(new Point(betweenPoints * 3, 100));
            points.Add(new Point(betweenPoints * 4, 80));
            points.Add(new Point(betweenPoints * 5, 120));
            points.Add(new Point(betweenPoints * 6, 63));
            points.Add(new Point(betweenPoints * 7, 89));
            points.Add(new Point(betweenPoints * 8, 150));
            points.Add(new Point(betweenPoints * 9, 200));

            valueOfParameter.Content = points[9].Y.ToString();

            PlotGraph(points);
            ColorForScale(points[points.Count - 1].Y, 200, 20);
            AnimationForScale(points[points.Count-1].Y);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Обновление каждую секунду
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Получаем текущую скорость (демонстрационное значение)
            double speed = GetRandomSpeed();

            // Ограничиваем скорость в диапазоне от 0 до 200
            if (speed < 0) speed = 0;
            if (speed > 200) speed = 200;

            // Вычисляем угол поворота для стрелки спидометра
            double angle = MapValue(speed, 0, 200, -135, 135);

            // Обновляем угол поворота стрелки спидометра
            needleTransform.Angle = angle;
        }

        private double GetRandomSpeed()
        {
            // Генерируем случайное значение скорости для демонстрации
            Random random = new Random();
            return random.Next(0, 201);
        }

        private double MapValue(double value, double fromMin, double fromMax, double toMin, double toMax)
        {
            // Преобразуем значение из одного диапазона в другой
            return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
        }

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
                if (points[points.Count - 1].Y <= 200 + 20 && points[points.Count - 1].Y >= 200 - 20)
                {
                    line.Stroke = Brushes.LightGreen;
                }
                else
                {
                    line.Stroke = Brushes.Red;
                }

                //line.Stroke = Brushes.Blue;
                line.StrokeThickness = 1;

                line.X1 = points[i].X;
                line.Y1 = canvas.Height - points[i].Y;
                line.X2 = points[i + 1].X;
                line.Y2 = canvas.Height - points[i + 1].Y;

                canvas.Children.Add(line);
            }

            // Добавляем координатные оси
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

            // Подписываем оси
            TextBlock xAxisLabel = new TextBlock();
            xAxisLabel.Text = "X";
            Canvas.SetLeft(xAxisLabel, canvas.Width - 20);
            Canvas.SetTop(xAxisLabel, canvas.Height - 20);
            canvas.Children.Add(xAxisLabel);

            TextBlock yAxisLabel = new TextBlock();
            yAxisLabel.Text = "Y";
            Canvas.SetLeft(yAxisLabel, 10);
            Canvas.SetTop(yAxisLabel, 0);
            canvas.Children.Add(yAxisLabel);



            //Line norm = new Line();
            //norm.Stroke = Brushes.Black;
            //norm.StrokeThickness = 1.5;
            //norm.X1 = 800;
            //norm.Y1 = 173 + 100;
            //norm.X2 = 800+20;
            //norm.Y2 = 173 + 100;
            //grid.Children.Add(norm);







            canvas.HorizontalAlignment = HorizontalAlignment.Left;
            canvas.VerticalAlignment = VerticalAlignment.Top;
            grid.Children.Add(canvas);

            //Content = canvas;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = 40;

            // Построение графика
        
            Random rn = new Random();
            points.RemoveAt(0);
            points[0] = new Point(0, points[0].Y);
            points[1] = new Point(x, points[1].Y);
            points[2] = new Point(x * 2, points[2].Y);
            points[3] = new Point(x * 3, points[3].Y);
            points[4] = new Point(x * 4, points[4].Y);
            points[5] = new Point(x * 5, points[5].Y);
            points[6] = new Point(x * 6, points[6].Y);
            points[7] = new Point(x * 7, points[7].Y);
            points[8] = new Point(x * 8, points[8].Y);
            points.Add(new Point(x * 9, rn.Next(0, 300)));


            PlotGraph(points);
            ColorForScale(points[9].Y, 200, 20);
            AnimationForScale(points[9].Y);
            valueOfParameter.Content = points[9].Y.ToString();
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
