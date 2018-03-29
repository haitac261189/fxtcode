﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAS.Entity.DBEntity;

namespace CAS.Entity
{
    /// <summary>
    /// 外部api返回json实体
    /// </summary>
    public class OutJsonEntity
    {
        /// <summary>
        /// 返回ID
        /// 云查勘3.0 向第三方发起查勘，返回第三方查勘id
        /// </summary>
        public long objectid { get; set; }
    }

    /// <summary>
    /// 自动估价结果
    /// </summary>
    public class AutoPrice
    {
        /// <summary>
        /// 单价
        /// </summary>
        public decimal unitprice { get; set; }
        /// <summary>
        /// 项目均价(楼盘均价)
        /// </summary>
        public decimal eprice { get; set; }
        /// <summary>
        /// 楼栋均价
        /// </summary>
        public decimal beprice { get; set; }
        /// <summary>
        /// 房号估价
        /// </summary>
        public decimal heprice { get; set; }
        public decimal avgprice { get; set; }
        /// <summary>
        /// 案例数
        /// </summary>
        public int casecount { get; set; }
        /// <summary>
        /// 案例最大值
        /// </summary>
        public int casemax { get; set; }
        /// <summary>
        /// 案例最小值
        /// </summary>
        public int casemin { get; set; }

        /// <summary>
        /// 价格计算类型（银行使用）
        /// </summary>
        public int pricetype { get; set; }

        /// <summary>
        /// 楼盘细分类型均价(需要存储在银行数据库，确保每次显示一致）
        /// </summary>
        public List<DATProjectAvgPrice> avgpricelist { get; set; }
    }

}