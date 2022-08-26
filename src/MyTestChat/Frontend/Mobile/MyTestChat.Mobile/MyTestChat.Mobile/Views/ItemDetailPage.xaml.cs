using MyTestChat.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyTestChat.Mobile.Views
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