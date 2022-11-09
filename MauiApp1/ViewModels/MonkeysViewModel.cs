using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class MonkeysViewModel : INotifyPropertyChanged
    {
        readonly List<Monkey> source;
        Monkey selectedMonkey;

        public ObservableCollection<Monkey> Monkeys { get; private set; }

        public Monkey SelectedMonkey
        {
            get
            {
                return selectedMonkey;
            }
            set
            {
                if (selectedMonkey != value)
                {
                    selectedMonkey = value;
                }
            }
        }

        public ICommand DeleteCommand => new Command<Monkey>(RemoveMonkey);
        public ICommand FavoriteCommand => new Command<Monkey>(FavoriteMonkey);

        public MonkeysViewModel()
        {
            source = new List<Monkey>();
            CreateMonkeyCollection();

            SelectedMonkey = Monkeys.Skip(3).FirstOrDefault();
            OnPropertyChanged("SelectedMonkey");

        }

        void CreateMonkeyCollection()
        {

            var _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            HttpClient _client = new HttpClient();
            var data = _client.GetAsync("https://localhost:7135/api/MusicItems").Result;
            string content = data.Content.ReadAsStringAsync().Result;
            var items = JsonSerializer.Deserialize<List<Monkey>>(content, _serializerOptions);
            source.AddRange(items);
            Monkeys = new ObservableCollection<Monkey>(source);
        }

        void RemoveMonkey(Monkey monkey)
        {
            if (Monkeys.Contains(monkey))
            {
                Monkeys.Remove(monkey);
            }
        }

        void FavoriteMonkey(Monkey monkey)
        {
            monkey.IsFavorite = !monkey.IsFavorite;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
