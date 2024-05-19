using Choiyebeen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Choiyebeen.ViewModel
{
    public class HomeViewModel : ViewModelBase // 상속 -> 자료형 맞춰줘야함 
    {
        public event EventHandler<CartModel> PriceChanged;
        public ICommand CiderCommand { get; }
        public ICommand CocaCommand { get; }

        InventoryModel inventory;

        public ImageSource CiderImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.사이다]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.사이다] = value;
                OnPropertyChanged(nameof(CiderImageSource));

            }
        }

        public ImageSource CocaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.콜라]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.콜라] = value;
                OnPropertyChanged(nameof(CocaImageSource));

            }
        }


        public HomeViewModel()
        {
            inventory = InventoryModel.Instance;
            inventory.RegisterAction(1, LoadImage);
            CiderCommand = new ViewModelCommand(ExecuteCiderCommand);
            CocaCommand = new ViewModelCommand(ExecuteCocaCommand);
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                var imagePaths = new Dictionary<enumInventroy, string>
                {
                    { enumInventroy.사이다, inventory.imgPath["사이다"] },
                    { enumInventroy.콜라, inventory.imgPath["콜라"] },
                };

                foreach(var imagePath in imagePaths)
                {
                    var uri = new Uri(imagePath.Value, UriKind.RelativeOrAbsolute);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = uri;
                    bitmap.EndInit();

                    switch (imagePath.Key)
                    {
                        case enumInventroy.사이다:
                            CiderImageSource = bitmap;
                            break;
                        case enumInventroy.콜라:
                            CocaImageSource = bitmap;
                            break;
                    }
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);
            }
        }

        private void ExecuteCocaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "콜라",
                ItemCount = 1,
                ItemPrice = 1500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteCiderCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "사이다",
                ItemCount = 1,
                ItemPrice = 1500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}