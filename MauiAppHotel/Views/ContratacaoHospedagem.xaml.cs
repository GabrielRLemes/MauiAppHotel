using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();
		PropriedadesApp = (App)Application.Current;
		pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;
		dtpck_checkin.MinimumDate = DateTime.Now;
		dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(3);
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			Hospedagem h = new Hospedagem()
			{
				QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
				QuantidadeAdulto = Convert.ToInt32(stp_adultos.Value),
				QuantidadeCrianca = Convert.ToInt32(stp_criancas.Value),
				DiaCheckIn = dtpck_checkin.Date,
				DiaCheckOut = dtpck_checkout.Date,
			};

			await Navigation.PushAsync(new HospedagemContratada()
			{
				BindingContext = h,
			});
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "ok");
		}
	}

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker elemento = sender as DatePicker;

		DateTime dataSelecionadaCheckin = elemento.Date;

		dtpck_checkout.MinimumDate = dataSelecionadaCheckin.AddDays(1);
		dtpck_checkout.MaximumDate = dataSelecionadaCheckin.AddMonths(3);
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
		try
		{
			await Navigation.PushAsync(new SobreApp());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "ok");
		}
    }
}