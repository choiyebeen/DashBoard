using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Choiyebeen.Model;
using Choiyebeen.Repositories;
using FontAwesome.Sharp;
using MySqlX.XDevAPI;
using Newtonsoft.Json;

namespace Choiyebeen.ViewModel
{
   public class MainViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private IUserRepository userRepository;
        private int m_price;
        private ObservableCollection<CartModel> m_cart_list; //이걸 통해서 표 만들어짐
        private DispatcherTimer m_timer;
        InventoryModel inventory;
        string queryString = "gocheok"; // 고척점
        //chingil 신길점
        //siheung 시흥점

        //properties
        public ObservableCollection<CartModel> CartList
        {
            get
            {
                return m_cart_list;
            }
            set
            {
                m_cart_list = value;
                OnPropertyChanged(nameof(CartList));
            }
        }

        public int Price
        {
            get 
            {
                return m_price; 
            }

            set
            {
                m_price = value;
                OnPropertyChanged(nameof(Price));
            }

        }
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView // 뷰모델 베이스를 넘겨줘야함 / 뷰 모델 베이스로 사용
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return Caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        
        //--> commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowTeaCommand { get; }
        public ICommand ShowSmoothieCommand { get; }
        public ICommand ShowAdeCommand { get; }
        public ICommand ShowDesertCommand { get; }
        public ICommand PayCommand { get; set; }
        public ICommand CancleCommand { get; set; }

        public MainViewModel() //생성자 처음에 사용
        {
            inventory = InventoryModel.Instance;
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            m_price = 0;

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowTeaCommand = new ViewModelCommand(ExecuteShowTeaCommand);
            ShowSmoothieCommand = new ViewModelCommand(ExecuteShowSmoothieCommand);
            ShowAdeCommand = new ViewModelCommand(ExecuteShowAdeCommand);
            ShowDesertCommand = new ViewModelCommand(ExecuteShowDesertCommand);
            PayCommand = new ViewModelCommand(ExecutePayCommand);
            CancleCommand = new ViewModelCommand(ExecuteCancleCommand);

            CartList = new ObservableCollection<CartModel>(); //생성자에서 객체화
            



            //Default view
            ExecuteShowCustomerViewCommand(null);

            LoadCurrentUserData();

            //m_timer = new Timer(async (_) => await WebGet(), null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            m_timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            m_timer.Tick += async (sender, e) => await WebGet();
            m_timer.Start();
        }

        public async Task WebGet()
        {
            using (HttpClient client = new HttpClient()) //한글파일 2번
            {
                //추가
                client.Timeout = TimeSpan.FromSeconds(10); // 타임아웃 시간 설정
                try
                {
                    // GET 요청 보내기sonResponse);
                    HttpResponseMessage response = await client.GetAsync("http://192.168.118.252:8080/store/" + queryString); // 상대방 컴퓨터 ip주소 및 포트 + /get 상대방이 있어서 적어줘야함

                    // 응답 확인
                    if (response.IsSuccessStatusCode)
                    {
                        // JSON 응답을 문자열로 읽기
                        string jsonString = await response.Content.ReadAsStringAsync();

                        // JSON 문자열을 객체로 변환
                        var responseObj = JsonConvert.DeserializeObject<Inventory>(jsonString);

                        foreach (var item in responseObj.Detail)
                        {
                            inventory.inventoryCount[item.Product]= int.Parse(item.Count);
                            if (inventory.inventoryCount[item.Product] == 0)
                            {
                                inventory.imgPath[item.Product]=  inventory.imgPath[item.Product].Replace("_in", "_out");
                            }
                            else
                            {
                                inventory.imgPath[item.Product]= inventory.imgPath[item.Product].Replace("_out", "_in");
                            }
                        }

                        Dispatcher.CurrentDispatcher.Invoke(() =>
                        {
                            inventory.InvokeAction(0);
                            inventory.InvokeAction(1);
                            inventory.InvokeAction(2);
                            inventory.InvokeAction(3);
                            inventory.InvokeAction(4);
                            inventory.InvokeAction(5);
                        });

                        //inventory.InvokeAction(0);
                        /*                        inventory.InvokeAction(1);
                                                inventory.InvokeAction(2);
                                                inventory.InvokeAction(3);
                                                inventory.InvokeAction(4);
                                                inventory.InvokeAction(5);*/

                        // 결과 출력
                        //MessageBox.Show(jsonString);
                    }
                    else
                    {
                       // MessageBox.Show("서버로부터 응답을 받지 못했습니다. 상태 코드: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                  //  MessageBox.Show("오류 발생: " + ex.Message);
                }
            }
        }


        private void ExecuteCancleCommand(object obj)
        {
            MessageBoxResult cancle = MessageBox.Show("결제 취소하시겠습니까?", "결제 취소", MessageBoxButton.YesNo);

            if (cancle == MessageBoxResult.Yes)
            {
                CartList.Clear();
                Price = 0;
            }
        }

        private async void ExecutePayCommand(object obj)
        {
           MessageBoxResult result = MessageBox.Show($"{Price}원을 결제 하시겠습니까?","결제",MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                //여기에 코드 추가함
                DateTime currentTime = DateTime.Now;
                List<ProductDetail> productDetails = new List<ProductDetail>();
                foreach (var item in CartList)
                {
                    productDetails.Add(new ProductDetail
                    {
                        product = item.ItemName,
                        count = item.ItemCount,
                        price = item.ItemPrice,

                    });
                }

                SalesData salesData = new SalesData
                {
                    store = "고척점",
                    time = currentTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    detail = productDetails
                };

                bool isSuccess = await WebPost(salesData);
                if(isSuccess)
                {
                    MessageBoxResult receipt = MessageBox.Show("영수증을 출력하시겠습니까?", "영수증", MessageBoxButton.YesNo);
                    MessageBoxResult Thx = MessageBox.Show("감사합니다");
                }
                else
                {
                    MessageBoxResult receipt = MessageBox.Show("영수증을 출력하시겠습니까?", "영수증", MessageBoxButton.YesNo);
                    MessageBox.Show("서버와의 연결상태를 확인해주세요.");
                }
                CartList.Clear();
                Price = 0;
            }
        }


        public async Task<bool> WebPost(SalesData salesData) //한글파일 1번
        {
            using (HttpClient client = new HttpClient())
            {
                //추가
                client.Timeout = TimeSpan.FromSeconds(1); // 타임아웃 시간 설정

                try
                {
                    // C# 객체를 JSON 문자열로 직렬화
                    string reqJsonString = JsonConvert.SerializeObject(salesData); //salesData를 Json 문자열로 바꿔서 reqJsonString에 저장
                                                                                   // POST 요청을 위한 데이터 생성
                    var postData = new StringContent(reqJsonString, System.Text.Encoding.UTF8, "application/json"); //key,value 바꾸기 //reqJsonStrins 로 사용

                    // POST 요청 보내기
                    HttpResponseMessage response = await client.PostAsync("http://192.168.118.252:8080/post", postData); // 서영언니 주소(IPv4)만 바꿔서 테스트 ex.http://192.168.173.252:8080/post

                    // 응답 확인
                    if (response.IsSuccessStatusCode)
                    {
                        // JSON 응답을 문자열로 읽기
                        string jsonString = await response.Content.ReadAsStringAsync();

                        // 출력
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        // 구매 장바구니
        private void MainViewModelPriceChanged(object sender, CartModel newValue) //desertViewModel에서 newValue로 값이 넘어옴
        {
            int index = -1;
            for (int i = 0; i < CartList.Count; i++) //CartList.Count는 장바구니에 있는 갯수
            {
                if(CartList[i].ItemName == newValue.ItemName) 
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                CartList[index].ItemCount++;
                CartList[index].ItemPrice += newValue.ItemPrice;
                var tempCartList = new ObservableCollection<CartModel>(CartList);
                CartList = tempCartList; //우회

            }
            else
            {
                CartList.Add(newValue); //못 찾음
            }

            Price += newValue.ItemPrice; //가격 더하기
        }



        private void ExecuteShowDesertCommand(object obj)
        {
            var desertViewModel = new DesertViewModel();
            desertViewModel.PriceChanged += MainViewModelPriceChanged; //priceChanged의 값이 바뀌면 MainViewModelPriceChanged가 자동 사용
            Caption = "Desert";
            Icon = IconChar.Home;
            CurrentChildView = desertViewModel; //화면전환
        }

        private void ExecuteShowAdeCommand(object obj)
        {
            var adeViewModel = new AdeViewModel();
            adeViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Ade";
            Icon = IconChar.Home;
            CurrentChildView = adeViewModel;
        }

        private void ExecuteShowSmoothieCommand(object obj)
        {
            var smoothieViewModel = new SmoothieViewModel();
            smoothieViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Smoothie";
            Icon = IconChar.Home;
            CurrentChildView = smoothieViewModel;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            var customerViewModel = new CustomerViewModel();
            customerViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Customers";
            Icon = IconChar.UserGroup;
            CurrentChildView = customerViewModel;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Dashboard";
            Icon = IconChar.Home;
            CurrentChildView = homeViewModel;
        }

        private void ExecuteShowTeaCommand(object obj)
        {
            var teaViewModel = new TeaViewModel();
            teaViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Tea";
            Icon = IconChar.Home;
            CurrentChildView = teaViewModel;
        }

       


        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $" {user.Name} {user.LastName}";
                    CurrentUserAccount.ProfilePicture = null;
              
            }
            else
            {
                CurrentUserAccount.DisplayName="";
                //hide child view
            }
        }
    }
}
