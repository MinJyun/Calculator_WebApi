namespace Calculator_WebApi
{
    /// <summary>
    /// 按鍵的基礎類別
    /// </summary>
    public abstract class ButtonBase
    {
        /// <summary>
        /// 按鍵名稱
        /// </summary>
        public abstract string Button { get; set; }

        /// <summary>
        /// 是否為數字
        /// </summary>
        public abstract bool IsNumber { get; set; }

        /// <summary>
        /// 是否為一元運算子
        /// </summary>
        public abstract bool IsUnaryOperaotr { get; set; }

        /// <summary>
        /// 是否為二元運算子
        /// </summary>
        public abstract bool IsBinaryOperaotr { get; set; }

        /// <summary>
        /// 現在的表示式再輸入這個按鍵是否合法
        /// </summary>
        /// <param name="bracketNumber">括號數量</param>
        /// <param name="lastButton">上一次的按鍵</param>
        /// <param name="presentNode">現在節點</param>
        /// <returns>是否合法</returns>
        public virtual bool IsLegal(int bracketNumber, ButtonBase lastButton, Node presentNode)
        {
            return true;
        }

        /// <summary>
        /// 確認括號數量，並進行增減
        /// </summary>
        /// <param name="bracketNumber">括號數量</param>
        public virtual void CheckBracket(ref int bracketNumber)
        {
        }

        /// <summary>
        /// 處理流程
        /// </summary>
        /// <param name="upLineString">上行文字</param>
        /// <param name="downLineString">下行文字</param>
        /// <param name="lastButton">上一次得按鍵</param>
        /// <param name="tree">樹</param>
        /// <param name="presentNode">現在的節點</param>
        public abstract void Process(ref string upLineString, ref string downLineString, ButtonBase lastButton, ref Node tree, ref Node presentNode);
    }
}
