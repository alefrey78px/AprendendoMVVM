using AprendendoMVVM.Models;

namespace AprendendoMVVM.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();

		// BindingContext � uma classe que fica dispon�vel para 
		// fazermos vincula��es em nossa tela.
		// faremos pelo XAML que � mais recomendado.
		// BindingContext = new ViewModels.StartPageViewModel();
	}
}