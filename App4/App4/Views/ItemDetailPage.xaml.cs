﻿using System;

using Xamarin.Forms;

namespace App4
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        /* Open the view UpdateItemPage*/
        async void UpdateItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new App4.Views.UpdateItemPage(viewModel));
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            await viewModel.DeleteItem_Clicked();
            await Navigation.PopToRootAsync();
        }
    }
}
