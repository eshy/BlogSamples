using Cirrious.MvvmCross.Plugins.PictureChooser;
using Cirrious.MvvmCross.ViewModels;
using System.IO;
using System.Windows.Input;

namespace CameraTest.Core.ViewModels
{
    public class HomeViewModel 
		: MvxViewModel
    {
        private readonly IMvxPictureChooserTask _pictureChooserTask;

        private const int MaxPicturePixelDimension = 640;
        private const int PictureQuality = 100;

        public HomeViewModel(IMvxPictureChooserTask pictureChooserTask)
        {
            _pictureChooserTask = pictureChooserTask;
        }

        private byte[] _pictureBytes;
        public byte[] PictureBytes
        {
            get { return _pictureBytes; }
            set { _pictureBytes = value; RaisePropertyChanged(()=>PictureBytes); }
        }

        public ICommand SelectPictureCommand
        {
            get { return new MvxCommand(SelectPicture); }
        }

        private async void SelectPicture()
        {
            var pictureStream = await _pictureChooserTask.ChoosePictureFromLibraryAsync(MaxPicturePixelDimension, PictureQuality);

            var memoryStream = new MemoryStream();
            await pictureStream.CopyToAsync(memoryStream);
            PictureBytes = memoryStream.ToArray();
        }

        public void ContinueFileOpenPicker(object args)
        {
            _pictureChooserTask.ContinueFileOpenPicker(args);
        }
        
    }
}
