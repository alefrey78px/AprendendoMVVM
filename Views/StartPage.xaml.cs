using AprendendoMVVM.Models;

namespace AprendendoMVVM.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();

		// BindingContext é uma classe que fica disponível para 
		// fazermos vinculações em nossa tela.
		// faremos pelo XAML que é mais recomendado.
		// BindingContext = new ViewModels.StartPageViewModel();
	}
}