using System;
using System.Windows.Forms;

namespace EmotionalStateDetection
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", $"C:\\emotionalstate.json");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreenForm());
        }
        public static string Generate(int number, string nominativ, string genetiv, string plural)
        {
            var titles = new[] { nominativ, genetiv, plural };
            var cases = new[] { 2, 0, 1, 1, 1, 2 };
            return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
        }
        public static void ChooseFolder(TextBox textBox, FolderBrowserDialog folderBrowserDialog)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textBox.Text = folderBrowserDialog.SelectedPath;
        }

    }
}
