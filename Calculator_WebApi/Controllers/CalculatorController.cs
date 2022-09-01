using Microsoft.AspNetCore.Mvc;

namespace Calculator_WebApi.Controllers
{
    /// <summary>
    /// �p���API�����
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// �p����إ߮ɡA�����@�ӭp���ID
        /// </summary>
        /// <returns>�p���ID</returns>
        [HttpGet("Create")]
        public string Create()
        {
            CalculatorState newCalculator = new CalculatorState();
            return SharedFunction.GetCalculatorID(newCalculator);
        }

        /// <summary>
        /// �p����Ǩӫ���W�١A�öǦ^�p��᪺���A
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
                    return NotFound("�L�k������p���");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// �Ȥ�����}�ɧR�������p���
        /// </summary>
        /// <param name="calculatorId">�p���ID</param>
        /// <returns>�����r��</returns>
        [HttpGet("{calculatorId}/Leave")]
        public string Leave(string calculatorId)
        {
            CalculatorMapping.IdToCalculator.TryRemove(calculatorId, out CalculatorState ignore);
            return $"�����s��:{calculatorId} �p���";
        }
    }
}