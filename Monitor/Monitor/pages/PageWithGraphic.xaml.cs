using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

        private List<double> points = new List<double>();
        private Rectangle scale = new Rectangle();
        private Label valueOfParameter = new Label();

        private double graphicWidth;
        private double graphicHeight;
        private int graphicToScale = 30;
        private int scaleWidth = 20;
        private double betweenPoints;
        private int countOfPoints = 25;

        private double topMargin = 20;
        private double bottomMargin = 20;
        

        private double maxAllowableValue;
        private double minAllowableValue;
        private double normValue;
        private bool f;
        private double devb;
        private double devt;

        //public PageWithGraphic(string graphicNameString, double min, double max, double norm)
        //{
        //    InitializeComponent();

        //    maxAllowableValue = max;
        //    minAllowableValue = min;
        //    normValue = norm;

        //    graphicHeight = grid.Height - bottomMargin - topMargin;
        //    graphicWidth = grid.Width - graphicToScale - scaleWidth;
        //    betweenPoints = graphicWidth / countOfPoints;

        //    Line xNorm = new Line();
        //    xNorm.Stroke = Brushes.DarkGreen;
        //    xNorm.StrokeThickness = 1;
        //    xNorm.StrokeDashArray = new DoubleCollection() {2, 2};
        //    xNorm.X1 = 0;
        //    xNorm.Y1 = graphicHeight - (norm - minAllowableValue) * graphicHeight / (maxAllowableValue - minAllowableValue);
        //    xNorm.X2 = grid.Width;
        //    xNorm.Y2 = graphicHeight - (norm - minAllowableValue) * graphicHeight / (maxAllowableValue - minAllowableValue);
        //    xNorm.VerticalAlignment = VerticalAlignment.Top;
        //    xNorm.Margin = new Thickness(0, topMargin, 0, 0);
        //    grid.Children.Add(xNorm);

        //    Label normLabel = new Label();
        //    normLabel.HorizontalAlignment = HorizontalAlignment.Right;
        //    normLabel.VerticalAlignment = VerticalAlignment.Top;
        //    normLabel.Margin = new Thickness(0, graphicHeight - (norm - minAllowableValue) * graphicHeight / (maxAllowableValue - minAllowableValue), scaleWidth, 0);
        //    normLabel.Content = norm.ToString();
        //    normLabel.FontSize = 12;
        //    grid.Children.Add(normLabel);

        //    CreateGraphicAndScale(graphicNameString);

        //    PlotGraph();

        //    timer = new DispatcherTimer();
        //    timer.Interval = TimeSpan.FromSeconds(2); // время обновления
        //    timer.Tick += Timer_Tick;
        //    timer.Start();
        //}

        //график выше и ниже нормы
        //0 - не выше, 1 - не ниже
        public PageWithGraphic(string graphicNameString, double min, double max, double norm, bool f)
        {
            InitializeComponent();

            maxAllowableValue = max;
            minAllowableValue = min;
            normValue = norm;
            this.f = f;

            graphicHeight = grid.Height - bottomMargin - topMargin;
            graphicWidth = grid.Width - graphicToScale - scaleWidth;
            betweenPoints = graphicWidth / countOfPoints;

            CreateGraphicAndScale(graphicNameString);

            Line xNorm = new Line();
            xNorm.Stroke = Brushes.DarkGreen;
            xNorm.StrokeThickness = 1;
            xNorm.StrokeDashArray = new DoubleCollection() {2, 2};
            xNorm.X1 = 0;
            xNorm.Y1 = graphicHeight - ValueToY(norm);
            xNorm.X2 = grid.Width;
            xNorm.Y2 = graphicHeight - ValueToY(norm);
            xNorm.VerticalAlignment = VerticalAlignment.Top;
            xNorm.Margin = new Thickness(0, topMargin, 0, 0);
            grid.Children.Add(xNorm);

            Label normLabel = new Label();
            normLabel.HorizontalAlignment = HorizontalAlignment.Right;
            normLabel.VerticalAlignment = VerticalAlignment.Top;
            normLabel.Margin = new Thickness(0, graphicHeight - ValueToY(norm), scaleWidth, 0);
            normLabel.Content = norm.ToString();
            normLabel.FontSize = 12;
            grid.Children.Add(normLabel);

            

            PlotGraph();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2); // время обновления
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void ColorForScaleForSimpleGraphic(double value)
        {
            if (f)
            {
                if(value >= normValue)
                    scale.Fill = Brushes.LightGreen;
                else
                    scale.Fill = Brushes.Coral;
            }
            else
            {
                if (value <= normValue)
                    scale.Fill = Brushes.LightGreen;
                else
                    scale.Fill = Brushes.Coral;
            }
        }

        //график с отклонением

        public PageWithGraphic(string graphicNameString, double min, double max, double norm, double devb, double devt)
        {
            InitializeComponent();

            maxAllowableValue = max;
            minAllowableValue = min;
            normValue = norm;

            this.devb = devb;
            this.devt = devt;


            graphicHeight = grid.Height - bottomMargin - topMargin;
            graphicWidth = grid.Width - graphicToScale - scaleWidth;
            betweenPoints = graphicWidth / countOfPoints;

            CreateGraphicAndScale(graphicNameString);

            Line xNorm = new Line();
            xNorm.Stroke = Brushes.DarkGreen;
            xNorm.StrokeThickness = 1;
            xNorm.StrokeDashArray = new DoubleCollection() {2, 2};
            xNorm.X1 = 0;
            xNorm.Y1 = graphicHeight - ValueToY(norm + devt);
            xNorm.X2 = grid.Width;
            xNorm.Y2 = graphicHeight - ValueToY(norm + devt);
            xNorm.VerticalAlignment = VerticalAlignment.Top;
            xNorm.Margin = new Thickness(0, topMargin, 0, 0);
            grid.Children.Add(xNorm);

            Label normLabel = new Label();
            normLabel.HorizontalAlignment = HorizontalAlignment.Right;
            normLabel.VerticalAlignment = VerticalAlignment.Top;
            normLabel.Margin = new Thickness(0, graphicHeight - ValueToY(norm + devt), scaleWidth, 0);
            normLabel.Content = (norm + devt).ToString();
            normLabel.FontSize = 12;
            grid.Children.Add(normLabel);

            Line xNorm2 = new Line();
            xNorm2.Stroke = Brushes.DarkGreen;
            xNorm2.StrokeThickness = 1;
            xNorm2.StrokeDashArray = new DoubleCollection() { 2, 2 };
            xNorm2.X1 = 0;
            xNorm2.Y1 = graphicHeight - ValueToY(norm - devb);
            xNorm2.X2 = grid.Width;
            xNorm2.Y2 = graphicHeight - ValueToY(norm - devb);
            xNorm2.VerticalAlignment = VerticalAlignment.Top;
            xNorm2.Margin = new Thickness(0, topMargin, 0, 0);
            grid.Children.Add(xNorm2);

            Label normLabel2 = new Label();
            normLabel2.HorizontalAlignment = HorizontalAlignment.Right;
            normLabel2.VerticalAlignment = VerticalAlignment.Top;
            normLabel2.Margin = new Thickness(0, graphicHeight - ValueToY(norm - devb), scaleWidth, 0);
            normLabel2.Content = (norm - devb).ToString();
            normLabel2.FontSize = 12;
            grid.Children.Add(normLabel2);



            PlotGraph();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2); // время обновления
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void ColorForScaleForDevGraphic(double value)
        {
            if (value >= normValue - devb && value <= normValue + devt)
                scale.Fill = Brushes.LightGreen;
            else
                scale.Fill = Brushes.Coral;
        }

        private void CreateGraphicAndScale(string graphicNameString)
        {
            Label graphicName = new Label();
            graphicName.HorizontalAlignment = HorizontalAlignment.Center;
            graphicName.VerticalAlignment = VerticalAlignment.Bottom;
            //graphicName.Margin = new Thickness(0, 0, 0, 0);
            graphicName.Content = graphicNameString;
            grid.Children.Add(graphicName);

            scale.Width = scaleWidth;
            scale.Height = 0;
            scale.Fill = new SolidColorBrush(Colors.LightGreen);
            scale.HorizontalAlignment = HorizontalAlignment.Left;
            scale.VerticalAlignment = VerticalAlignment.Bottom;
            scale.Margin = new Thickness(graphicWidth + graphicToScale, 0, 0, grid.Height - graphicHeight - topMargin);
            grid.Children.Add(scale);

            Rectangle r = new Rectangle();
            r.Width = scaleWidth;
            r.Height = graphicHeight;
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.HorizontalAlignment = HorizontalAlignment.Left;
            r.VerticalAlignment = VerticalAlignment.Top;
            r.Margin = new Thickness(graphicWidth + graphicToScale, topMargin, 0, 0);
            grid.Children.Add(r);

            if (minAllowableValue < 0)
            {
                Line xZero = new Line();
                xZero.Stroke = Brushes.Blue;
                xZero.StrokeThickness = 1;
                xZero.X1 = 0;
                xZero.Y1 = graphicHeight - (0 - minAllowableValue * (graphicHeight / (maxAllowableValue - minAllowableValue)));
                xZero.X2 = grid.Width;
                xZero.Y2 = graphicHeight - (0 - minAllowableValue * (graphicHeight / (maxAllowableValue - minAllowableValue)));
                xZero.VerticalAlignment = VerticalAlignment.Top;
                xZero.Margin = new Thickness(0, topMargin, 0, 0);
                grid.Children.Add(xZero);

                Label zeroLabel = new Label();
                zeroLabel.HorizontalAlignment = HorizontalAlignment.Right;
                zeroLabel.VerticalAlignment = VerticalAlignment.Top;
                zeroLabel.Margin = new Thickness(0, graphicHeight - (0 - minAllowableValue) * graphicHeight / (maxAllowableValue - minAllowableValue), scaleWidth, 0);
                zeroLabel.Content = "0";
                zeroLabel.FontSize = 12;
                grid.Children.Add(zeroLabel);
            }

            Canvas canvas = new Canvas();
            canvas.Width = graphicWidth;
            canvas.Height = graphicHeight;
            canvas.HorizontalAlignment = HorizontalAlignment.Left;
            canvas.VerticalAlignment = VerticalAlignment.Top;
            canvas.Margin = new Thickness(0, topMargin, 0, 0);
            canvas.Name = "myCanvas";
            grid.Children.Add(canvas);

            valueOfParameter.HorizontalAlignment = HorizontalAlignment.Center;
            valueOfParameter.VerticalAlignment = VerticalAlignment.Top;
            valueOfParameter.Foreground = Brushes.Black;
            grid.Children.Add(valueOfParameter);

            Line xAxis = new Line();
            xAxis.Stroke = Brushes.Black;
            xAxis.StrokeThickness = 1.5;
            xAxis.X1 = 0;
            xAxis.Y1 = canvas.Height;
            xAxis.X2 = canvas.Width;
            xAxis.Y2 = canvas.Height;
            xAxis.VerticalAlignment = VerticalAlignment.Top;
            xAxis.Margin = new Thickness(0, topMargin, 0, 0);
            grid.Children.Add(xAxis);

            Line yAxis = new Line();
            yAxis.Stroke = Brushes.Black;
            yAxis.StrokeThickness = 1.5;
            yAxis.X1 = 0;
            yAxis.Y1 = 0;
            yAxis.X2 = 0;
            yAxis.Y2 = canvas.Height;
            yAxis.VerticalAlignment = VerticalAlignment.Top;
            yAxis.Margin = new Thickness(0, topMargin, 0, 0);
            grid.Children.Add(yAxis);
        }

        private double GetRandomSpeed()
        {
            Random random = new Random();
            return random.Next((int)minAllowableValue, (int)maxAllowableValue)+0.01;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rn = new Random();

            if (points.Count == countOfPoints)
            {
                points.RemoveAt(0);
            }

            points.Add(GetRandomSpeed());

            PlotGraph();
            AnimationForScale(ValueToY(points[points.Count - 1]));
            valueOfParameter.Content = Math.Round(points[points.Count - 1], 2);
        }

        private double ValueToY(double n)
        {
            return (n - minAllowableValue) * graphicHeight / (maxAllowableValue - minAllowableValue);
        }

        private void PlotGraph()
        {
            Grid myGrid = (Grid)FindName("grid");
            Canvas canvas = grid.Children.OfType<Canvas>().FirstOrDefault(c => c.Name == "myCanvas");
            canvas.Children.Clear();

            for (int i = 0; i < points.Count - 1; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 1.7;

                line.X1 = betweenPoints * i;
                line.Y1 = canvas.Height - ValueToY(points[i]);
                line.X2 = betweenPoints * (i + 1);
                line.Y2 = canvas.Height - ValueToY(points[i+1]);

                canvas.Children.Add(line);
            }
        }

        private void AnimationForScale(double n)
        {
            DoubleAnimation anim = new DoubleAnimation();
            if(devb == double.NaN)
                ColorForScaleForSimpleGraphic(points[points.Count - 1]);
            else
                ColorForScaleForDevGraphic(points[points.Count - 1]);
            anim.From = scale.Height;
            anim.To = n;
            anim.Duration = TimeSpan.FromSeconds(1);
            anim.EasingFunction = new QuadraticEase();
            scale.BeginAnimation(HeightProperty, anim);
        }
    }
}

