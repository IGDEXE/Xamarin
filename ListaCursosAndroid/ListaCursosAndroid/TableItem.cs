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
    class TableItem
    {
        // Cria as variaveis
        private string titulo;
        private string descripcion;
        private int imageID;
        // Utiliza o VS para criar as estruturas:
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int ImageID { get => imageID; set => imageID = value; }
    }
}