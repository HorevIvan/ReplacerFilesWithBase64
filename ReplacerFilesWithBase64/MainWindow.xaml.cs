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

namespace ReplacerFilesWithBase64
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lines = text1.Text.Split('\n');

            if (lines.Length > 5)
            {
                var e1 = lines[3].Trim(' ');
                var e2 = lines[5].Trim(' ');

                var r1 = Replace(e1);
                var r2 = Replace(e2);

                lines[3] = lines[3].Replace(e1, r1);
                lines[5] = lines[5].Replace(e2, r2);
            }

            text2.Text = String.Join("\n", lines);
        }

        private string Replace(string base64)
        {
            var str = Base64Decode(base64);

            str = str.Replace("MSK-DPRO-PSG220", "MSK-DPRO-PSG916");
            str = str.Replace("6432", "5432");

            return Base64Encode(str);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
