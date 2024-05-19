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
    public class TeaViewModel : ViewModelBase
    {
        public event EventHandler<CartModel> PriceChanged;
        public ICommand CteaCommand { get; }
        public ICommand GteaCommand { get; }
        public ICommand HteaCommand { get; }
        public ICommand HbteaCommand { get; }
        public ICommand JteaCommand { get; }
        public ICommand LteaCommand { get; }
        public ICommand OteaCommand { get; }
        public ICommand PteaCommand { get; }

        InventoryModel inventory;

        public ImageSource CteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.시트러스차]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.시트러스차] = value;
                OnPropertyChanged(nameof(CteaImageSource));

            }
        }
        public ImageSource GteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.생강차]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.생강차] = value;
                OnPropertyChanged(nameof(GteaImageSource));

            }
        }
        public ImageSource HteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.한라봉차]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.한라봉차] = value;
                OnPropertyChanged(nameof(HteaImageSource));

            }
        }
        public ImageSource HbteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.히비스커스차]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.히비스커스차] = value;
                OnPropertyChanged(nameof(HbteaImageSource));

            }
        }
        public ImageSource JteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.자스민차]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.자스민차] = value;
                OnPropertyChanged(nameof(JteaImageSource));

            }
        }
        public ImageSource LteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.레몬차]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.레몬차] = value;
                OnPropertyChanged(nameof(LteaImageSource));

            }
        }
        public ImageSource OteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.오미자차]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.오미자차] = value;
                OnPropertyChanged(nameof(OteaImageSource));

            }
        }
        public ImageSource PteaImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.복숭아아이스티]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.복숭아아이스티] = value;
                OnPropertyChanged(nameof(PteaImageSource));

            }
        }

        public TeaViewModel()
        {
            inventory = InventoryModel.Instance;
            inventory.RegisterAction(2, LoadImage);
            CteaCommand = new ViewModelCommand(ExecuteCteaCommand);
            GteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            HteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            HbteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            LteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            JteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            PteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            OteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                var imagePaths = new Dictionary<enumInventroy, string>
                {
                    { enumInventroy.시트러스차, inventory.imgPath["시트러스차"] },
                    { enumInventroy.생강차, inventory.imgPath["생강차"] },
                    { enumInventroy.한라봉차, inventory.imgPath["한라봉차"] },
                    { enumInventroy.히비스커스차, inventory.imgPath["히비스커스차"] },
                    { enumInventroy.레몬차, inventory.imgPath["레몬차"] },
                    { enumInventroy.자스민차, inventory.imgPath["자스민차"] },
                    { enumInventroy.복숭아아이스티, inventory.imgPath["복숭아아이스티"] },
                    { enumInventroy.오미자차, inventory.imgPath["오미자차"] },
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
                        case enumInventroy.시트러스차:
                            CteaImageSource = bitmap;
                            break;
                        case enumInventroy.생강차:
                            GteaImageSource = bitmap;
                            break;
                        case enumInventroy.한라봉차:
                            HteaImageSource = bitmap;
                            break;
                        case enumInventroy.히비스커스차:
                            HbteaImageSource = bitmap;
                            break;
                        case enumInventroy.레몬차:
                            LteaImageSource = bitmap;
                            break;
                        case enumInventroy.자스민차:
                            JteaImageSource = bitmap;
                            break;
                        case enumInventroy.복숭아아이스티:
                            PteaImageSource = bitmap;
                            break;
                        case enumInventroy.오미자차:
                            OteaImageSource = bitmap;
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);
            }
        }

        private void ExecutePPteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "복숭아 아이스티",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteOteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "오미자 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteLteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "레몬 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteJteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "자스민 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteHbteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "히비스커스 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteHteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "한라봉 차",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteGteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "생강차",
                ItemCount = 1,
                ItemPrice = 5000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteCteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "시트러스 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}
