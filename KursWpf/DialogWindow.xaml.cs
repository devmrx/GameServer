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

namespace KursWpf {
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window {
        public DialogWindow(string text) {
            InitializeComponent();

            QuestionText.Text = text;
        }

        private void Accept_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {

        }
    }
}
