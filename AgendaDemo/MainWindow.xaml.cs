﻿using AgendaDemo.modelo;
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
            dtPikerDataNascimentoContato.SelectedDate = DateTime.Now;




        }
        private void ControlaBotoes (int opc)
        {
            BtnNovoContato.IsEnabled = false;
            BtnSalvarContato.IsEnabled = false;
            BtnEditarContato.IsEnabled = false;
            BtnExcluirContato.IsEnabled = false;
            BtnCancelaOperacao.IsEnabled = false;
            BtnProcurarEnderecoContato.IsEnabled = false;

            if(opc == 1)
            {
                BtnNovoContato.IsEnabled = true;
            }

            if(opc == 2)
            {
                BtnCancelaOperacao.IsEnabled = true;
                BtnSalvarContato.IsEnabled = true;
                BtnProcurarEnderecoContato.IsEnabled = true;

            }
            if(opc == 3)
            {
                BtnEditarContato.IsEnabled = true;
                BtnExcluirContato.IsEnabled = true;
                BtnCancelaOperacao.IsEnabled = true;
                BtnProcurarEnderecoContato.IsEnabled = true;

            }

            
        }
        private void ControlaCampos (int opc)
        {
            txtNomeContato.IsEnabled = false;
            txtEnderecoContato.IsEnabled = false;
            txtTelefonesContato.IsEnabled = false;
            txtCelularContato.IsEnabled = false;
            txtEmailContato.IsEnabled = false;
            txtLinkedinContato.IsEnabled = false;
            txtCepContato.IsEnabled = false;
            

            if(opc == 1)
            {
                txtNomeContato.IsEnabled = false;
                txtEnderecoContato.IsEnabled = false;
                txtTelefonesContato.IsEnabled = false;
                txtCelularContato.IsEnabled = false;
                txtEmailContato.IsEnabled = false;
                txtLinkedinContato.IsEnabled = false;
                txtCepContato.IsEnabled = false;
                
                

            }
            if(opc == 2)
            {
                txtNomeContato.IsEnabled = true;
                txtEnderecoContato.IsEnabled = true;
                txtTelefonesContato.IsEnabled = true;
                txtCelularContato.IsEnabled = true;
                txtEmailContato.IsEnabled = true;
                txtLinkedinContato.IsEnabled = true;
                txtCepContato.IsEnabled = true;
                txtPesquisaContato.IsEnabled = true;

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

            try
            {
                agendaEntities1 agenda = new agendaEntities1();
                agenda.contatosAgendas.Add(contatoAgenda);
                agenda.SaveChanges();
                MessageBox.Show("Contato salvo com sucesso");
                LimparCampos();

            }
            catch
            {
                MessageBox.Show("Erro");
            }






        }
    }
}
