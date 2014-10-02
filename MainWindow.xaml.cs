using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.IO;
using Microsoft.Win32;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            int itemCount = Convert.ToInt32(text_1.Text);
            Random rnd1 = new Random();
            int number;
            lbMain.Items.Clear();
            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
                lbMain.Items.Add(number);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            int itemCount = Convert.ToInt32(text_1.Text);
            Random rnd1 = new Random();
            int number;
            lbMain.Items.Clear();
            lbMain.Items.Add("Исходный массив");
            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
                lbMain.Items.Add(number);
            }
            myAL.Sort();
            lbMain.Items.Add("Отсортированный массив");
            foreach (int elem in myAL)
            {
                lbMain.Items.Add(elem);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

            ArrayList myAL = new ArrayList();
            int index;
            int itemCount = Convert.ToInt32(text_1.Text);
            Random rnd1 = new Random();
            int k = itemCount, x = 0;
            int[] fibarray = new int[k];
            lbMain.Items.Clear();
            lbMain.Items.Add("Исходный массив");
            for (index = 0; index < itemCount; index++)
            {
                fibarray[index] = -100 + rnd1.Next(200);
                myAL.Add(fibarray[index]);
                lbMain.Items.Add(fibarray[index]);
            }

            lbMain.Items.Add("\nКоличество элементов, соседи которых меньше: ");
            for (index = 1; index < itemCount - 1; index++)
            {
                if (fibarray[index] > fibarray[index - 1] && fibarray[index] > fibarray[index + 1]) x++;
            }

            lbMain.Items.Add(x);
            lbMain.Items.Add("\nНомер первого элемента, большего 25: ");
            int y = -1;
            for (index = 0; index < itemCount; index++)
            {
                if (fibarray[index] > 25) { y = index; break; }
            }

            if (y != -1) lbMain.Items.Add(y);
            else lbMain.Items.Add("Такого элемента нет!");

            lbMain.Items.Add("\nСумма элементов, больших второго: ");
            int sum = 0;
            for (index = 0; index < itemCount; index++)
            {
                if (fibarray[index] > fibarray[1])
                    sum = sum + fibarray[index];
            }

            lbMain.Items.Add(sum);

        }

    }

}
