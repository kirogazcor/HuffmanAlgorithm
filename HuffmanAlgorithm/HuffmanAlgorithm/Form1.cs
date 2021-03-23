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

namespace HuffmanAlgorithm
{
    public partial class Form1 : Form
    {
        string InPath, OutPath; // Имя загружаемого текстового файла
                                // и сохраняемого кодированного 
        byte[] CodeHuffman;     // Массив байтов для декодирования
        public Form1()
        {
            InitializeComponent();
            InPath = null;
            OutPath = "coding.htf";     // Имя кодированного файла по умолчанию
        }

        private void EncodingButton_Click(object sender, EventArgs e)
        {   
            // Кодирование текстового сообщения и сохранение в файл кодированного сообщения
            if(InPath != null)OutPath = InPath.Substring(0, InPath.Length - 3) + "htf";
            // При загрузке текста из файла имя кодированного 
            // файла отличается от него только расширением
            FileStream fStream = new FileStream(OutPath, FileMode.Create, FileAccess.Write);
            EncodingHuffman Coding = new EncodingHuffman(TextBoxIO.Text);
            byte[] OutBytes = Coding.Encode(TextBoxIO.Text);
            // Кодирование текста
            Calculation source = new Calculation(TextBoxIO.Text);
            Calculation received = new Calculation(OutBytes);
            source.Calc(received.bits);      // Вычисления для исходного файла
            HiLabel.Text = "H исх = " + Convert.ToString(source.H);
            Rilabel.Text = "R исх = " + Convert.ToString(source.r);
            Klabel.Text = "K сжатия = " + Convert.ToString(source.Compres);
            received.Calc(source.bits);    // Вычисления для кодированного файла
            HkLabel.Text = "H код = " + Convert.ToString(received.H);
            Rklabel.Text = "R код = " + Convert.ToString(received.r);                   
            fStream.Write(OutBytes, 0, OutBytes.Length);
            // Сохранение кодированного файла
            fStream.Dispose();
            MessageBox.Show("Текст кодированный алгоритмом Хаффмана сохранен в файл \"" + OutPath + "\"");

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Загрузка текстового файла и вывод в текстовую область формы
            OpenTextDialog.Filter = "Текстовый файл|*.txt";
            if(OpenTextDialog.ShowDialog() == DialogResult.OK)
            {
                InPath = OpenTextDialog.FileName;
                TextBoxIO.Clear();
                StreamReader stream = new StreamReader(InPath, Encoding.GetEncoding(1251));
                while (!stream.EndOfStream)
                {
                    TextBoxIO.Text += stream.ReadLine() + Environment.NewLine;
                }
                stream.Dispose();
            }
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            // Загрузка кодированного файла в массив байтов
            OpenTextDialog.Filter = "Кодированный файл|*.htf";
            if (OpenTextDialog.ShowDialog() == DialogResult.OK)
            {
                InPath = OpenTextDialog.FileName;
                FileStream fstream = new FileStream(InPath,FileMode.Open,FileAccess.Read);
                CodeHuffman = new byte[(int)fstream.Length];
                fstream.Read(CodeHuffman,0,(int)fstream.Length);
                fstream.Dispose();
            }
        }

        private void DecodingButton_Click(object sender, EventArgs e)
        {
            // Декодирование массива байтов и вывод полученного текста
            // в текстовую область формы
            try
            {
                if (CodeHuffman != null)
                {
                    EncodingHuffman Coding = new EncodingHuffman(CodeHuffman);
                    TextBoxIO.Clear();
                    TextBoxIO.Text = Coding.Decode();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
