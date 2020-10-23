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

namespace Atbash
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        static int Check_mod2(string str, int n)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[n] == str[i])
                    count++;
            }
            if (count / 2 != 0)
                return 1;
            else
                return 2;
        }

        private void Btm_Start_Click(object sender, RoutedEventArgs e)
        {
            string str = tbl_Get.Text;
            char[] text;
            text = str.ToCharArray(0, str.Length);   //превод строки в массив символов

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    if (Char.IsUpper(str[i]))
                    {
                        if (str[i] >= 'A' && str[i] <= 'Z')     
                        {
                            //str = str.Replace(str[i], (char)(90 - ((int)str[i] - 65)));       //меняет все подобные символы в строке( если четное количество одной буквы меняет дважды, так что буква в итоге не меняется)
                            text[i] = (char)(90 - ((int)text[i] - 65));             //меняет символ исходя из кода символа
                        }
                        else if (str[i] >= 'А' && str[i] <= 'Я')
                        {
                            text[i] = (char)(1071 - ((int)text[i] - 1040));
                        }
                    }
                    else
                    {
                        if (str[i] >= 'a' && str[i] <= 'z')
                        {
                            text[i] = (char)(122 - ((int)text[i] - 97));
                        }
                        else if (str[i] >= 'а' && str[i] <= 'я')
                        {
                            text[i] = (char)(1103 - ((int)text[i] - 1072));
                        }
                    }
                }
            }

            string res = new string(text);
            tbl_Out.Text = String.Format("{0}", res);
        }
    }
}
