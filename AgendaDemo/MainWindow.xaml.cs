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

namespace AgendaDemo
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtNomeContato.MaxLength = 39;
            txtEnderecoContato.MaxLength = 39;
            txtTelefonesContato.MaxLength = 39;
            txtCelularContato.MaxLength = 39;
            txtEmailContato.MaxLength = 39;
            txtLinkedinContato.MaxLength = 39;
            txtCepContato.MaxLength = 8;
            txtPesquisaContato.MaxLength = 39;
        }
    }
}
