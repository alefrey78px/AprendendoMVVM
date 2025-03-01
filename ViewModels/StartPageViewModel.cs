using AprendendoMVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AprendendoMVVM.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        public ICommand SaveCommand { get; set; }

        private Person _person;
        // A Person agora é um modelo simples, então a ViewModel precisa gerenciar as notificações
        private string _personName;
        private string _personEmail;
        private int _personId;

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                _personName = _person.Name;
                _personEmail = _person.Email;
                _personId = _person.Id;
                OnPropertyChanged(nameof(Person));
                OnPropertyChanged(nameof(PersonName));
                OnPropertyChanged(nameof(PersonEmail));
                OnPropertyChanged(nameof(PersonId));
            }
        }
        
        public string PersonName
        {
            get { return _personName; }
            set
            {
                _personName = value;
                _person.Name = value;
                OnPropertyChanged(nameof(PersonName));
            }
        }

        public string PersonEmail
        {
            get { return _personEmail; }
            set
            {
                _personEmail = value;
                _person.Email = value;
                OnPropertyChanged(nameof(PersonEmail));
            }
        }

        public int PersonId
        {
            get { return _personId; }
            set
            {
                _personId = value;
                _person.Id = value;
                OnPropertyChanged(nameof(PersonId));
            }
        }

        public ObservableCollection<Person> People { get; set; }

        public StartPageViewModel()
        {
            People = new ObservableCollection<Person>();
            SaveCommand = new Command(Save);
            _person = new Person();  // Inicializa a pessoa
            _personName = string.Empty;
            _personEmail = string.Empty;
        }

        private void Save()
        {
            // Cria uma nova instância de Person para adicionar à coleção
            var personToAdd = new Person
            {
                Id = PersonId,
                Name = PersonName,
                Email = PersonEmail
            };

            People.Add(personToAdd);

            // Reset para um novo Person
            Person = new Person();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}