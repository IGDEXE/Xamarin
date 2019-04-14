using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json;

namespace ListaComprasAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        // Cria a variavel para salvar a lista
        public List<string[]> miProducto = new List<string[]>(); 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Cria a representacao do botao
            var btn = FindViewById<Button>(Resource.Id.btnAgregar);

            // Chama evento do Botao
            btn.Click += Btn_Click;
        }
        // Evento de clicar no botao
        private void Btn_Click(object sender, System.EventArgs e)
        {
            // Cria a representacao das TXTs
            var producto = FindViewById<EditText>(Resource.Id.txtProducto);
            var cantidad = FindViewById<EditText>(Resource.Id.txtCantidad);
            // Recebe os valores
            string[] data = new string[] { producto.Text, cantidad.Text };
            // Salva eles
            miProducto.Add(data);
            // Limpa as TXTs
            producto.Text = "";
            cantidad.Text = "";
            // Conecta com a outra tela
            var intent = new Intent(this, typeof(ListaProductosActivity));
            // Envia as informacoes
            intent.PutExtra("data", JsonConvert.SerializeObject(miProducto));
            // Abre a nova tela
            StartActivity(intent);
        }
    }
}