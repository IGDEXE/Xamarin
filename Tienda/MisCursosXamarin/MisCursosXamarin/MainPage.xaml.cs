using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MisCursosXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        // Cria um array para salvar os dados
        JArray arrData;
        public MainPage()
        {
            InitializeComponent();

            // Carrega o JSON
            loadJSONAsync();
        }

        private async Task loadJSONAsync()
        {
            // Cria um client
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://area51.pe/sol/")
            };

            // Aponta a pagina onde estao as infos
            string url = string.Format("tienda.json");
            // Cria um recebedor assincrono
            var resp = await client.GetAsync(url);
            // Recebe os dados
            var result = resp.Content.ReadAsStringAsync().Result;

            // Cria um objeto para interpretar
            JObject values = JObject.Parse(result);
            // Salva os valores recebidos
            arrData = (JArray)values["tienda"];

            // Acompanha o resultado via log
            Debug.WriteLine(arrData);

            // Mostra os dados
            fillData(arrData);
        }

        private void fillData(JArray arrData)
        {
            // Cria a lista
            var data = new List<Product>();
            // Cria um laco para receber os valores
            for (int i = 0; i < arrData.Count; i++)
            {
                // Conta a quantidade de itens
                string cant = "Cantidad: " + ((JArray)arrData[i]["items"]).Count;
                // Instancia o objeto
                Product tmp = new Product
                {
                    // Configura o nome
                    nombre = arrData[i]["nombre"].ToString(),
                    // Configura a quantidade
                    cantidad = cant,
                    // Configura a imagem
                    imagen = "http://area51.pe/sol/" + arrData[i]["imagen"],
                    // Configura os itens
                    items = (JArray) arrData[i]["items"]
                };
                // Grava o produto
                data.Add(tmp);
            }
            // Grava a lista
            list.ItemsSource = data;
            // Evento para cada vez que selecionar o item
            list.ItemSelected += List_ItemSelected;
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (e.SelectedItem == null) return;
            DisplayAlert("Proximamente", (list.SelectedItem as Product).nombre, "Muchas gracias");
            //ListarItems listarItems = new ListarItems((list.SelectedItem as Product).items);
            //listarItems.Title = (list.SelectedItem as Product).nombre;
            //Navigation.PushAsync(listarItems);
        }
    }
}
