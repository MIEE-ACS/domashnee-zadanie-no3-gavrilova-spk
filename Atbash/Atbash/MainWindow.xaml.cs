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
                        else if (str[i] >= 'А' && str[i] <= 'Я' || text[i] == 'Ё')
                        {
                            if (text[i] == 'Ё')
                                text[i] = 'Щ';
                            else if (text[i] == 'Щ')
                                text[i] = 'Ё';
                            else if ( ((int)text[i] < 1046 || (int)text[i] > 1065) && text[i] != 'Ё')
                                text[i] = (char)(1071 - ((int)text[i] - 1040));
                            else
                                text[i] = (char)(1071 - ((int)text[i] - 1040) - 1);
                        }
                    }
                    else
                    {
                        if (str[i] >= 'a' && str[i] <= 'z')
                        {
                            text[i] = (char)(122 - ((int)text[i] - 97));
                        }
                        else if (str[i] >= 'а' && str[i] <= 'я'  || text[i] == 'ё')
                        {
                           // text[i] = (char)(1103 - ((int)text[i] - 1072));
                            if ((int)text[i] < 1078 || (int)text[i] > 1097 && text[i] != 'ё')
                                text[i] = (char)(1103 - ((int)text[i] - 1072));
                            else if (text[i] == 'ё')
                                text[i] = 'щ';
                            else if (text[i] == 'щ')
                                text[i] = 'ё';
                            else
                                text[i] = (char)(1103 - ((int)text[i] - 1072) - 1);
                        }
                    }
                }
            }

            string res = new string(text);
            tbl_Out.Text = String.Format("{0}", res);
        }
    }
}
