﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkSocket.Http;
using HttpServer.Filters;
using NetworkSocket.Core;

namespace HttpServer.Controller
{
    [Route("/api/token")] //路由映射
    public class TokenController : HttpController
    {
        public class model
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        [LogFilter("Test方法收到Get请求了")]
        public ActionResult Test(model m)
        {
            return Json(new { m.x, m.y });
        }

        [HttpPost]
        [LogFilter("Test方法收到Post请求了")]
        public ActionResult Test(model m, DateTime? t)
        {
            return Json(new { m.x, m.y });
        }

        [Api("ApiTest")] // 接口名修饰
        public ActionResult TestApi(string input)
        {
            return Content(input);
        }
    }
}
