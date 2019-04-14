using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisCursosXamarin
{
    public partial class ListarItems : ContentView
    {
        public ListarItems( JArray arrData)
        {
            InitializeComponent();
            Debug.WriteLine("DATA:  " + arrData);

            // Cria a lista
            var data = new List<Product>();
            // Cria um laco para receber os valores
            for (int i = 0; i < arrData.Count; i++)
            {
                // Instancia o objeto
                Product tmp = new Product
                {
                    // Configura o nome
                    nombre = arrData[i]["nombre"].ToString(),
                    // Configura o preco
                    precioMillar = arrData[i]["precioMillar"].ToString(),
                    // Configura a imagem
                    imagen = "http://area51.pe/sol/" + arrData[i]["imagen"]
                };
                // Grava o produto
                data.Add(tmp);
            }
            // Grava a lista
            list.ItemsSource = data;
        }
    }
}