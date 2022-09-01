namespace Calculator_WebApi.Button
{
    /// <summary>
    /// 數字的按鍵
    /// </summary>
    public class Number : ButtonBase
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
        public Number(string number)
        {
            Button = number;
            IsNumber = true;
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
            if (lastButton.Button == ")")
            {
                return false;
            }
            return true;
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
            if(lastButton.IsBinaryOperaotr || lastButton.Button == "(")
            {
                Node temp = new Node(String.Empty, 1);
                temp.TopNode = presentNode;
                presentNode.RightNode = temp;
                presentNode = temp;
            }
            downLineString = $"{downLineString}{Button}";
            presentNode.Value = $"{presentNode.Value}{Button}";
        }
    }
}
