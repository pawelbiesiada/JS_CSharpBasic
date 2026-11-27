using MyMAUIApp.Models;
using MyMAUIApp.PageModels;

namespace MyMAUIApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}