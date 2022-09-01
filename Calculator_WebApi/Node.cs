namespace Calculator_WebApi
{
    /// <summary>
    /// 節點的類別
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 值
        /// </summary>
        public string Value;

        /// <summary>
        /// 優先權
        /// </summary>
        public int Prioraty { get; set; }

        /// <summary>
        /// 上節點
        /// </summary>
        public Node? TopNode { get; set; }

        /// <summary>
        /// 左節點
        /// </summary>
        public Node? LeftNode { get; set; }

        /// <summary>
        /// 右節點
        /// </summary>
        public Node? RightNode { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="prioraty">優先權</param>
        public Node(string value, int prioraty)
        {
            Value = value;
            Prioraty = prioraty;
        }
    }
}
