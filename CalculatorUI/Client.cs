using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    /// <summary>
    /// 用來溝通API的類別
    /// </summary>
    internal class Client
    {
        /// <summary>
        /// 計算機ID
        /// </summary>
        private readonly string CalculatorID;

        /// <summary>
        /// 請求的類別
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// 建構子，建立初始BaseUrl以及取得計算機ID
        /// </summary>
        public Client() 
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7244/");
            CalculatorID = _client.GetAsync($"Calculator/Create").Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 傳出按鍵請求
        /// </summary>
        /// <param name="buttonName"></param>
        /// <returns></returns>
        public async Task<string> Response(string buttonName)
        {           
            return await _client.GetAsync($"Calculator/{CalculatorID}/Click/{buttonName}").Result.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 關閉時移除API計算機物件
        /// </summary>
        public async void Leave()
        {
            string close = await _client.GetAsync($"Calculator/{CalculatorID}/Leave").Result.Content.ReadAsStringAsync();
            MessageBox.Show(close);
        }
    }
}
