using Microsoft.Win32;
using Music.controller;
using Music.util;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Music.view
{
    /// <summary>
    /// Логика взаимодействия для CreateSongWindow.xaml
    /// </summary>
    public partial class CreateSongWindow : Window
    {
        private User user;
        private Song song;
        private SongValidation validation;
        private MediaPlayer mediaPlayer;
        private Controller controller;
        private string FilePath { get; set; }

        public CreateSongWindow(User user)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            this.user = user;
            song = new Song();
            validation = new SongValidation();
            mediaPlayer = new MediaPlayer();
            controller = new Controller();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            if (openFileDialog.ShowDialog() == true)
            {

                mediaPlayer.Open(new Uri(openFileDialog.FileName));


                FilePath = openFileDialog.FileName;
                Thread.Sleep(2000);
                song.Name = parseName(openFileDialog.FileName);

                song.Duraction = parseDuraction(mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                song.NumberOfPlays = 0;
                mediaPlayer.Close();
            }


            UpdateButton.IsEnabled = false;
        }
        public CreateSongWindow(User user, Song song)
        {
            this.user = user;
            this.song = song;
            validation = new SongValidation();
            controller = new Controller();

            InitializeComponent();
            CreateButton.IsEnabled = false;
        }

        private int parseDuraction(string str)
        {
            string[] arr = str.Split(':');
            return Convert.ToInt32(arr[0]) * 60 + Convert.ToInt32(arr[1]);
        }

        private void goToAdminWindow(object sender, RoutedEventArgs e)
        {
            new AdminWindow(user).Show();
            Close();
        }

        private void choosePrirority(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            typeSong.Text = button.Content.ToString();
            song.Type = typeSong.Text;
            validation.validateOthers(typeSong);
        }

        private void description(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; ;
            if (validation.descriptionValidation(textBox))
            {
                song.Description = textBox.Text;
            }
        }

        private void authorName(object sender, TextChangedEventArgs e)
        {

            TextBox textBox = (TextBox)sender; ;
            if (validation.authorNameValidation(textBox))
            {
                song.AuthorName = textBox.Text;
            }
        }

        private void album(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; ;
            if (validation.albumValidation(textBox))
            {
                song.Album = textBox.Text;
            }
        }

        private void realiseDate(object sender, SelectionChangedEventArgs e)
        {
            validation.validateOthers(Date);
            song.ReleaseDate = (DateTime)Date.SelectedDate;
        }

        private void create(object sender, RoutedEventArgs e)
        {

            if (validation.isAllFieldValidate())
            {
                controller.complete(TextCommand.CREATE_GOOGLE_SONG, new object[] { FilePath, song });
                controller.complete(TextCommand.SEND_NOTIFICATION_FOR_USERS, new object[] { user.Id, song });
                new AdminWindow(user).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Error(empty field or not correct text)");
            }
        }
        private string parseName(string filePath)
        {
            string[] arr = filePath.Split('\\');
            string badStr = arr.Last();
            char[] badArr = badStr.ToCharArray();
            string str = "";
            for (int i = 0; i < badArr.Length - 4; i++)
            {
                str += badArr[i].ToString();
            }
            return str;

        }

        private void updateSong(object sender, RoutedEventArgs e)
        {
            if (validation.isAllFieldValidate())
            {
                controller.complete(TextCommand.UPDATE_SONG, new object[] { song.Id, song });
                new AdminWindow(user).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Error(empty field or not correct text)");
            }
        }
    }
}
