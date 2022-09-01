namespace Calculator_WebApi.Button
{
    /// <summary>
    /// 全部清除的按鍵
    /// </summary>
    public class CleanAll:ButtonBase
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
        public CleanAll(string buttonName)
        {
            Button = buttonName;
            IsNumber = false;
            IsUnaryOperaotr = true;
            IsBinaryOperaotr = false;
        }

        /// <summary>
        /// 確認括號數量，並進行增減
        /// </summary>
        /// <param name="bracketNumber">括號數量</param>
        public virtual void CheckBracket(ref int bracketNumber)
        {
            bracketNumber = 0;
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
            tree = new Node(String.Empty, 1);
            presentNode = tree;
            upLineString = string.Empty; 
            downLineString = string.Empty;
        }
    }
}
