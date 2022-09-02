namespace Calculator_WebApi
{
    /// <summary>
    /// 共用方法
    /// </summary>
    internal static class SharedFunction
    {
        /// <summary>
        /// 取得計算機ID並且將計算機加入對應，以應付多線開啟不同計算機
        /// </summary>
        /// <param name="newCalculator"></param>
        /// <returns></returns>
        internal static string GetCalculatorID(CalculatorState newCalculator, CalculatorMapping map)
        {
            string randomID = Guid.NewGuid().ToString();
            //如果取到相同ID(雖然很難)，就遞迴取到不重複為止
            if (!map.IdToCalculator.TryAdd(randomID, newCalculator))
            {
                return GetCalculatorID(newCalculator, map);
            }
            return randomID;
        }

        /// <summary>
        /// 前一個按鍵是等於的話要清掉螢幕顯示
        /// </summary>
        /// <param name="upLineString">上行字幕</param>
        /// <param name="downLineString">下行字幕</param>
        /// <param name="lastButton">上一個按鍵</param>
        internal static void WipeBlackBoard(ref string upLineString, ref string downLineString, ButtonBase lastButton)
        {
            if(lastButton.Button == "=")
            { 
                upLineString = string.Empty;
                downLineString = string.Empty;
            }
        }

        /// <summary>
        /// 是否為葉節點
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsLeaf(Node root)
        {
            return (root.LeftNode == null && root.RightNode == null);
        }

        /// <summary>
        /// 最後一個字是否為.
        /// </summary>
        /// <param name="root">節點</param>
        /// <returns>是與否</returns>
        public static bool IsLastWordDot(Node root)
        {
            if (string.IsNullOrEmpty(root.Value))
            { 
                return false;
            }
            else
            {
                return root.Value.Substring(root.Value.Length - 1, 1) == ".";
            }
        }

        /// <summary>
        /// 是否在左括號節點
        /// </summary>
        /// <param name="root">節點</param>
        /// <returns>是否</returns>
        public static bool IsLastLeftBracket(Node root)
        {
            if (string.IsNullOrEmpty(root.Value))
            {
                return false;
            }
            else
            {
                return root.Value == "(";
            }
        }

        /// <summary>
        /// 運算樹的值
        /// </summary>
        /// <param name="root">樹</param>
        /// <returns>計算值</returns>
        public static decimal EvalTree(Node root)
        {
            // 空樹
            if (root == null || string.IsNullOrEmpty(root.Value))
            {
                return 0;
            }

            // 葉節點
            if (IsLeaf(root))
            {
                return decimal.Parse(root.Value);
            }

            // 估左子樹
            decimal leftEval = EvalTree(root.LeftNode);

            // 估右子樹
            decimal rightEval = EvalTree(root.RightNode);

            // 運算子節點
            switch (root.Value)
            {
                case "+":
                    return leftEval + rightEval;
                case "-":
                    return leftEval - rightEval;
                case"*":
                    return leftEval * rightEval;
                default:
                    return leftEval / rightEval;
            }
        }
    }
}
