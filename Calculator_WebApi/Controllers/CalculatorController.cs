using Microsoft.AspNetCore.Mvc;

namespace Calculator_WebApi.Controllers
{
    /// <summary>
    /// 計算機API的控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// 計算機建立時，給予一個計算機ID
        /// </summary>
        /// <returns>計算機ID</returns>
        [HttpGet("Create")]
        public string Create()
        {
            CalculatorState newCalculator = new CalculatorState();
            return SharedFunction.GetCalculatorID(newCalculator);
        }

        /// <summary>
        /// 計算機傳來按鍵名稱，並傳回計算後的狀態
        /// </summary>
        /// <param name="calculatorId"></param>
        /// <param name="buttonName"></param>
        /// <returns></returns>
        [HttpGet("{calculatorId}/Click/{buttonName}")]
        public ActionResult<string> Get(string calculatorId, string buttonName)
        {
            try
            {
                if (CalculatorMapping.IdToCalculator.TryGetValue(calculatorId, out CalculatorState currentCalculator))
                {
                    return Ok(currentCalculator.ResponseResult(buttonName));
                }
                else
                {
                    return NotFound("無法對應到計算機");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 客戶端離開時刪除對應計算機
        /// </summary>
        /// <param name="calculatorId">計算機ID</param>
        /// <returns>關閉字樣</returns>
        [HttpGet("{calculatorId}/Leave")]
        public string Leave(string calculatorId)
        {
            CalculatorMapping.IdToCalculator.TryRemove(calculatorId, out CalculatorState ignore);
            return $"關閉編號:{calculatorId} 計算機";
        }
    }
}