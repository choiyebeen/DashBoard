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
    public class DesertViewModel : ViewModelBase
    {
        public event EventHandler<CartModel> PriceChanged; //얘를 통해서 뷰모델끼리 데이터를 주고 받음
        public ICommand CupcookieCommand { get; }
        public ICommand CookieCommand { get; }
        public ICommand IcecreamCommand { get; }
        public ICommand MacaronCommand { get; }
        public ICommand BeanbreadCommand { get; }

        InventoryModel inventory;

        public ImageSource CupcookieImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.컵쿠키]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.컵쿠키] = value;
                OnPropertyChanged(nameof(CupcookieImageSource));

            }
        }

        public ImageSource CookieImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.쿠키] ; }
            set
            {
                inventory.imageSource[(int)enumInventroy.쿠키] = value;
                OnPropertyChanged(nameof(CookieImageSource));

            }
        }
        public ImageSource IcecreamImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.아이스크림]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.아이스크림] = value;
                OnPropertyChanged(nameof(IcecreamImageSource));

            }
        }

        public ImageSource MacaronImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.마카롱]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.마카롱] = value;
                OnPropertyChanged(nameof(MacaronImageSource));

            }
        }
        public ImageSource BeanbreadImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.커피콩빵]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.커피콩빵] = value;
                OnPropertyChanged(nameof(BeanbreadImageSource));

            }
        }

        public DesertViewModel() //생성자 먼저사용됨
        {
            inventory = InventoryModel.Instance;
            inventory.RegisterAction(5, LoadImage);
            CupcookieCommand = new ViewModelCommand(ExecuteCupcookieCommand);
            CookieCommand = new ViewModelCommand(ExecuteCookieCommand);
            IcecreamCommand = new ViewModelCommand(ExecuteIcecreamCommand);
            MacaronCommand = new ViewModelCommand(ExecuteMacaronCommand);
            BeanbreadCommand = new ViewModelCommand(ExecuteBeanbreadCommand);
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                var imagePaths = new Dictionary<enumInventroy, string>
                {
                    { enumInventroy.컵쿠키, inventory.imgPath["컵쿠키"] },
                    { enumInventroy.쿠키, inventory.imgPath["쿠키"] },
                    { enumInventroy.아이스크림, inventory.imgPath["아이스크림"] },
                    { enumInventroy.마카롱, inventory.imgPath["마카롱"] },
                     { enumInventroy.커피콩빵, inventory.imgPath["커피콩빵"] },
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
                        case enumInventroy.컵쿠키:
                            CupcookieImageSource = bitmap;
                            break;
                        case enumInventroy.쿠키:
                            CookieImageSource = bitmap;
                            break;
                        case enumInventroy.아이스크림:
                            IcecreamImageSource = bitmap;
                            break;
                        case enumInventroy.마카롱:
                            MacaronImageSource = bitmap;
                            break;
                        case enumInventroy.커피콩빵:
                            BeanbreadImageSource = bitmap;
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);
            }
        }


        private void ExecuteBeanbreadCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "커피콩 빵",
                ItemCount = 1,
                ItemPrice = 3000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteMacaronCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "마카롱",
                ItemCount = 1,
                ItemPrice = 2500
            };
            PriceChanged?.Invoke(this, item);
        }

        private void ExecuteIcecreamCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "구슬 아이스크림",
                ItemCount = 1,
                ItemPrice = 3000
            };
            PriceChanged?.Invoke(this, item);
        }

        private void ExecuteCookieCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "쿠키",
                ItemCount = 1,
                ItemPrice = 2000
            };
            PriceChanged?.Invoke(this, item);
        }

        private void ExecuteCupcookieCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "컵쿠키",
                ItemCount = 1,
                ItemPrice = 2700
            };
            PriceChanged?.Invoke(this, item);
        }
    }
}
