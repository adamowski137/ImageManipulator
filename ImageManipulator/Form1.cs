
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageManipulator
{
    public partial class Form1 : Form
    {


        SelectItem[] selectItems = {new SelectItem(){ Name = "Whole Area", Value = Mode.WholeArea }, new SelectItem() { Name = "Brush", Value = Mode.Brush } };

        AppState appState;

        Chart redChart;
        Chart greenChart;
        Chart blueChart;
        
        TrackBar brightnessTB;
        TrackBar gammaTB;
        TrackBar contrastTB;
        Chart customFunctionCHT;

        int[] customFunctionValues;
        bool isDragging;
        int selectedPointIndex;

        bool[,] modified;

        bool drawing;

        const int radius = 100;

        public Form1()
        {
            drawing = false;
            isDragging = false;
            selectedPointIndex = -1;
            redChart = new Chart();
            greenChart = new Chart();
            blueChart = new Chart();

            redChart.ChartAreas.Add("redChartArea");
            greenChart.ChartAreas.Add("greenChartArea");
            blueChart.ChartAreas.Add("blueChartArea");

            appState = new AppState(Width, Height);
            
            brightnessTB = new TrackBar();
            gammaTB = new TrackBar();
            contrastTB = new TrackBar();
            customFunctionCHT = new Chart();

            modified = new bool[,] { };

            redChart.Height = 200;
            greenChart.Height = 200;
            blueChart.Height = 200;

            brightnessTB.Dock= DockStyle.Fill;
            gammaTB.Dock= DockStyle.Fill;
            contrastTB.Dock= DockStyle.Fill;
            customFunctionCHT.Dock = DockStyle.Fill;

            brightnessTB.Maximum = 255;
            brightnessTB.Minimum = -255;

            gammaTB.Maximum = 200;
            gammaTB.Minimum = 0;

            contrastTB.Maximum = 127;
            contrastTB.Minimum = 0;

            gammaTB.Value = 100;

            customFunctionValues = new int[256/32 + 1];
            for (int i = 0; i < customFunctionValues.Count(); i++)
            {
                customFunctionValues[i] = i * 32;
            }

            brightnessTB.ValueChanged += TB_ValueChanged;
            gammaTB.ValueChanged += TB_ValueChanged;
            contrastTB.ValueChanged += TB_ValueChanged;

            customFunctionCHT.MouseDown += Chart_MouseDown;
            customFunctionCHT.MouseMove += Chart_MouseMove;
            customFunctionCHT.MouseUp += Chart_MouseUp;



            InitializeComponent();
        }


        private void TB_ValueChanged(object? sender, EventArgs e)
        {
            drawImage();
        }

        private void updateCustomFunction()
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Spline;


            for (int i = 0; i < customFunctionValues.Count(); i++)
            {
                series.Points.AddXY(i * 32, customFunctionValues[i]);
            }
            foreach (DataPoint point in series.Points)
            {
                point.MarkerStyle = MarkerStyle.Circle;
                point.MarkerSize = 8;
            }

            customFunctionCHT.Series.Clear();
            customFunctionCHT.Series.Add(series);
            customFunctionCHT.Invalidate();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modeCBX.Items.AddRange(selectItems.Select(x => x.Name).ToArray());
            modeCBX.SelectedIndex = 0;


            chartsLP.Controls.Add(redChart);
            chartsLP.Controls.Add(greenChart);
            chartsLP.Controls.Add(blueChart);


            customFunctionCHT.ChartAreas.Add("function");
            updateCustomFunction();
           
        }
        private void Chart_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult hitResult = customFunctionCHT.HitTest(e.X, e.Y, false);
            if (hitResult.PointIndex >= 0)
            {
                isDragging = true;
                selectedPointIndex = hitResult.PointIndex;
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedPointIndex >= 0)
            {
                double xValue = selectedPointIndex * 20;
                double yValue = customFunctionValues[selectedPointIndex];

                // Convert mouse coordinates to chart coordinates
                Chart chart = (Chart)sender;
                ChartArea chartArea = chart.ChartAreas[0];
                double x = chartArea.AxisX.PixelPositionToValue(e.X);
                double y = chartArea.AxisY.PixelPositionToValue(e.Y);

                // Update the selected data point
                customFunctionValues[selectedPointIndex] =(int) y;

                updateCustomFunction();
            }
        }

        private void Chart_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            selectedPointIndex = -1;

            drawImage();
        }

        void calculateHistogramData()
        {
            redChart.Series.Clear();
            greenChart.Series.Clear();
            blueChart.Series.Clear();

            int[] redPixels = new int[256];
            int[] greenPixels = new int[256];
            int[] bluePixels = new int[256];
            Bitmap img = new Bitmap(imagePBX.Image);
            for (int i = 0; i < img.Width; i++)
            {
                for(int j = 0; j < img.Height; j++)
                {
                    Color color = img.GetPixel(i, j);
                    redPixels[color.R] += 1;
                    greenPixels[color.G] += 1;
                    bluePixels[color.B] += 1;
                }
            }

            for(int i = 0; i < 256; i++)
            {
                Series redSeries = new Series();
                Series greenSeries = new Series();
                Series blueSeries = new Series();
                
                redSeries.Color = Color.Red;
                greenSeries.Color = Color.Green;
                blueSeries.Color = Color.Blue;
                redSeries.Points.AddXY(i, redPixels[i]);
                greenSeries.Points.AddXY(i, greenPixels[i]);
                blueSeries.Points.AddXY(i, bluePixels[i]);

                redChart.Series.Add(redSeries);
                greenChart.Series.Add(greenSeries);
                blueChart.Series.Add(blueSeries);
            }
                redChart.ChartAreas[0].AxisX.Minimum = 0;
                redChart.ChartAreas[0].AxisX.Maximum = 255;
                greenChart.ChartAreas[0].AxisX.Minimum = 0;
                greenChart.ChartAreas[0].AxisX.Maximum = 255;
                blueChart.ChartAreas[0].AxisX.Minimum = 0;
                blueChart.ChartAreas[0].AxisX.Maximum = 255;

                redChart.ChartAreas[0].AxisY.Minimum = 0;
                redChart.ChartAreas[0].AxisY.Maximum = img.Width * img.Height / 100;
                greenChart.ChartAreas[0].AxisY.Minimum = 0;
                greenChart.ChartAreas[0].AxisY.Maximum = img.Width * img.Height / 100;
                blueChart.ChartAreas[0].AxisY.Minimum = 0;
                blueChart.ChartAreas[0].AxisY.Maximum = img.Width * img.Height / 100;
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (Stream bmpStream = System.IO.File.Open(fileDialog.FileName, System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);

                    appState.Image = ResizeImage(image, imagePBX.Width, imagePBX.Height);
                    modified = new bool[imagePBX.Width, imagePBX.Height];
                }
                drawImage();
            }
        }
        private Bitmap ResizeImage(Image image, int newWidth, int newHeight)
        {
            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var originalImage = new Bitmap(image))
            {
                
                using (var graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                }

                // Save the resized image to the specified output path
            }
            return resizedImage;
        }

        private void drawImage()
        {
            imagePBX.Image = appState.Transformation(appState.Image,
                new TransformationArgs(
                    brightnessTB.Value, 
                    (float) gammaTB.Value/100.0f, 
                    (byte)contrastTB.Value, 
                    customFunctionValues, 
                    appState.Mode, 
                    modified
                    ));
            calculateHistogramData();
        }
        private void noFilterRBTN_CheckedChanged(object sender, EventArgs e)
        {
            modified = new bool[imagePBX.Width, imagePBX.Height];

            appState.Transformation = Transformation.None; 
            drawImage();
        }

        private void negationRBTN_CheckedChanged(object sender, EventArgs e)
        {
            modified = new bool[imagePBX.Width, imagePBX.Height];

            appState.Transformation = Transformation.Negate;
            controlGBX.Controls.Clear();
            drawImage();

        }

        private void changeBrightnessRBTN_CheckedChanged(object sender, EventArgs e)
        {
            modified = new bool[imagePBX.Width, imagePBX.Height];

            appState.Transformation = Transformation.ChangeBrightness;
            controlGBX.Controls.Clear();
            controlGBX.Controls.Add(brightnessTB);
            drawImage();
        }

        private void gammaCorrectionRBTN_CheckedChanged(object sender, EventArgs e)
        {
            modified = new bool[imagePBX.Width, imagePBX.Height];

            appState.Transformation = Transformation.ChangeGamma;
            controlGBX.Controls.Clear();
            controlGBX.Controls.Add(gammaTB);
            drawImage();
        }


        private void contrastRBTN_CheckedChanged(object sender, EventArgs e)
        {
            modified = new bool[imagePBX.Width, imagePBX.Height];

            appState.Transformation = Transformation.Contrast;
            controlGBX.Controls.Clear();
            controlGBX.Controls.Add(contrastTB);
            drawImage();
        }

        private void customFuncRBTN_CheckedChanged(object sender, EventArgs e)
        {
            modified = new bool[imagePBX.Width, imagePBX.Height];

            appState.Transformation = Transformation.Custom;
            controlGBX.Controls.Clear();
            controlGBX.Controls.Add(customFunctionCHT);
            drawImage();
        }

        private void modeCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectItems[modeCBX.SelectedIndex].Value is not null)
            {
                modified = new bool[imagePBX.Width, imagePBX.Height];
                appState.Mode = selectItems[modeCBX.SelectedIndex].Value ?? Mode.WholeArea;
                noFilterRBTN.Checked = true;
            }
        }

        private void imagePBX_MouseDown(object sender, MouseEventArgs e)
        {
            if (appState.Mode == Mode.WholeArea)
            {
                return;
            }
            drawing = true;
            Parallel.For(0, modified.GetLength(0), (int i) =>
            {
                Parallel.For(0, modified.GetLength(1), (int j) =>
                {
                    if ((i - e.X) * (i - e.X) + (j - e.Y) * (j - e.Y) <= radius * radius)
                    {
                        modified[i, j] = true;
                    }
                });
            });
            drawImage();
        }

        private void imagePBX_MouseMove(object sender, MouseEventArgs e)
        {
            if(appState.Mode == Mode.WholeArea || !drawing)
            {
                return;
            }
            Parallel.For(0, modified.GetLength(0), (int i) =>
            {
                Parallel.For(0, modified.GetLength(1), (int j) =>
                {
                    if ((i - e.X) * (i - e.X) + (j - e.Y) * (j - e.Y) <= radius * radius)
                    {
                        modified[i, j] = true;
                    }
                });
            });
            drawImage();
        }

        private void imagePBX_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void applyBTN_Click(object sender, EventArgs e)
        {
            modified = new bool[imagePBX.Width, imagePBX.Height];
            appState.Image = new Bitmap(imagePBX.Image);
        }
    }
}