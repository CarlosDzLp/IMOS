using System;
using System.Diagnostics;
using IMOS.DbLocal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMOS.Views.Principal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            LoadVerificationDay();

        }
        private void LoadVerificationDay()
        {
            try
            {
                var db = new DbContext();
                var openDay = db.validarVenta();
                if(openDay)
                {
                    var ventas = db.GetvalidarVenta();
                    var datedb = Convert.ToDateTime(ventas.FechaHora);
                    TimeSpan ts = DateTime.Now - datedb;
                    int day = ts.Days * 24;
                    int differenceInDays = ts.Hours;
                    differenceInDays = differenceInDays + day;
                    if (differenceInDays >= 24)
                    {
                        var notification = Plugin.LocalNotifications.CrossLocalNotifications.Current;
                        notification.Show("IMOS", "Tiene una venta abierta del " + datedb.ToString("dd/MM/yyyy"));
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
	}
}