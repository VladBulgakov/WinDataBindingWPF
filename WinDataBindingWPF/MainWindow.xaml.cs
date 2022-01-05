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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinDataBindingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SolidColorBrush yellowBrush = new SolidColorBrush(Colors.Yellow);
        static SolidColorBrush orangeBrush = new SolidColorBrush(Colors.Orange);
        MyStrings mystrings = new MyStrings();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void setColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!mainWindow.Background.Equals(yellowBrush)) mainWindow.Background = yellowBrush;
            else mainWindow.Background = orangeBrush;
            textBoxOne.Text = "Цвет изменен!";
        }

        private void startWritingButton_Click(object sender, RoutedEventArgs e)
        {
            mystrings.ClearStrings();
            for (int i = 0; i < 5; i++)
            {
                Task.Delay(100).Wait();
                mystrings.AddString($"Запись номер {i + 1}");
            }
            MessageBox.Show(mystrings.AllText);
        }
    }

    public class MyStrings : INotifyPropertyChanged
    {
        List<string> textStrings = new List<string>();
        public event PropertyChangedEventHandler PropertyChanged;

        public MyStrings()
        {
            this.textStrings.Add("Привет!");
        }

        public void AddString(string input)
        {
            this.textStrings.Add(input);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllText"));
        }

        public void ClearStrings()
        {
            this.textStrings.Clear();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllText"));
        }

        public string AllText
        {
            get
            {
                string str = "";
                foreach (string s in textStrings) str += s + "\n";
                return str;
            }
        }
    }
}

    /*public class Phone : INotifyPropertyChanged
    {
        private string title;
        private string company;
        private int price;

        public Phone(string title, string company, int price)
        {
            this.title = title;
            this.company = company;
            this.price = price;
        }

        public Phone()
        { }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }*/