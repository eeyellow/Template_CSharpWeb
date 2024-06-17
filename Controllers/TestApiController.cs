using LC.Infrastructure.AppSettings;

namespace Template_CSharpWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestApiController : BaseController<TestApiController>
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="diagnosticContext"></param>
        /// <param name="webHostEnvironment"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public TestApiController(ILogger<TestApiController> logger,
                                 IDiagnosticContext diagnosticContext,
                                 IWebHostEnvironment webHostEnvironment,
                                 IOptions<AppSettingsOptions> options) : base(logger, diagnosticContext, webHostEnvironment, options)
        {

        }

        /// <summary>
        /// 取得亂數
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetRandom()
        {
            var rnd = new Random();
            return Ok(rnd.Next(0, 10));
        }

        /// <summary>
        /// 取得亂數
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> GetRandomAuth()
        {
            var rnd = new Random();
            return Ok(rnd.Next(0, 10));
        }
    }
}
