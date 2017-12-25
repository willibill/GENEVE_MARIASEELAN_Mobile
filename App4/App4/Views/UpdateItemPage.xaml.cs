/*The code for modifying an item */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateItemPage : ContentPage
    {

        public Item Item { get; set; }

        ItemDetailViewModel viewModel;

        public UpdateItemPage()
        {
            var Item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(Item);
            BindingContext = viewModel;
        }

        public UpdateItemPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;


        }

        async void Validate_clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(BindingContext, "UpdateItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}