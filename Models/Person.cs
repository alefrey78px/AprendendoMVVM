using System;
using System.ComponentModel;

namespace AprendendoMVVM.Models
{
    // A classe Person representa o "Model" no padrão MVVM.
    // Ela implementa INotifyPropertyChanged para notificar a ViewModel quando seus dados mudam.
    public class Person : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); } // Notifica a UI sobre a alteração do ID
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); } // Notifica a UI sobre a alteração do Nome
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); } // Notifica a UI sobre a alteração do Email
        }

        // O evento PropertyChanged é essencial no MVVM para atualizar a UI quando os dados mudam.
        public event PropertyChangedEventHandler? PropertyChanged;

        // Método responsável por disparar o evento PropertyChanged.
        // Ele informa à ViewModel (e consequentemente à UI) que uma propriedade foi alterada.
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
