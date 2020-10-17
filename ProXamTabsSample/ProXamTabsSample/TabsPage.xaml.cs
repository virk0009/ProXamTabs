using Plugin.ProXamTabs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProXamTabsSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabsPage : ContentPage
    {
        public TabsPage()
        {
            InitializeComponent();
            SetTabs();
            tabsView.TabSelectedCommand = new Command<PXTab>(TabSelected);

        }

        private void TabSelected(PXTab pxTab)
        {
            Title = pxTab.Text;

            
            if (ToolbarItems.Count > 0)
            {
                for (int i = 0; i < ToolbarItems.Count; i++)
                {
                    this.ToolbarItems.Remove(ToolbarItems[i]);
                }
            }
            if (pxTab.ToolBarItems != null)
            {
                foreach (var item in pxTab.ToolBarItems)
                {
                    this.ToolbarItems.Add(item);
                }
            }


        }

        List<PXTab> _tabs;
        private void SetTabs()
        {
            var mainpage = new MainPage();
            var t = mainpage.ToolbarItems;

            _tabs = new List<PXTab>()
            {
                 CreateTab(1, new HomeView(), "Home", "ProXamTabsSample.Resources.ic_home_32dp.jpg", "ProXamTabsSample.Resources.ic_home_gray_32dp.png", Color.Gray, Color.Gray, 0),
                 CreateTab(2, new ContactsView(), "Contacts", "ProXamTabsSample.Resources.ic_contact_32dp.png", "ProXamTabsSample.Resources.ic_contact_gray_32dp.png", Color.Blue, Color.Gray, 3),
                 CreateTab(3, new SearchView(), "Search", "ProXamTabsSample.Resources.ic_search_32dp.png", "ProXamTabsSample.Resources.ic_search_gray_32dp.png", Color.Red, Color.Gray, 200),
                 CreateTab(4, mainpage.Content, "Main page", "ProXamTabsSample.Resources.ic_search_32dp.png", "ProXamTabsSample.Resources.ic_search_gray_32dp.png", Color.Red, Color.Gray, 200,t)

            };

            tabsView.Tabs = _tabs;
            tabsView.AddToCommonBar(new VideoPlayer());


        }

        private PXTab CreateTab(int id, View view, string text, string selectedImage, string unselectedImage, Color selectedColor, Color unselectedColor, int badgeCount = 0, IList<ToolbarItem> toolbarItems = null)
        {
            return new PXTab()
            {
                TabId = id,
                TabView = view,
                Text = text,
                SelectedImage = selectedImage,
                UnselectedImage = unselectedImage,
                SelectedColor = selectedColor,
                UnSelectedColor = unselectedColor,
                TextSize = 12,
                ImageSize = 24,
                BadgeCount = badgeCount,
                BadgeColor = Color.Blue,
                TabPadding = 2,
                ToolBarItems = toolbarItems
            };

        }
    }
}