using System.IO;
using System.Text.Json;
using System.Windows;

namespace HotelWpf
{
    public partial class MainWindow : Window
    {
        private HotelRoom CurrentRoom = new HotelRoom();
        private bool isNew = true;

        public MainWindow()
        {
            InitializeComponent();
            NewRoom();
        }

        private string GetFileName(int id)// имя файла по id
        {
            return "room_" + id + ".json";
        }

        
        private int GenerateId()// ищем первый id, для которого файла ещё нет
        {
            int id = 1;
            while (File.Exists(GetFileName(id)))
            {
                id++;
            }
            return id;
        }

        private void NewRoom()
        {
            CurrentRoom = new HotelRoom();
            CurrentRoom.Id = GenerateId();
            isNew = true;
            DataContext = CurrentRoom;
        }

        private void NewRecord_Click(object sender, RoutedEventArgs e)//создание новой комнаты
        {
            NewRoom();
        }

        private void Save_Click(object sender, RoutedEventArgs e)//сохранение в файл
        {
            if (isNew && File.Exists(GetFileName(CurrentRoom.Id)))
            {
                CurrentRoom.Id = GenerateId();
            }

            string json = JsonSerializer.Serialize(CurrentRoom);
            File.WriteAllText(GetFileName(CurrentRoom.Id), json);
            isNew = false;

            MessageBox.Show("Сохранено, ID = " + CurrentRoom.Id);
        }

        private void Find_Click(object sender, RoutedEventArgs e)//поиск по id
        {
            int id;
            if (!int.TryParse(tbSearchId.Text, out id))
            {
                MessageBox.Show("Введите ID числом");
                return;
            }

            if (!File.Exists(GetFileName(id)))
            {
                MessageBox.Show("Номер с таким ID не найден");
                return;
            }

            string json = File.ReadAllText(GetFileName(id));
            HotelRoom room = JsonSerializer.Deserialize<HotelRoom>(json);

            CurrentRoom = room;
            isNew = false;
            DataContext = CurrentRoom;
        }
    }
}