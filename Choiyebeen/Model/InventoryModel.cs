using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Choiyebeen.Model
{

    //총 28개
    public enum enumInventroy
    {
        아메리카노=0, 
        카페라떼=1,
        카라멜마끼야또=2,
        헤이즐럿라떼=3,
        카페모카=4,
        바닐라라떼=5,
        사이다=6,
        콜라=7,
        시트러스차=8,
        생강차=9,
        한라봉차=10,
        히비스커스차=11,
        자스민차=12,
        레몬차=13,
        오미자차=14,
        복숭아아이스티=15,
        플레인요거트스무디=16,
        블루베리요거트스무디=17,
        딸기요거트스무디=18,
        망고요거트스무디=19,
        자몽에이드=20,
        청포도에이드=21,
        레몬에이드=22,
        컵쿠키=23,
        쿠키=24,
        아이스크림=25,
        마카롱=26,
        커피콩빵=27,
    }
    public class InventoryModel
    {
        private static InventoryModel instance;
        private static readonly object padlock = new object();

        // 정수 키와 함수를 저장할 딕셔너리
        private Dictionary<int, Action> actions = new Dictionary<int, Action>();

        // 인스턴스를 얻기 위한 프로퍼티
        public static InventoryModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new InventoryModel();
                    }
                    return instance;
                }
            }
        }

        // 다른 클래스의 함수를 등록하는 메서드
        public void RegisterAction(int key, Action action)
        {
            actions[key] = action; // 키가 이미 있으면 덮어쓰기 됩니다.
        }

        // 특정 키로 등록된 함수를 호출하는 메서드
        public void InvokeAction(int key)
        {
            if (actions.TryGetValue(key, out Action action))
            {
                action.Invoke();
            }
            else
            {
                Console.WriteLine("No action registered with key: " + key);
            }
        }

        //물품 여기에 하나하나 다 적어야 함
        private InventoryModel()
        {
            inventoryCount = new Dictionary<string, int>();
            imgPath = new Dictionary<string, string>();
            imageSource = new ImageSource[100];

            inventoryCount["아메리카노"] = 20;
            inventoryCount["카페라떼"] = 20;
            inventoryCount["카라멜마끼야또"] = 20;
            inventoryCount["헤이즐럿라떼"] = 20;
            inventoryCount["카페모카"] = 20;
            inventoryCount["바닐라라떼"] = 20;

            inventoryCount["사이다"] = 20;
            inventoryCount["콜라"] = 20;

            inventoryCount["시트러스차"] = 20;
            inventoryCount["생강차"] = 20;
            inventoryCount["한라봉차"] = 20;
            inventoryCount["히비스커스차"] = 20;
            inventoryCount["레몬차"] = 20;
            inventoryCount["자스민차"] = 20;
            inventoryCount["복숭아아이스티"] = 20;
            inventoryCount["오미자차"] = 20;

            inventoryCount["플레인요거트스무디"] = 20;
            inventoryCount["블루베리요거트스무디"] = 20;
            inventoryCount["딸기요거트스무디"] = 20;
            inventoryCount["망고요거트스무디"] = 20;

            inventoryCount["청포도에이드"] = 20;
            inventoryCount["레몬에이드"] = 20;
            inventoryCount["자몽에이드"] = 20;

            inventoryCount["컵쿠키"] = 20;
            inventoryCount["쿠키"] = 20;
            inventoryCount["아이스크림"] = 20;
            inventoryCount["마카롱"] = 20;
            inventoryCount["커피콩빵"] = 20;



            imgPath["아메리카노"] = "/images/coffee/icecoffee_in.png";
            imgPath["카페라떼"] = "/images/coffee/icelatte_in.png";
            imgPath["카라멜마끼야또"] = "/images/coffee/Clatte_in.png";
            imgPath["헤이즐럿라떼"] = "/images/coffee/Hlatte_in.png";
            imgPath["카페모카"] = "/images/coffee/Mochalatte_in.png";
            imgPath["바닐라라떼"] = "/images/coffee/Vlatte_in.png";

            imgPath["사이다"] = "/images/Carbonated/Cider_in.png";
            imgPath["콜라"] = "/images/Carbonated/Coca_in.png";

            imgPath["시트러스차"] = "/images/tea/Ctea_in.png";
            imgPath["생강차"] = "/images/tea/Gtea_in.png";
            imgPath["한라봉차"] = "/images/tea/Htea_in.png";
            imgPath["히비스커스차"] = "/images/tea/Hbtea_in.png";
            imgPath["레몬차"] = "/images/tea/Ltea_in.png";
            imgPath["자스민차"] = "/images/tea/Jtea_in.png";
            imgPath["복숭아아이스티"] = "/images/tea/Ptea_in.png";
            imgPath["오미자차"] = "/images/tea/Otea_in.png";

            imgPath["플레인요거트스무디"] = "/images/smoothie/Pyogurt_in.png";
            imgPath["블루베리요거트스무디"] = "/images/smoothie/Byogurt_in.png";
            imgPath["딸기요거트스무디"] = "/images/smoothie/Syogurt_in.png";
            imgPath["망고요거트스무디"] = "/images/smoothie/Myogurt_in.png";

            imgPath["자몽에이드"] = "/images/ade/Gade_in.png";
            imgPath["청포도에이드"] = "/images/ade/GGade_in.png";
            imgPath["레몬에이드"] = "/images/ade/Lade_in.png";

            imgPath["컵쿠키"] = "/images/desert/Cupcookie_in.png";
            imgPath["쿠키"] = "/images/desert/Cookie_in.png";
            imgPath["아이스크림"] = "/images/desert/Icecream_in.png";
            imgPath["마카롱"] = "/images/desert/Macaron_in.png";
            imgPath["커피콩빵"] = "/images/desert/Beanbread_in.png";
        }

        public Dictionary<string, int> inventoryCount;
        public Dictionary<string, string> imgPath;
        public ImageSource[] imageSource;


    }
}
