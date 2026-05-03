using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PWebBrowser
{
    public partial class Form1 : Form
    {
        private string strINIFile = "browser.ini";
        private const string HeadWindow = "[Window]";
        private const string HeadBrowser = "[Browser]";


        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик события закрытия формы
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(strINIFile, false, Encoding.UTF8))
                {
                    // Секция окна
                    writer.WriteLine("[HeadWindow]");
                    writer.WriteLine($"Left={this.Left}");
                    writer.WriteLine($"Top={this.Top}");
                    writer.WriteLine($"Width={this.Width}");
                    writer.WriteLine($"Height={this.Height}");
                    writer.WriteLine($"WindowState={this.WindowState}");

                    // Секция браузера
                    writer.WriteLine("[HeadBrowser]");
                    writer.WriteLine($"URL={wbBrowser.Url}");
                }
            }
            catch
            {
                // Не удалось сохранить
            }
        }

        // Обработчик события загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Если файла нет – форма загружается с параметрами по умолчанию
            if (!File.Exists(strINIFile))
                return;

            try
            {
                using (StreamReader reader = new StreamReader(strINIFile))
                {
                    string line;
                    string currentSection = "";

                    // Переменные для временного хранения считанных значений
                    int left = this.Left, top = this.Top;
                    int width = this.Width, height = this.Height;
                    FormWindowState windowState = this.WindowState;
                    string url = wbBrowser.Url?.ToString() ?? "about:blank";

                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();

                        // Определяем секцию
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            currentSection = line.Substring(1, line.Length - 2).Trim();
                            continue;
                        }

                        // Обрабатываем ключ=значение только если находимся внутри секции
                        int eqPos = line.IndexOf('=');
                        if (eqPos < 0)
                            continue;

                        string key = line.Substring(0, eqPos).Trim();
                        string value = line.Substring(eqPos + 1).Trim();

                        if (currentSection == "HeadWindow")
                        {
                            switch (key)
                            {
                                case "Left":
                                    int.TryParse(value, out left);
                                    break;
                                case "Top":
                                    int.TryParse(value, out top);
                                    break;
                                case "Width":
                                    if (int.TryParse(value, out int w) && w > 0)
                                        width = w;
                                    break;
                                case "Height":
                                    if (int.TryParse(value, out int h) && h > 0)
                                        height = h;
                                    break;
                                case "WindowState":
                                    Enum.TryParse(value, true, out windowState);
                                    break;
                            }
                        }
                        else if (currentSection == "HeadBrowser")
                        {
                            if (key == "URL")
                            {
                                if (!string.IsNullOrWhiteSpace(value))
                                    url = value;
                            }
                        }
                    }

                    // Применяем все параметры после чтения всего файла
                    this.Left = left;
                    this.Top = top;
                    this.Width = width;
                    this.Height = height;
                    this.WindowState = windowState;
                    wbBrowser.Url = new Uri(url);
                }
            }
            catch
            {
                // Ошибка чтения
            }
        }


        // Обработчик события нажатия клавиши
        private void txtURL_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (e.KeyChar == (char)Keys.Return)
            {
                //MessageBox.Show(txtURL.Text);
                wbBrowser.Navigate(txtURL.Text);
                e.Handled = true;
            }
        }
    }
}
