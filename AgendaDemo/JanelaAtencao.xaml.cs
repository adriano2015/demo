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
using System.Windows.Shapes;

namespace AgendaDemo
{
    /// <summary>
    /// Lógica interna para JanelaAtencao.xaml
    /// </summary>
    public partial class JanelaAtencao : Window
    {
        public JanelaAtencao()
        {
            InitializeComponent();
        }

        public void RecebeMensagem(string msg)
        {
            LabelRecebeMenssagem.Content = msg;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
