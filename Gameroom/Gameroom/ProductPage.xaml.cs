using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Gameroom.Models;

namespace Gameroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        ReviewList sl;

        public ProductPage(ReviewList slist)
        {
            InitializeComponent();

            sl = slist;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var product = (Package)BindingContext;
            await App.Database.SaveProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var product = (Package)BindingContext;
            await App.Database.DeleteProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Package p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Package;
                var lp = new ListPackage()
                {
                    ReviewListID = sl.ID,
                    PackageID = p.ID
                };
                await App.Database.SaveListProductAsync(lp);
                p.ListPackage = new List<ListPackage> { lp };
                await Navigation.PopAsync();
            }
        }
    }
}