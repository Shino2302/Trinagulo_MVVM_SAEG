using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinagulo_MVVM_SAEG.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trinagulo_MVVM_SAEG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            InitializeComponent();

            BindingContext = new VMTipoTriangulo(Navigation);
        }
    }
}