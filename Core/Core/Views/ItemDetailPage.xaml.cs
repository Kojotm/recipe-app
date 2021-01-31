using Core.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}