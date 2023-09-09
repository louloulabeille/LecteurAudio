using LecteurAudio.ViewModel;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using MusiqueBOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using System.Windows.Threading;

namespace LecteurAudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MediaPlayer _media = new();
        private string? _path;
        private string[]? _fichiers;
        private bool _mediaPlayPause = true;    // true = play / false = pause
        private readonly DispatcherTimer _mediaPlayTimer;

        public MainWindow()
        {
            InitializeComponent();
            // volume slider
            Slider_Volume.Value = _media.Volume*100;

            _mediaPlayTimer = new() { Interval = TimeSpan.FromSeconds(0.01) };
            _mediaPlayTimer.Tick += ThreadProgressMusique;

        }

        private void Ouvrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new() { 
                Filter = "mp3 audio (*.mp3)|*.mp3|flac audio (*.flac)|*.flac|aif audio (*.aif)|*.aif",
                FilterIndex = 3,
                Multiselect = true,
                Title = "Charger votre musique.",
            };
            bool? result = openFile.ShowDialog();

            if (result == true)
            {
                _fichiers = openFile.FileNames;
                _path = new(_fichiers[0]);  // prend le premier
                List<LecteurMusiqueViewModel> musiques = new();
                int i = 1;
                foreach (string fiche in  _fichiers)
                {
                    LecteurMusiqueViewModel musique = new () {
                        Titre = new FileInfo(fiche).Name,
                        Ordre = i,
                        Path = fiche,
                    };
                    musiques.Add(musique);
                    i++;
                }
                List_Musique.ItemsSource = musiques;
            }
        }

        private void ThreadProgressMusique(object? sender, EventArgs e)
        {
            if (_media.NaturalDuration.HasTimeSpan == false) return;

            ProgressBar_Musique.Maximum = _media.NaturalDuration.TimeSpan.TotalSeconds;
            ProgressBar_Musique.Value = _media.Position.TotalSeconds;

            if (ProgressBar_Musique.Value == ProgressBar_Musique.Maximum)
            {
                Next_Musique(sender??new object(), new RoutedEventArgs());
                //Stop();
            }
        }

        private void Play ()
        {
            _media.Play();
            ProgressBar_Status.Value = 35;
            // changement icone
            Btn_Play_Pause.Content = new PackIcon { Kind = PackIconKind.Pause, };
            _mediaPlayTimer.Start();
            _mediaPlayPause = false;
        }

        private void Pause ()
        {
            _media.Pause();
            ProgressBar_Status.Value = 100;
            // changement icone
            Btn_Play_Pause.Content = new PackIcon { Kind = PackIconKind.Play, }; ;
            _mediaPlayPause = true;
        }

        private void Stop()
        {
            _mediaPlayPause = true;
            ProgressBar_Status.Value = 100;
            ProgressBar_Musique.Value = 0;
            Btn_Play_Pause.Content = new PackIcon { Kind = PackIconKind.Play, };
            _mediaPlayTimer.Stop();
        }

        private void Play_Musique(object sender, RoutedEventArgs e)
        {
            if (_path is null) return;

            if (_mediaPlayPause)
            {
                if (_media.Source is null ) _media.Open(new Uri(_path));
                if (_fichiers is not null)
                {
                    // la lecture se lance en changeant le selected index de la liste de musique
                    // avec event SelectionChanged sur la la liste View Liste_Musique
                    if (List_Musique.SelectedIndex != Array.IndexOf(_fichiers, _path))
                        List_Musique.SelectedIndex = Array.IndexOf(_fichiers, _path);
                    else // en cas de pause on relance juste le mediaplayer
                        Play();
                }
            }
            else
            {
                Pause();
            }
        }

        private void Stop_Musique(object sender, RoutedEventArgs e)
        {
            _media.Stop();
            Stop();
        }

        private void Slider_Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { // volume Media 0 - 1
            _media.Volume = Slider_Volume.Value/100;
        }

        private void Stop_Song(object sender, RoutedEventArgs e)
        {
            _media.IsMuted = !_media.IsMuted;
            if (_media.IsMuted) Btn_Song.Content = new PackIcon { Kind = PackIconKind.VolumeOff, };
            else Btn_Song.Content = new PackIcon { Kind = PackIconKind.VolumeHigh, };
        }

        private void List_Play_Musique(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            if (e.AddedItems[0] is LecteurMusiqueViewModel musique)
            {
                Stop();
                _path = musique.Path;
                _media.Open(new Uri(_path));
                Play();
            }
        }

        private void Next_Musique(object sender, RoutedEventArgs e)
        {
            if (_fichiers is null ||_path is null) return;
            int index = Array.IndexOf(_fichiers,_path);
            if (index == -1 || index >= _fichiers.Length - 1) return;


            Stop();
            List_Musique.SelectedIndex = index + 1;
            _path = _fichiers[index+1];
            _media.Open(new Uri(_path));
            Play();
        }

        private void Last_Musique(object sender, RoutedEventArgs e)
        {
            if (_fichiers is null || _path is null) return;
            int index = Array.IndexOf(_fichiers, _path);
            if (index == -1 || index == 0) return;

            Stop();
            List_Musique.SelectedIndex = index - 1;
            _path = _fichiers[index - 1];
            _media.Open(new Uri(_path));
            Play();
        }
    }
}
