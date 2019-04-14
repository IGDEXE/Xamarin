using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace ListaCursosAndroid
{
    [Activity(Label = "ActivityCourse")]
    public class ActivityCourse : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Define a tela
            SetContentView(Resource.Layout.Course);
            // Recebe o item
            var item = JsonConvert.DeserializeObject<TableItem>(Intent.GetStringExtra("data"));
            // Configura os dados
            TextView titulo = FindViewById<TextView>(Resource.Id.textView1);
            TextView descripcion = FindViewById<TextView>(Resource.Id.textView2);
            // Configura os campos
            titulo.Text = item.Titulo;
            descripcion.Text = item.Descripcion;
            FindViewById<ImageView>(Resource.Id.imageView).SetImageResource(item.ImageID);
        }
    }
}