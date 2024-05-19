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
    public class AdeViewModel : ViewModelBase
    {
        public event EventHandler<CartModel> PriceChanged;
        public ICommand GadeCommand { get; }
        public ICommand GGadeCommand { get; }
        public ICommand LadeCommand { get; }

        InventoryModel inventory;

        public ImageSource GadeImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.자몽에이드]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.자몽에이드] = value;
                OnPropertyChanged(nameof(GadeImageSource));

            }
        }

        public ImageSource GGadeImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.청포도에이드]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.청포도에이드] = value;
                OnPropertyChanged(nameof(GGadeImageSource));

            }
        }
        public ImageSource LadeImageSource
        {
            get { return inventory.imageSource[(int)enumInventroy.레몬에이드]; }
            set
            {
                inventory.imageSource[(int)enumInventroy.레몬에이드] = value;
                OnPropertyChanged(nameof(LadeImageSource));

            }
        }

        public AdeViewModel()
        {
            inventory = InventoryModel.Instance;
            inventory.RegisterAction(4, LoadImage);
            GadeCommand = new ViewModelCommand(ExecuteGadeCommand);
            GGadeCommand = new ViewModelCommand(ExecuteGGadeCommand);
            LadeCommand = new ViewModelCommand(ExecuteLadeCommand);
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                var imagePaths = new Dictionary<enumInventroy, string>
                {
                    { enumInventroy.자몽에이드, inventory.imgPath["자몽에이드"] },
                    { enumInventroy.청포도에이드, inventory.imgPath["청포도에이드"] },
                     { enumInventroy.레몬에이드, inventory.imgPath["레몬에이드"] },
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
                        case enumInventroy.자몽에이드:
                            GadeImageSource = bitmap;
                            break;
                        case enumInventroy.청포도에이드:
                            GGadeImageSource = bitmap;
                            break;
                        case enumInventroy.레몬에이드:
                            LadeImageSource = bitmap;
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);
            }
        }

        private void ExecuteLadeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "레몬 에이드",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteGGadeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "청포도 에이드",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteGadeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "자몽 에이드",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}
