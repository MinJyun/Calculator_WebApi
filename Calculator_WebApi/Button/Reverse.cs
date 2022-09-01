using static Calculator_WebApi.SharedFunction;

namespace Calculator_WebApi.Button
{
    /// <summary>
    /// 倒數的按鍵
    /// </summary>
    public class Reverse:ButtonBase
    {
        /// <summary>
        /// 按鍵名稱
        /// </summary>
        public override string Button { get; set; }

        /// <summary>
        /// 是否為數字
        /// </summary>
        public override bool IsNumber { get; set; }

        /// <summary>
        /// 是否為一元運算子
        /// </summary>
        public override bool IsUnaryOperaotr { get; set; }

        /// <summary>
        /// 是否為二元運算子
        /// </summary>
        public override bool IsBinaryOperaotr { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="buttonName">按鍵名稱</param>
        public Reverse(string buttonName)
        {
            Button = buttonName;
            IsNumber = false;
            IsUnaryOperaotr = true;
            IsBinaryOperaotr = false;
        }

        /// <summary>
        /// 現在的表示式再輸入這個按鍵是否合法
        /// </summary>
        /// <param name="bracketNumber">括號數量</param>
        /// <param name="lastButton">上一次的按鍵</param>
        /// <param name="presentNode">現在節點</param>
        /// <returns>是否合法</returns>
        public override bool IsLegal(int bracketNumber, ButtonBase lastButton, Node presentNode)
        {
            if (IsLeaf(presentNode) && !IsLastWordDot(presentNode) && !IsLastLeftBracket(presentNode) && !IsZero(presentNode))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判斷當節點數值是否為0
        /// </summary>
        /// <param name="presentNode">當節點</param>
        /// <returns>判斷</returns>
        private bool IsZero(Node presentNode)
        {
            if(!string.IsNullOrEmpty(presentNode.Value))
            {
                if(decimal.TryParse(presentNode.Value, out decimal value) && !decimal.Equals(value, 0m))
                { 
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 處理流程
        /// </summary>
        /// <param name="upLineString">上行文字</param>
        /// <param name="downLineString">下行文字</param>
        /// <param name="lastButton">上一次得按鍵</param>
        /// <param name="tree">樹</param>
        /// <param name="presentNode">現在的節點</param>
        public override void Process(ref string upLineString, ref string downLineString, ButtonBase lastButton, ref Node tree, ref Node presentNode)
        {
            decimal value = 0;
            if (!string.IsNullOrEmpty(presentNode.Value) && decimal.TryParse(presentNode.Value, out decimal presentValue))
            {
                value = 1/presentValue;
            }
            downLineString = WriteReverse(downLineString);
            presentNode.Value = $"{value}";
        }

        /// <summary>
        /// 寫成倒數的方法
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>倒數的樣子</returns>
        private string WriteReverse(string value)
        {
            if (value.Contains("1/"))
            {
                value = value.Replace("1/", string.Empty);
            }
            else 
            {
                value = $"1/{value}";
            }
            return value;
        }
    }
}
