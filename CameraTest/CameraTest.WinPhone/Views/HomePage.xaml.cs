using CameraTest.Core.ViewModels;
using CameraTest.WinPhone.Helpers;
namespace CameraTest.WinPhone.Views
{
    public sealed partial class HomePage:IFileOpenPickerContinuable
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void ContinueFileOpenPicker(Windows.ApplicationModel.Activation.FileOpenPickerContinuationEventArgs args)
        {
            //Pass the continuation args to the PictureChooserTask via the ViewModel
            ((HomeViewModel)ViewModel).ContinueFileOpenPicker(args);
        }
    }
}
