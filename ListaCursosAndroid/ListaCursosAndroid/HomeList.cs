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

namespace ListaCursosAndroid
{
    class HomeList : BaseAdapter<TableItem>
    {
        // Cria a lista
        List<TableItem> items;
        Activity context;
        // Cria a estrutura para receber os dados
        public HomeList(Activity context, List<TableItem> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            // Retorna a posicao
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Configura a visualizacao
            var item = items[position];
            // Cria o modelo da visualizacao
            View view = convertView;
            // Verifica se eh nula
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.Cell, null);
            }
            // Configura os campos
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Titulo;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Descripcion;
            view.FindViewById<ImageView>(Resource.Id.imageView).SetImageResource(item.ImageID);
            // Retorna a configuracao
            return view;
        }
    }
}