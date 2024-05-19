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
    public class SmoothieViewModel : ViewModelBase //상속 자료형 맞춰줘야함
    {
        public event EventHandler<CartModel> PriceChanged;
        public ICommand PyogurtCommand { get; }
        public ICommand ByogurtCommand { get; }
        public ICommand SyogurtCommand { get; }
        public ICommand MyogurtCommand { get; }

        InventoryModel inventory;

        public ImageSource PyogurtImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.플레인요거트스무디]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.플레인요거트스무디] = value;
                OnPropertyChanged(nameof(PyogurtImageSource));
            }
        }

        public ImageSource ByogurtImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.블루베리요거트스무디]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.블루베리요거트스무디] = value;
                OnPropertyChanged(nameof(ByogurtImageSource));

            }
        }
        public ImageSource SyogurtImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.딸기요거트스무디]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.딸기요거트스무디] = value;
                OnPropertyChanged(nameof(SyogurtImageSource));

            }
        }

        public ImageSource MyogurtImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.망고요거트스무디]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.망고요거트스무디] = value;
                OnPropertyChanged(nameof(MyogurtImageSource));

            }
        }

        public SmoothieViewModel()
        {
            inventory = InventoryModel.Instance;
            inventory.RegisterAction(3, LoadImage);
            PyogurtCommand = new ViewModelCommand(ExecutePyogurtCommand);
            ByogurtCommand = new ViewModelCommand(ExecuteByogurtCommand);
            SyogurtCommand = new ViewModelCommand(ExecuteSyogurtCommand);
            MyogurtCommand = new ViewModelCommand(ExecuteMyogurtCommand);
            LoadImage();
        }
        private void LoadImage()
        {
            try
            {
                var imagePaths = new Dictionary<enumInventroy, string>
                {
                    { enumInventroy.플레인요거트스무디, inventory.imgPath["플레인요거트스무디"] },
                    { enumInventroy.블루베리요거트스무디, inventory.imgPath["블루베리요거트스무디"] },
                     { enumInventroy.딸기요거트스무디, inventory.imgPath["딸기요거트스무디"] },
                    { enumInventroy.망고요거트스무디, inventory.imgPath["망고요거트스무디"] },
                };

                foreach (var imagePath in imagePaths)
                {
                    var uri = new Uri(imagePath.Value, UriKind.RelativeOrAbsolute);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = uri;
                    bitmap.EndInit();

                    switch (imagePath.Key)
                    {
                        case enumInventroy.플레인요거트스무디:
                            PyogurtImageSource = bitmap;
                            break;
                        case enumInventroy.블루베리요거트스무디:
                            ByogurtImageSource = bitmap;
                            break;
                        case enumInventroy.딸기요거트스무디:
                            SyogurtImageSource = bitmap;
                            break;
                        case enumInventroy.망고요거트스무디:
                            MyogurtImageSource = bitmap;
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);
            }
        }


        private void ExecuteMyogurtCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "망고 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteSyogurtCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "딸기 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteByogurtCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "블루베리 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecutePyogurtCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "플레인 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}
