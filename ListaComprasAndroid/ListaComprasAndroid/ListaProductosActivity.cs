using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace ListaComprasAndroid
{
    [Activity(Label = "ListaProductosActivity")]
    public class ListaProductosActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Recebe os dados da outra tela
            var items = JsonConvert.DeserializeObject<List<string[]>>(Intent.GetStringExtra("data"));
            // Verifica os valores recebidos no terminal
            Console.WriteLine(items[0][0]);
            Console.WriteLine(items[0][1]);
            // Cria um novo Layout
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            // Exibe os dados
            for (int i = 0; i<items.Count; i++)
            {
                // Cria um layout de apresentacao
                var layoutH = new LinearLayout(this);
                layoutH.Orientation = Orientation.Horizontal;
                // Cria a representacao do produto
                var txtProducto = new TextView(this);
                txtProducto.Text = items[i][0];
                txtProducto.SetWidth(500);
                txtProducto.SetPadding(0, 5, 5, 0);
                txtProducto.SetTextSize(Android.Util.ComplexUnitType.Sp, 24);
                txtProducto.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
                txtProducto.SetTextColor(Color.ParseColor("#ffff00"));
                // Cria a representacao da quantidade
                var txtCantidad = new TextView(this);
                txtCantidad.Text = items[i][1];
                txtCantidad.SetWidth(500);
                txtCantidad.SetPadding(0, 5, 5, 0);
                txtCantidad.SetTextSize(Android.Util.ComplexUnitType.Sp, 24);
                // Configura exibicao
                layoutH.AddView(txtProducto);
                layoutH.AddView(txtCantidad);
                // Configura tela principal
                layout.AddView(layoutH);
            }
            // Mostra na tela
            SetContentView(layout);
        }
    }
}