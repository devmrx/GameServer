﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace KursWpf {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Server _server;

        public MainWindow() {

            InitializeComponent();

            _server = new Server();
           
           
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e) {

        }

        private void BtnClickStatusPage(object sender, RoutedEventArgs e) {
            Main.Content = new PageStatus();
        }



        private void BtnClickGamesPage(object sender, RoutedEventArgs e) {
            Main.Content = new PageGames();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            Main.Content = new PageUsers(_server);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Main.Content = new PageSettings();
        }


    }
}