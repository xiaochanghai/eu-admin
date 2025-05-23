﻿namespace EU.Core.Controllers.v2
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name), ApiExplorerSettings(GroupName = Grouping.GroupName_Other)]
    public class ApbController : ControllerBase
    {


        /************************************************/
        // 如果需要使用Http协议带名称的，比如这种 [HttpGet("apbs")]
        // 目前只能把[CustomRoute(ApiVersions.v2)] 提到 controller 的上边，做controller的特性
        // 并且去掉//[Route("api/[controller]")]路由特性，否则会有两个接口
        /************************************************/


        [HttpGet("apbs")]
        public IEnumerable<string> Get()
        {
            return new string[] { "第二版的 apbs" };
        }


    }
}
