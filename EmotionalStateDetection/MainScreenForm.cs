using CsvHelper;
using Google.Cloud.Vision.V1;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EmotionalStateDetection
{
    public partial class MainScreenForm : Form
    {
        // Объявление переменных, используемых для создания изображений
        Thread camera;
        Mat frame;
        VideoCapture capture;
        Bitmap image;
        // Маркер, отображающий записывается ли изображение с камеры
        bool cameraShooting = false;
        // Маркер, отображающий идёт ли запись
        bool capturing = false;
        // Счётчик сделанных снимков
        int totalshots = 0;

        // Класс, использующийся для заполнения CSV-файла данными, полученными с сервиса
        public class FaceDetectionData
        {
            // Номер снимка
            public string Case { get; set; }
            // Время записи снимков
            public string RecordingTime { get; set; }
            // Поле, отражающее выражение эмоции "Веселье"
            public string Joy { get; set; }
            // Поле, отражающее выражение эмоции "Удивление"
            public string Surprise { get; set; }
            // Поле, отражающее выражение эмоции "Грусть"
            public string Sorrow { get; set; }
            // Поле, отражающее выражение эмоции "Злость"
            public string Anger { get; set; }
        }

        // Создание потока, в котором проводится запись изображения с камеры
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        // Вывод изображения с камеры в превью в главном окне программы
        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                cameraShooting = true;
                while (cameraShooting)
                {
                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBoxImage.Image != null)
                    {
                        pictureBoxImage.Image.Dispose();
                    }
                    pictureBoxImage.Image = image;
                }
            }
        }
        // Отображение главного окна программы
        public MainScreenForm()
        {
            InitializeComponent();
            CaptureCamera();
        }

        // Сигнал, прекащающий использование камеры при закрытии программы
        private void MainScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Abort();
        }

        // Сигнал, открывающий диалог с выбором директории для сохранения
        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            Program.ChooseFolder(textBoxDirectory, folderBrowserDialogDirectory);
        }

        // Сигнал, позволяющий начать запись только тогда, когда интервал имеет ненулевое значение и есть изображение с камеры
        private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownInterval.Value != 0 && cameraShooting == true)
                buttonStart.Enabled = true;
            else
                buttonStart.Enabled = false;
        }

        // Отдельный поток в котором проводится запись скриншотов и/или снимков с камеры
        private void backgroundWorkerShooting_DoWork(object sender, DoWorkEventArgs e)
        {
            // Условие проверяющее, не остановлена ли запись
            while (capturing == true)
            {
                // Выполнение снимков экрана, если пользователь поставил галочку в поле "Делать сники экрана"
                if (checkBoxScreenshot.Checked == true)
                    ScreenShotCapturing.TakeScreenshot(textBoxDirectory);
                SnapShotCapturing.TakeSnapshot(textBoxDirectory, frame);
                // Увелечение значения сделанных снимков каждый раз, когда выполняется снимок
                totalshots++;
                // Управление интервалом записи снимков в соответсвии с заданным пользователем
                Thread.Sleep(1000 * Convert.ToInt32(numericUpDownInterval.Value));
            }
        }

        // Сигнал, выполняющий действия по нажатию кнопки "Начать запись"/"Завершить запись"
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Если начинается запись
            if (capturing == false)
            {
                // Задание директории, по которой будет производится сохранение
                DirectoryInfo dirInfo = new DirectoryInfo(textBoxDirectory.Text);
                // Создание папки "snapshots", в которой будут хранится снимки с камеры
                dirInfo.CreateSubdirectory("snapshots");
                // Создание папки "screenshots", в которой будут хранится снимки экрана
                dirInfo.CreateSubdirectory("screenshots");
                // Изменение текста кнопки с "Начать запись" на "Остановить"
                buttonStart.Text = "Остановить";
                // Задание маркеру, отвечающему за запись значение "true"
                capturing = true;
                // Делает неактивными все элементы кроме кнопки "Остановить"
                panelParameters.Enabled = false;
                buttonDetect.Enabled = false;
                // Запускает отдельный поток с записью снимков
                backgroundWorkerShooting.RunWorkerAsync();
                // Отображение сообщения о том, что запись началась
                MessageBox.Show("Запись началась");
            }
            // Если завершается запись
            else
            {
                // Изменение текста кнопки с "Остановить" на "Начать запись" 
                buttonStart.Text = "Начать запись";
                // Задание маркеру, отвечающему за запись значение "false"
                capturing = false;
                // Делает активными все элементы
                panelParameters.Enabled = true;
                buttonDetect.Enabled = true;
                // Завершает отдельный поток с записью снимков
                backgroundWorkerShooting.CancelAsync();
                // Отображение сообщения с количеством сделанных снимков
                MessageBox.Show($"{Program.Generate(totalshots, $"Был сделан {totalshots} снимок", $"Было сделано {totalshots} снимков", $"Было сделано {totalshots} снимков")}");
            }
        }

        // Сигнал, выполняющий действия по нажатию кнопки "Распознать"
        private void buttonDetect_Click(object sender, EventArgs e)
        {
            // Запускает отдельный поток с отправкой снимков для анализа и записью результатов
            backgroundWorkerDetection.RunWorkerAsync();
        }

        // Отдельнй поток с отправкой снимков для анализа
        private void backgroundWorkerDetection_DoWork(object sender, DoWorkEventArgs e)
        {
            // Объявление переменной с количеством отправляемых снимков
            int cases = 1;
            // Создание клиента для работы с Google Vision API
            ImageAnnotatorClient client = ImageAnnotatorClient.Create();
            // Создание списка, в котором будут хранится результаты анализа
            List<FaceDetectionData> faceDetectionData = new List<FaceDetectionData> { };
            // Создание массива содержащего пути ко всем файлам, отправляемым на анализ
            string[] allfiles = Directory.GetFiles(textBoxDirectory.Text + "\\snapshots");
            // Цикл, в котором каждый файл отправляется на анализ, а полученные результаты записываются в созданный CSV-файл
            foreach (string filename in allfiles)
            {
                // Берётся отдельный снимок по пути из списка
                Google.Cloud.Vision.V1.Image image = Google.Cloud.Vision.V1.Image.FromFile($"{filename}");
                // Результат записывается в списке
                IReadOnlyList<FaceAnnotation> result = client.DetectFaces(image);
                // Цикл в котором каждый результат, в нужном представлении, записывается в CSV-файл
                foreach (FaceAnnotation face in result)
                {
                    faceDetectionData.Add(new FaceDetectionData() { Case = $"{cases++}", RecordingTime = $"{Path.GetFileNameWithoutExtension(filename)}", Joy = $"{face.JoyLikelihood}", Surprise = $"{face.SurpriseLikelihood}", Sorrow = $"{face.SorrowLikelihood}", Anger = $"{face.AngerLikelihood}" });
                    using (StreamWriter streamReader = new StreamWriter($"{textBoxDirectory.Text}\\table.csv"))
                    {
                        using (CsvWriter csvReader = new CsvWriter(streamReader, CultureInfo.InvariantCulture))
                        {
                            csvReader.Configuration.Delimiter = ",";
                            csvReader.WriteRecords(faceDetectionData);
                        }
                    }
                }
            }
            // Отображение сообщения о том, что анализ проведён и результаты записаны
            MessageBox.Show("Результаты записаны");
            // Завершает отдельный поток, в котором проводится анализ снимков и запись результатов
            backgroundWorkerDetection.CancelAsync();
        }

        // Сигнал, отображающий состояние записи в трее при сворачивании окна
        private void MainScreenForm_Resize(object sender, EventArgs e)
        {
            // Если окно свернуто
            if (this.WindowState == FormWindowState.Minimized)
            {
                // И если идёт запись
                if (capturing == true)
                {
                    // В трей помещается соответствующая иконка с текстом "Идёт запись"
                    notifyIconCapturing.Icon = new Icon("Capturing.ico");
                    notifyIconCapturing.Text = "Идёт запись";
                }
                // А если запись не идёт
                else
                {
                    // В трей помещается сответствующая иконка с текстом "Запись не идёт"
                    notifyIconCapturing.Icon = new Icon("NotCapturing.ico");
                    notifyIconCapturing.Text = "Запись не идёт";
                }
                notifyIconCapturing.Visible = true;
            }
        }
        // Сигнал, разворачивающий окно программы при нажатии на иконку в трее
        private void notifyIconCapturing_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIconCapturing.Visible = false;
        }

        private void MainScreenForm_Load(object sender, EventArgs e)
        {

        }
    }
}
