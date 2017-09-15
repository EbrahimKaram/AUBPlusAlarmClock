using AubPlusAlarm.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace AubPlusAlarm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
            myMediaElement.Source = new Uri("ms-appx:///Assets\03 Don't Trust Me.mp3");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //FileOpenPicker openPicker = new FileOpenPicker();
            //openPicker.ViewMode = PickerViewMode.List;
            //openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            //openPicker.FileTypeFilter.Add("*");
            //openPicker.PickMultipleFilesAndContinue();

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".aac");
            openPicker.FileTypeFilter.Add(".ogg");
            openPicker.FileTypeFilter.Add(".mp4a");
            openPicker.FileTypeFilter.Add(".wma");
            openPicker.PickSingleFileAndContinue();
            
        }

        public void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
           try
           {
               myMediaElement.Source = new Uri("ms-appx:///"+args.Files[0].Path);
               //myMediaElement.Source = new Uri("ms-appx:///Assets\03 Don't Trust Me.mp3");
               myMediaElement.Play();
           }
            catch
           {
               myMediaElement.Source = new Uri("ms-appx:///Assets\03 Don't Trust Me.mp3");
           }
        }

        private void myMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
        }
        
        
        private void Button_Prime_Click(object sender, RoutedEventArgs e)
           {
               Frame.Navigate(typeof(WhatsNext));  //(creates Problems)

           }

      

    }
}
     