using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Battlelogium.Core.UI;
using Battlelogium.Utilities;
using Battlelogium.ThirdParty.WPFCustomMessageBox;

namespace Battlelogium.Core.Configuration
{
    /// <summary>
    /// Interaction logic for UIConfig.xaml
    /// </summary>
    public partial class UIConfig : Window
    {
        Config config;
        public UIConfig(Config config)
        {
            InitializeComponent();
            this.config = config;
            this.Closing += UIConfig_Closing;
            //Load General Settings
            this.checkUpdates_input.IsChecked = this.config.CheckUpdates;
            this.manageOrigin_input.IsChecked = config.ManageOrigin;

            //Load Window Settings
            this.fullscreenMode_input.IsChecked = config.FullscreenMode;
            this.rightClickDrag_input.IsChecked = config.RightClickDrag;
            this.disableHardwareAccel_input.IsChecked = config.DisableHardwareAccel;
        }

        private void UIConfig_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.DialogResult == null) this.DialogResult = false; //make bool? default to false
            
        }

        private void discardButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxUtils.ShowChoiceDialog("Are you sure you want to discard your changes?", "Discard Changes", "Discard Changes", "Cancel"))
            {
                this.DialogResult = false;
                this.Close();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Need to add a confirm here
            this.config.WriteConfig("manageOrigin", this.manageOrigin_input.IsChecked);
            this.config.WriteConfig("checkUpdates", this.checkUpdates_input.IsChecked);

            this.config.WriteConfig("disableHardwareAccel", this.disableHardwareAccel_input.IsChecked);
            this.config.WriteConfig("rightClickDrag", this.rightClickDrag_input.IsChecked);
            this.config.WriteConfig("fullscreenMode", this.fullscreenMode_input.IsChecked);

            this.DialogResult = true;
            this.Close();
        }


    }
}
