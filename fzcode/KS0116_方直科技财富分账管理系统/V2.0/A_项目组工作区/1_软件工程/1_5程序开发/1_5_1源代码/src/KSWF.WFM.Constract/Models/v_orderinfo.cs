﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSWF.WFM.Constract.Models
{
    public class v_orderinfo
    {
      
        public Guid? o_guid { get; set; }

        public string o_pno { get; set; }

        /// <summary>
        /// 来源订单商品名称
        /// </summary>
        public string p_name { get; set; }

        /// <summary>
        /// 来源订单商品的科目ID
        /// </summary>
        public int? p_subjectid { get; set; }

        /// <summary>
        /// 来源订单商品的科目
        /// </summary>
        public string p_subject { get; set; }

        /// <summary>
        /// 来源订单年级ID
        /// </summary>
        public int? gradeid { get; set; }

        /// <summary>
        /// 来源订单年级名称
        /// </summary>
        public string gradename { get; set; }


        /// <summary>
        /// 产品年级ID
        /// </summary>
        public int? pgradeid { get; set; }

        /// <summary>
        /// 产品年级名称
        /// </summary>
        public string pgradename { get; set; }

        /// <summary>
        /// 来源订单商品的版本ID
        /// </summary>
        public int? p_versionid { get; set; }

        /// <summary>
        /// 来源订单商品的版本
        /// </summary>
        public string p_version { get; set; }

        /// <summary>
        /// 来源订单商品的类别ID
        /// </summary>
        public int? p_categorykey { get; set; }

        /// <summary>
        /// 来源订单商品的类别
        /// </summary>
        public string p_category { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal p_price { get; set; }

        /// <summary>
        /// 来源订单号
        /// </summary>
        public string o_id { get; set; }

        /// <summary>
        /// 来源订单日期
        /// </summary>
        public DateTime? o_datetime { get; set; }

        /// <summary>
        /// 来源订单区域ID
        /// </summary>
        public int? districtid { get; set; }

        /// <summary>
        /// 来源订单区域地址
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 来源订单学校ID
        /// </summary>
        public int? schoolid { get; set; }

        /// <summary>
        /// 来源订单学校名称
        /// </summary>
        public string schoolname { get; set; }



        /// <summary>
        /// 来源订单班级ID
        /// </summary>
        public Guid? classid { get; set; }

        /// <summary>
        /// 来源订单班级名称
        /// </summary>
        public string classname { get; set; }

        /// <summary>
        /// 来源订单老师编号
        /// </summary>
        public int? u_teacherid { get; set; }

        /// <summary>
        /// 来源订单老师姓名
        /// </summary>
        public string u_teachername { get; set; }

        /// <summary>
        /// 来源订单购买用户ID
        /// </summary>
        public int? u_userid { get; set; }

        /// <summary>
        /// 来源订单购买用户手机号
        /// </summary>
        public string u_mobile { get; set; }

        /// <summary>
        /// 来源订单支付金额
        /// </summary>
        public decimal? o_payamount { get; set; }

        /// <summary>
        /// 来源订单支付类型
        ///0 微信
        ///1 支付宝
        ///2 苹果
        /// </summary>
        public int? o_feetype { get; set; }

        /// <summary>
        /// 来源订单第三方支付扣款金额
        /// </summary>
        public decimal? o_feeamount { get; set; }

        /// <summary>
        /// 实际到账金额
        /// </summary>
        public decimal? o_actamount { get; set; }

        /// <summary>
        /// 来源订单渠道（产品名称）

        /// </summary>
        public int? channel { get; set; }

        /// <summary>
        /// 订单所属用户类型   直销/代理商
        /// </summary>
        public string m_mastertype { get; set; }

        /// <summary>
        /// 订单所属用户
        /// </summary>
        public string m_mastername { get; set; }

        /// <summary>
        /// 订单所属用户真实姓名/代理商名称
        /// </summary>
        public string m_a_name { get; set; }

        /// <summary>
        /// 订单所属用户部门ID
        /// </summary>
        public int? m_deptid { get; set; }

        /// <summary>
        /// 订单所属用户部门名称
        /// </summary>
        public string m_deptname { get; set; }

        /// <summary>
        /// 公司标识
        /// </summary>
        public string agentid { get; set; }

        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal o_bonus { get; set; }
    }
}
