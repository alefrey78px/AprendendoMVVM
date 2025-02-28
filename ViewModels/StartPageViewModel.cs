using AprendendoMVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AprendendoMVVM.ViewModels
{
    // A classe StartPageViewModel representa a "ViewModel" no padrão MVVM.
    // Ela é responsável por conectar os dados do Model com a UI (View).
    public class StartPageViewModel : INotifyPropertyChanged
    {
        // Comando que será associado a um botão na View para salvar uma pessoa.
        public ICommand SaveCommand { get; set; }

        private Person _person;

        // Propriedade que representa a pessoa que está sendo editada.
        // Usa OnPropertyChanged para notificar a UI sempre que for alterada.
        public Person Person
        {
            get { return _person; }
            set { _person = value; OnPropertyChanged(nameof(Person)); }
        }

        // *** IMPORTANTE: ESTA LISTA NÃO FAZ PARTE DO MVVM ***
        // Ela está aqui apenas para simular o salvamento de dados de forma simples.
        // Em um cenário real, os dados seriam salvos em um banco de dados ou outro repositório.
        public ObservableCollection<Person> People { get; set; }

        // Construtor da ViewModel.
        public StartPageViewModel()
        {
            People = new ObservableCollection<Person>(); // Inicializa a coleção
            SaveCommand = new Command(Save); // Define o comando que será usado na View
            Person = new Person(); // Inicializa a pessoa em edição
        }

        // Método chamado pelo comando SaveCommand.
        // Adiciona a pessoa atual à lista e cria uma nova para limpar os campos.
        private void Save(object obj)
        {
            // *** IMPORTANTE: ESTA LISTA NÃO FAZ PARTE DO MVVM ***
            // Aqui estamos apenas simulando a persistência de dados.
            People.Add(Person);
            Person = new Person(); // Para limpar a tela após salvar
        }

        // Evento PropertyChanged necessário para notificar a UI sobre mudanças nas propriedades.
        public event PropertyChangedEventHandler? PropertyChanged;

        // Método que dispara o evento PropertyChanged para atualizar a UI.
        public void OnPropertyChanged(string prop)
        {
            // Maneira recomendada (mais concisa e moderna)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

            // Maneira alternativa que também funciona:
            /*
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            */
        }
    }
}
