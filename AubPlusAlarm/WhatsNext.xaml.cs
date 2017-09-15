using AubPlusAlarm.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AubPlusAlarm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WhatsNext : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        int random;
        int[] A = Whats_Next.ListofPrimes();

        public WhatsNext()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

  
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
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

            int k = Whats_Next.difficulty(ComboBox_Difficulty.SelectedIndex);
            random = Whats_Next.Randomnumber(k);
            TextBlock_randomPrime.Text = A[random].ToString();

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }


        #endregion
         private void Button_StartOver_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int input=Convert.ToInt32(TextBox_usersInput.Text);
                if(input==A[random+1])
                {
                    TextBlock_WhatsnextAnswer.Text="WOW you got it right. Alarm Will Turn off";
                }
                else 
                    TextBlock_WhatsnextAnswer.Text="Nice try, but the answer is "+A[random+1];

                if (!IsItPrime.Primebility(TextBox_usersInput.Text))
                {
                    List<int> Divisbles = IsItPrime.divisibleby(TextBox_usersInput.Text);
                    TextBlock_Divisibleby.Text = TextBox_usersInput.Text+ " is actually divisible by";
                    foreach (int number in Divisbles)
                    {
                        TextBlock_Divisibleby.Text += " " + number;

                    }
                    TextBlock_Divisibleby.Text += ".";
                }
            }

            catch
            {
                TextBlock_WhatsnextAnswer.Text = "I think Your Number was just a nudge too Big or you didn't put anything, but what do I know I'm just a phone";
            }
        }

        private void ComboBox_Difficulty_GotFocus(object sender, RoutedEventArgs e)
        {
            //Could use a function for this
            int k = Whats_Next.difficulty(ComboBox_Difficulty.SelectedIndex);
            random = Whats_Next.Randomnumber(k);
            TextBlock_randomPrime.Text = A[random].ToString();
            TextBox_usersInput.Text = String.Empty;
            TextBlock_WhatsnextAnswer.Text = string.Empty;

        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            int k = Whats_Next.difficulty(ComboBox_Difficulty.SelectedIndex);
            random = Whats_Next.Randomnumber(k);
            TextBlock_randomPrime.Text = A[random].ToString();
            TextBlock_WhatsnextAnswer.Text = "";
            TextBlock_Divisibleby.Text = "";
            TextBox_usersInput.Text = "";
        }
    }
    }

