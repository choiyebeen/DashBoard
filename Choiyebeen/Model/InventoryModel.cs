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
        히비스커스=11,
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
            inventoryCount["자몽에이드"] = 20;

            imgPath["아메리카노"] = "/images/coffee/icecoffee_in.png";
            imgPath["카페라떼"] = "";
            imgPath["자몽에이드"] = "/images/ade/Gade_in.png";
        }

        public Dictionary<string, int> inventoryCount;
        public Dictionary<string, string> imgPath;
        public ImageSource[] imageSource;


    }
}
