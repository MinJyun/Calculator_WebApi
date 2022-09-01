using Calculator_WebApi.Button;
using System.Reflection;
using static Calculator_WebApi.SharedFunction;

namespace Calculator_WebApi
{
    /// <summary>
    /// 紀錄計算機現在狀態的類別
    /// </summary>
    public class CalculatorState
    {
        /// <summary>
        /// 回傳字幕上行
        /// </summary>
        private string UpLineString = string.Empty;

        /// <summary>
        /// 回傳字幕下行
        /// </summary>
        private string DownLineString = string.Empty;

        /// <summary>
        /// 左括號數量
        /// </summary>
        private int BracketNumber = 0;

        /// <summary>
        /// 上一個按鍵
        /// </summary>
        private ButtonBase LastButton = new Number("0");

        /// <summary>
        /// 運算樹
        /// </summary>
        private Node Tree = new Node(String.Empty, 1);

        /// <summary>
        /// 現在節點
        /// </summary>
        private Node PresentNode;

        /// <summary>
        /// 建構子
        /// </summary>
        public CalculatorState()
        {
            PresentNode = Tree;
        }

        /// <summary>
        /// 按鍵對應類別
        /// </summary>
        private Dictionary<string, ButtonBase> ButtonCorrespond = new Dictionary<string, ButtonBase>()
        { { "Zero", new Number("0") }, { "One", new Number("1") }, { "Two", new Number("2") }, { "Three", new Number("3") }, 
          { "Four", new Number("4") }, { "Five", new Number("5") }, { "Six", new Number("6") }, { "Seven", new Number("7") }, 
          { "Eight", new Number("8") }, { "Nine", new Number("9") }, { "Plus", new PlusAndMinus("+") }, { "Minus", new PlusAndMinus("-") }, 
          { "Cross", new CrossAndDivide("*") }, { "Divide", new CrossAndDivide("/") }, { "LeftBracket", new LeftBracket("(") }, 
          { "RightBracket", new RightBracket(")") }, { "Dot", new Dot(".") }, { "PlusMinus", new ChangeSign("+/-") },
          { "Percent", new Percent("%") }, { "Reverse", new Reverse("1/x") }, { "Clean", new Clean("CE") }, { "CleanAll", new CleanAll("C") },
          { "Back", new Back("←") }, { "Equal", new Equal("=") }
          };

        /// <summary>
        /// 接收客戶端得按鍵後，計算的運行流程
        /// </summary>
        /// <param name="buttonName">按鍵名稱</param>
        /// <returns>回傳結果</returns>
        public string ResponseResult(string buttonName)
        {
            if (ButtonCorrespond.TryGetValue(buttonName, out ButtonBase button))
            {
                if (button.IsLegal(BracketNumber, LastButton, PresentNode))
                {
                    //前一個按鍵是等於的話，清掉字幕
                    WipeBlackBoard(ref UpLineString, ref DownLineString, LastButton);
                    //確認現行左括號數量
                    button.CheckBracket(ref BracketNumber);
                    //運算邏輯
                    button.Process(ref UpLineString, ref DownLineString, LastButton, ref Tree, ref PresentNode);
                    //現在按鍵變成前一個按鍵
                    LastButton = button;                   
                    return $"{UpLineString}{Environment.NewLine}{DownLineString}";
                }
                else
                {
                    return "請按下合適的按鍵";
                }
            }
            else
            {
                return "無此按鈕";
            }
        }
    }
}
