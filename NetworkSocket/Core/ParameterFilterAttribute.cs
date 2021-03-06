﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSocket.Core
{
    /// <summary>
    /// 表示Api行为的参数过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public abstract class ParameterFilterAttribute : FilterAttribute
    {
        /// <summary>
        /// 参数
        /// </summary>
        private ApiParameter parameter;

        /// <summary>
        /// 绑定参数
        /// </summary>
        /// <param name="parameter">参数</param>
        internal ParameterFilterAttribute BindParameter(ApiParameter parameter)
        {
            this.parameter = parameter;
            return this;
        }

        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="filterContext"></param>
        protected sealed override void OnExecuting(IActionContext filterContext)
        {
            this.OnOnExecuting(filterContext.Action, this.parameter);
        }

        /// <summary>
        /// 执行后
        /// </summary>
        /// <param name="filterContext"></param>
        protected sealed override void OnExecuted(IActionContext filterContext)
        {
        }

        /// <summary>
        /// 异常时
        /// </summary>
        /// <param name="filterContext"></param>
        protected sealed override void OnException(IExceptionContext filterContext)
        {
        }

        /// <summary>
        /// Api执行之前
        /// 在此检测parameter的输入合理性
        /// 不合理可以抛出异常
        /// </summary>
        /// <param name="action">关联的Api行为</param>
        /// <param name="parameter">参数信息</param>
        public abstract void OnOnExecuting(ApiAction action, ApiParameter parameter);
    }
}
