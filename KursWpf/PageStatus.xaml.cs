﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace KursWpf {
    /// <summary>
    /// Логика взаимодействия для PageStatus.xaml
    /// </summary>
    public partial class PageStatus : Page, INotifyPropertyChanged
    {
        private Server _server;
        private ManualResetEvent _resetEvent = new ManualResetEvent(false);

        private double _lastLecture;
        private double _trend;

        //public SeriesCollection SeriesCollection { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Func<ChartPoint, string> PointLabel { get; set; }

        public PageStatus(Server server) {
            InitializeComponent();

            _server = server;

            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue(),
                        new ObservableValue()
                    }
                }
            };
            _trend = 8;

            PointLabel = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P})";

            DataContext = this;

            Task.Run(() => {
                var r = new Random();
                while (true) {
                    _resetEvent.WaitOne();
                    Thread.Sleep(500);
                    _trend += (r.NextDouble() > 0.3 ? 1 : -1) * r.Next(0, 5);
                    Application.Current.Dispatcher.Invoke(() => {
                        LastHourSeries[0].Values.Add(new ObservableValue(_trend));
                        LastHourSeries[0].Values.RemoveAt(0);
                        SetLecture();
                    });
                }
            });
        }


        public SeriesCollection LastHourSeries { get; set; }

        public double LastLecture {
            get => _lastLecture;
            set {
                _lastLecture = value;
                OnPropertyChanged("LastLecture");
            }
        }

        private void SetLecture() {
            var target = ((ChartValues<ObservableValue>)LastHourSeries[0].Values).Last().Value;
            var step = (target - _lastLecture) / 4;


            Task.Run(() => {
                for (var i = 0; i < 4; i++) {
                    Thread.Sleep(100);
                    LastLecture += step;
                }
                LastLecture = target;
            });

        }



        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //[DllImport("Kernel32")]
        //public static extern void AllocConsole();

        //[DllImport("Kernel32")]
        //public static extern void FreeConsole();


        private void ButtonStart_Click(object sender, RoutedEventArgs e) {


            if (!_server._serverWork)
            {
                _server.Start();
                _resetEvent.Set();

               // AllocConsole();
                //Console.WriteLine("test");


                //PointLabel = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P})";

                //DataContext = this;
            }
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e) {


            if (_server._serverWork) {
                _server.Stop(true);

                _resetEvent.Reset();
                //FreeConsole();
            }
        }

        

    }
}
