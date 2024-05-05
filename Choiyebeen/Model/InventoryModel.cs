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
        자몽에이드=21
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

            imgPath["아메리카노"] = "/images/coffee/icecoffee.png";
            imgPath["카페라떼"] = "";
            imgPath["자몽에이드"] = "/images/ade/Gade.png";
        }

        public Dictionary<string, int> inventoryCount;
        public Dictionary<string, string> imgPath;
        public ImageSource[] imageSource;


    }
}
