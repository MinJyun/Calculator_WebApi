using static Calculator_WebApi.SharedFunction;

namespace Calculator_WebApi.Button
{
    /// <summary>
    /// 加或減的按鍵
    /// </summary>
    public class PlusAndMinus : ButtonBase
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
        public PlusAndMinus(string buttonName)
        {
            Button = buttonName;
            IsNumber = false;
            IsUnaryOperaotr = false;
            IsBinaryOperaotr = true;
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
            if (IsLeaf(presentNode))
            {
                return true;
            }
            return false;
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

            while (presentNode.TopNode != null && presentNode.TopNode.Prioraty < 4)
            {
                presentNode = presentNode.TopNode;
            }
            Node temp = new Node(Button, 3);
            if (presentNode.TopNode == null)
            {
                temp.LeftNode = presentNode;
                presentNode.TopNode = temp;
                presentNode = temp;
                tree = presentNode;
            }
            else
            {
                presentNode.TopNode.RightNode = temp;
                temp.TopNode = presentNode.TopNode;
                temp.LeftNode = presentNode;
                presentNode.TopNode = temp;
                presentNode = temp;
            }

            upLineString = $"{upLineString}{downLineString}{Button}";
            downLineString = String.Empty;
        }
    }
}
