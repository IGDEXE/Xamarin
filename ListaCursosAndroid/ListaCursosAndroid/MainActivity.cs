using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json;

namespace ListaCursosAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        // Cria a lista
        List<TableItem> tableItems = new List<TableItem>();
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Define a pagina inicial
            SetContentView(Resource.Layout.Home);
            // Configura a List View
            listView = FindViewById<ListView>(Resource.Id.listView);
            // Cria os itens da tabela
            // Configura o curso de TI
            tableItems.Add(
                new TableItem()
                {
                    Titulo = "IT Network",
                    Descripcion = "Course about IT network infra",
                    ImageID = Resource.Drawable.IT
                }
            );
            // Configura o curso de ADS
            tableItems.Add(
                new TableItem()
                {
                    Titulo = "Development",
                    Descripcion = "Course about programming languages",
                    ImageID = Resource.Drawable.ADS
                }
            );
            // Configura o curso de arquitetura
            tableItems.Add(
                new TableItem()
                {
                    Titulo = "Architecture",
                    Descripcion = "Course about constructions",
                    ImageID = Resource.Drawable.Arquitetura
                }
            );
            // Faz a ligacao com a GUI
            listView.Adapter = new HomeList(this, tableItems);
            // Chama o evento do clique
            listView.ItemClick += ListView_ItemClick;
        }

        // Configura clique
        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // Cria um temporario
            var tmp = tableItems[e.Position];
            // Cria um conector
            var intent = new Intent(this, typeof(ActivityCourse));
            // Configura os dados
            intent.PutExtra("data", JsonConvert.SerializeObject(tmp));
            // Abre a outra tela
            StartActivity(intent);
        }
    }
}