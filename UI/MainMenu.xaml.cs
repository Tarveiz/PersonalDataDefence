﻿using System;
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
using BLL.Services.BackUp;

namespace UI
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void OutPut(object sender, RoutedEventArgs e)
        {
            MessageBroker message = new MessageBroker();
            message.ReceivingMessage();
        }

        public void Change(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Работает вот так");
        }
    }
}
