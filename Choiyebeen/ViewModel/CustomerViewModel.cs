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
    public class CustomerViewModel : ViewModelBase
    {
        InventoryModel inventory;

        //추가
        public ImageSource IceCoffeeImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.아메리카노]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.아메리카노] = value;
                OnPropertyChanged(nameof(IceCoffeeImageSource));
                
            }
        }

        public ImageSource IceLatteImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.카페라떼]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.카페라떼] = value;
                OnPropertyChanged(nameof(IceLatteImageSource));

            }
        }

        public ImageSource CLatteImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.카라멜마끼야또]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.카라멜마끼야또] = value;
                OnPropertyChanged(nameof(CLatteImageSource));

            }
        }

        public ImageSource HLatteImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.헤이즐럿라떼]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.헤이즐럿라떼] = value;
                OnPropertyChanged(nameof(HLatteImageSource));
            }
        }

        public ImageSource MochalatteImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.카페모카]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.카페모카] = value;
                OnPropertyChanged(nameof(MochalatteImageSource));

            }
        }

        public ImageSource VlatteImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.바닐라라떼]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.바닐라라떼] = value;
                OnPropertyChanged(nameof(VlatteImageSource));
            }
        }



        public event EventHandler<CartModel> PriceChanged;
        public ICommand IceCoffeeCommand { get; }
        public ICommand IceLatteCommand {get;}
        public ICommand CLatteCommand { get; }
        public ICommand HLatteCommand { get; }
        public ICommand MochalatteCommand { get; }
        public ICommand VlatteCommand { get; }

        public CustomerViewModel() //생성자
        {
            inventory = InventoryModel.Instance;
            inventory.RegisterAction(0,LoadImage);
            IceCoffeeCommand = new ViewModelCommand(ExecuteIceCoffeeCommand);
            IceLatteCommand = new ViewModelCommand(ExecuteIceLatteCommand);
            CLatteCommand = new ViewModelCommand(ExecuteCLatteCommand);
            HLatteCommand = new ViewModelCommand(ExecuteHLatteCommand);
            MochalatteCommand = new ViewModelCommand(ExecuteMochalatteCommand);
            VlatteCommand = new ViewModelCommand(ExecuteVlatteeCommand);

            LoadImage();
        }

        
        //추가
        private void LoadImage()
        {
            try
            {
                // 이미지 경로를 딕셔너리에 저장
                var imagePaths = new Dictionary<enumInventroy, string>
        {
            { enumInventroy.아메리카노, inventory.imgPath["아메리카노"] },
            { enumInventroy.카페라떼, inventory.imgPath["카페라떼"] },
            { enumInventroy.카라멜마끼야또, inventory.imgPath["카라멜마끼야또"] },
            { enumInventroy.헤이즐럿라떼, inventory.imgPath["헤이즐럿라떼"] },
            { enumInventroy.카페모카, inventory.imgPath["카페모카"] },
            { enumInventroy.바닐라라떼, inventory.imgPath["바닐라라떼"] }
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
                        case enumInventroy.아메리카노:
                            IceCoffeeImageSource = bitmap;
                            break;
                        case enumInventroy.카페라떼:
                            IceLatteImageSource = bitmap;
                            break;
                        case enumInventroy.카라멜마끼야또:
                            CLatteImageSource = bitmap;
                            break;
                        case enumInventroy.헤이즐럿라떼:
                            HLatteImageSource = bitmap;
                            break;
                        case enumInventroy.카페모카:
                            MochalatteImageSource = bitmap;
                            break;
                        case enumInventroy.바닐라라떼:
                            VlatteImageSource = bitmap;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);  // 오류 로깅
            }
        }



        private void ExecuteVlatteeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "바닐라 라떼",
                ItemCount = 1,
                ItemPrice = 3800
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteMochalatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "모카 라떼",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteIceCoffeeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "아메리카노",
                ItemCount = 1,
                ItemPrice = 3000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteIceLatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "카페라떼",
                ItemCount = 1,
                ItemPrice = 3800
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteCLatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "카라멜 마끼아또",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteHLatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "헤이즐넛 라떼",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }


    }


}
