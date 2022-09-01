namespace CalculatorUI
{
    /// <summary>
    /// �p�������
    /// </summary>
    public partial class Calculator : Form
    {
        /// <summary>
        /// �VAPI�o�e�ШD������
        /// </summary>
        Client RequestObject;

        /// <summary>
        /// �غc�l�A��l�ƭp���
        /// </summary>
        public Calculator()
        {           
            InitializeComponent();
            RequestObject = new Client();
        }

        /// <summary>
        /// ����@��ClickEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ShowBox.Text = await RequestObject.Response(button.Name);
        }

        /// <summary>
        /// �p��������ɡA�|�M��api����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCloseEvent(object sender, FormClosingEventArgs e)
        {
            RequestObject.Leave();
        }
    }
}