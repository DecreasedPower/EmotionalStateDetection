using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace EmotionalStateDetection
{
    class SnapShotCapturing
    {
        // Метод, отвечающий за создание снимков с камеры
        public static void TakeSnapshot(TextBox textBox, Mat frame)
        {
            // Захват изображения с камеры
            Bitmap bitmap = BitmapConverter.ToBitmap(frame);
            // Сохранение изображения по пути, указанному пользователем
            bitmap.Save($@"{textBox.Text}\snapshots\{DateTime.Now:dd_MM_yyyy_HH_mm_ss}.png", ImageFormat.Png);
            // Деструктор, удаляющий изображение из оперативной памяти
            bitmap.Dispose();
        }
    }
}
