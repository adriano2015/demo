using AgendaDemo.modelo;
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
            txtEstadoContato.MaxLength = 2;
            txtCidadeContato.MaxLength = 10;
            LimparCampos();
            ControlaBotoes(1);
            ControlaCampos(1);

        }
        //*********************************************************************** metodos para tratamento de tela *********************************
        private void LimparCampos()
        {
            txtNomeContato.Clear();
            txtEnderecoContato.Clear();
            txtTelefonesContato.Clear();
            txtCelularContato.Clear();
            txtEmailContato.Clear();
            txtLinkedinContato.Clear();
            txtCepContato.Clear();
            txtPesquisaContato.Clear();
            txtCidadeContato.Clear();
            txtEstadoContato.Clear();
            dtPikerDataNascimentoContato.SelectedDate = DateTime.Now;




        }
        private void ControlaBotoes(int opc)
        {
            BtnNovoContato.IsEnabled = false;
            BtnSalvarContato.IsEnabled = false;
            BtnEditarContato.IsEnabled = false;
            BtnExcluirContato.IsEnabled = false;
            BtnCancelaOperacao.IsEnabled = false;
            

            if (opc == 1)
            {
                BtnNovoContato.IsEnabled = true;
            }

            if (opc == 2)
            {
                BtnCancelaOperacao.IsEnabled = true;
                BtnSalvarContato.IsEnabled = true;
                

            }
            if (opc == 3)
            {
                BtnEditarContato.IsEnabled = true;
                BtnExcluirContato.IsEnabled = true;
                BtnCancelaOperacao.IsEnabled = true;
                

            }


        }
        private void ControlaCampos(int opc)
        {
            txtNomeContato.IsEnabled = false;
            txtEnderecoContato.IsEnabled = false;
            txtTelefonesContato.IsEnabled = false;
            txtCelularContato.IsEnabled = false;
            txtEmailContato.IsEnabled = false;
            txtLinkedinContato.IsEnabled = false;
            txtCepContato.IsEnabled = false;
            txtEstadoContato.IsEnabled = false;
            txtCidadeContato.IsEnabled = false;
            dtPikerDataNascimentoContato.IsEnabled = false;


            if (opc == 1)
            {
                txtNomeContato.IsEnabled = false;
                txtEnderecoContato.IsEnabled = false;
                txtTelefonesContato.IsEnabled = false;
                txtCelularContato.IsEnabled = false;
                txtEmailContato.IsEnabled = false;
                txtLinkedinContato.IsEnabled = false;
                txtCepContato.IsEnabled = false;
                txtEstadoContato.IsEnabled = false;
                txtCidadeContato.IsEnabled = false;
                dtPikerDataNascimentoContato.IsEnabled = false;



            }
            if (opc == 2)
            {
                txtNomeContato.IsEnabled = true;
                txtEnderecoContato.IsEnabled = true;
                txtTelefonesContato.IsEnabled = true;
                txtCelularContato.IsEnabled = true;
                txtEmailContato.IsEnabled = true;
                txtLinkedinContato.IsEnabled = true;
                txtCepContato.IsEnabled = true;
                txtPesquisaContato.IsEnabled = true;
                txtEstadoContato.IsEnabled = true;
                txtCidadeContato.IsEnabled = true;
                dtPikerDataNascimentoContato.IsEnabled = true;

            }

        }
        // **********************************************************************************operações com botoes ***************************************
        private void BtnNovoContato_Click(object sender, RoutedEventArgs e)
        {
            ControlaCampos(2);
            ControlaBotoes(2);


        }

        private void BtnSalvarContato_Click(object sender, RoutedEventArgs e)
        {
            ControlaBotoes(1);
            ControlaCampos(1);

            contatosAgenda contatoAgenda = new contatosAgenda();
            contatoAgenda.NomeContato = txtNomeContato.Text;
            contatoAgenda.EnderecoContato = txtEnderecoContato.Text;
            contatoAgenda.TelefonesContato = txtTelefonesContato.Text;
            contatoAgenda.CelularContato = txtCelularContato.Text;
            contatoAgenda.EmailContato = txtEmailContato.Text;
            contatoAgenda.LinkedinContato = txtLinkedinContato.Text;
            contatoAgenda.CepContato = txtCepContato.Text;
            contatoAgenda.DataNascimentoContato = dtPikerDataNascimentoContato.SelectedDate;
            contatoAgenda.CidadeContato = txtCidadeContato.Text;
            contatoAgenda.UFContato = txtEstadoContato.Text;

            try
            {
                agendaEntities1 agenda = new agendaEntities1();
                agenda.contatosAgendas.Add(contatoAgenda);
                agenda.SaveChanges();
                JanelaAtencao JA = new JanelaAtencao();
                JA.Show();
                JA.RecebeMensagem("Contato salvo com sucesso!!!!!!!!!!!!!");

                ListarContatos();
                LimparCampos();

            }
            catch
            {
                JanelaAtencao JA = new JanelaAtencao();
                JA.Show();
                JA.RecebeMensagem("Erro!!!!!!!!!!");

            }






        }
        //******************************************************** dataGrid ************************************************************************
        private void ListarContatos()
        {
            agendaEntities1 lista = new agendaEntities1();
            var consulta = lista.contatosAgendas;
            dtGRidContatos.ItemsSource = consulta.ToList();
            dtGRidContatos.Columns[0].Header = "Código";
            dtGRidContatos.Columns[1].Header = "Nome";
            dtGRidContatos.Columns[2].Header = "Endereço";
            dtGRidContatos.Columns[3].Header = "Telefone";
            dtGRidContatos.Columns[4].Header = "Celular";
            dtGRidContatos.Columns[5].Header = "email";
            dtGRidContatos.Columns[6].Header = "Linkedin";
            dtGRidContatos.Columns[7].Header = "CEP";
            dtGRidContatos.Columns[8].Header = "Pesquisa";
            dtGRidContatos.Columns[9].Header = "Aniversário";
            dtGRidContatos.Columns[10].Header = "Estado";
            dtGRidContatos.Columns[11].Header = "Cidade";

        }

        private void dtGRidContatos_Loaded(object sender, RoutedEventArgs e)
        {
            this.ListarContatos();
        }

        private void dtGRidContatos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtGRidContatos.SelectedIndex >= 0)
            {
                contatosAgenda contatos = (contatosAgenda)dtGRidContatos.Items[dtGRidContatos.SelectedIndex];
                int codigoInternoContato = contatos.codContato;
                txtNomeContato.Text = contatos.NomeContato;
                txtEnderecoContato.Text = contatos.EnderecoContato;
                txtTelefonesContato.Text = contatos.TelefonesContato;
                txtCelularContato.Text = contatos.CelularContato;
                txtEmailContato.Text = contatos.EmailContato;
                txtLinkedinContato.Text = contatos.LinkedinContato;
                txtCepContato.Text = contatos.CepContato;
                txtCidadeContato.Text = contatos.CidadeContato;
                txtEstadoContato.Text = contatos.UFContato;

            }
        }

    }
}
