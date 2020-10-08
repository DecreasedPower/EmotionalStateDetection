using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace EmotionalStateDetection
{
    class ScreenShotCapturing
    {
        // Метод, отвечающий за создание скриншотов
        public static void TakeScreenshot(TextBox textBoxDirectory)
        {
            // Захват скриншота с главного экрана. Изображение имеет его разрешение
            Bitmap captureBitmap = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height, PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            // Сохранение скриншота, по пути, указанному пользователем
            captureBitmap.Save($@"{textBoxDirectory.Text}\screenshots\{DateTime.Now:dd_MM_yyyy_HH_mm_ss}.png", ImageFormat.Png);
            // Деструкторы, удаляющие изображение из оперативной памяти после сохранения
            captureBitmap.Dispose();
            captureGraphics.Dispose();
        }
    }
}
