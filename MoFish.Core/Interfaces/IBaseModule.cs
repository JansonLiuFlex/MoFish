using System;
using System.Collections.Generic;
using System.Text;

namespace MoFish.Core.Interfaces
{
    public interface IBaseModule
    {
        /// <summary>
        /// 关联默认数据上下文
        /// </summary>
        void BindDefaultModel();

        object GetView();

        /// <summary>
        /// 关联表格列
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        void BindDataGridColumns();
    }
}
