using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataWorks_Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int s = RomanToInt(textBox.Text);
            if (s != 0)
            {
                label.Content = s;
            }
            else
            {
                label.Content = "Неверный ввод";
            }
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool b = CheckBrackets(textBox1.Text);
            if (b)
            {
                label1.Content="Скобочная структура сбалансирована";
            }
            else
            {
                label1.Content = "Скобочная структура НЕ сбалансирована";
            }
        }

        public static int RomanToInt(string text)
        {
            Dictionary<char, int> numbers;
            numbers = new Dictionary<char, int>
            {
                { 'I', 1},
                { 'V', 5},
                { 'X', 10},
                { 'L', 50},
                { 'C', 100},
                { 'D', 500},
                { 'M', 1000}
            };
            int result = 0, prevValue = 0;
            foreach (char chr in text)
            {
                // если такого символа нету 
                if (!numbers.ContainsKey(chr))
                {
                    // выход из метода 
                    return 0;
                }
                // получаем текущее значение из словарика 
                int curValue = numbers[chr];
                // складываем в результат 
                result += curValue;
                // если предыдущее значение не равно 0 И меньше текущего 
                if (prevValue != 0 && prevValue < curValue)
                {
                    // если предыдущее значение это 1, а текущее 5 или 10 , ИЛИ 
                    // 10 с 50 или 100 
                    // 100 с 500 или 1000 
                    if (prevValue == 1 &&
                    (curValue == 5 || curValue == 10) ||
                    prevValue == 10 &&
                    (curValue == 50 || curValue == 100) ||
                    prevValue == 100 &&
                    (curValue == 500 || curValue == 1000))
                    {
                        // результат уменьшить на 
                        result -= 2 * prevValue;
                    }
                    else
                    {
                        return 0;
                    }
                }
                // предыдущему значению даём текущее 
                prevValue = curValue;
            }
            return result;
        }
        public static bool CheckBrackets(string text)
        {
            bool answer = false;
            int rang = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    rang++;
                }
                if (text[i] == ')')
                {
                    rang--;
                }
            }
            if (rang == 0)
            {
                answer = true;
            }
            else
            {
                answer = false;
            }
            return answer;
        }

        public static void abc()
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            // добавление элементов
            linkedList.Add("A");
            linkedList.Add("B");
            linkedList.Add("C");
            linkedList.Add("D");
            linkedList.Add("E");

            MessageBox.Show("прямой порядок");
            foreach (var item in linkedList)
            {
                MessageBox.Show(item);
            }

            MessageBox.Show("простой обратный проход для сравнения");
            foreach (var item in linkedList.BackEnumerator())
            {
                MessageBox.Show(item);
            }
            MessageBox.Show("теперь лист развёрнут в обратном порядке");
            linkedList.Reverse();
            foreach (var item in linkedList)
            {
                MessageBox.Show(item);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            abc();
        }
    }
}
