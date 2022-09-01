namespace CalculatorUI
{
    /// <summary>
    /// 計算機介面
    /// </summary>
    public partial class Calculator : Form
    {
        /// <summary>
        /// 向API發送請求的物件
        /// </summary>
        Client RequestObject;

        /// <summary>
        /// 建構子，初始化計算機
        /// </summary>
        public Calculator()
        {           
            InitializeComponent();
            RequestObject = new Client();
        }

        /// <summary>
        /// 按鍵共用ClickEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ShowBox.Text = await RequestObject.Response(button.Name);
        }

        /// <summary>
        /// 計算機關閉時，會清除api的對應物件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCloseEvent(object sender, FormClosingEventArgs e)
        {
            RequestObject.Leave();
        }
    }
}