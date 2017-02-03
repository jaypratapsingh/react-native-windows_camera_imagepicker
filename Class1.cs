using ReactNative.Bridge;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Media.Capture;

namespace gwsconnect
{
    class Class1 : ReactContextNativeModuleBase, ILifecycleEventListener
    {
       
        public Class1(ReactContext reactContext)
            : base(reactContext)
        {
        }

        public override string Name
        {
            get
            {
                return "Class1";
            }
        }

        [ReactMethod]
        public async void openCamera(ICallback successCallback, ICallback errorCallback)
        {
            RunOnDispatcher(async () =>
            {
                CameraCaptureUI captureUI = new CameraCaptureUI();
                captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;

                StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

                if (photo == null)
                {
                    // User cancelled photo capture
                    errorCallback.Invoke("User cancelled photo capture");
                    return;
                }
                else
                {
                    successCallback.Invoke(photo);
                }
            });
            
        }

        [ReactMethod]
        public async void openGallery(ICallback successCallback, ICallback errorCallback)
        {
            RunOnDispatcher(async () =>
            {
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                openPicker.FileTypeFilter.Add(".jpg");
                openPicker.FileTypeFilter.Add(".jpeg");
                openPicker.FileTypeFilter.Add(".png");

                StorageFile file = await openPicker.PickSingleFileAsync();
                if (file != null)
                {
                    // Application now has read/write access to the picked file
                    successCallback.Invoke(file);
                }
                else
                {
                    errorCallback.Invoke("File not selected");
                }
            });
        }

        private static async void RunOnDispatcher(DispatchedHandler action)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, action).AsTask().ConfigureAwait(false);
        }


        public void OnDestroy()
        {
            throw new NotImplementedException();
        }

        public void OnResume()
        {
            throw new NotImplementedException();
        }

        public void OnSuspend()
        {
            throw new NotImplementedException();
        }
    }
}
