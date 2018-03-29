﻿using System;
using CAS.Entity.BaseDAModels;

namespace CAS.Entity.DBEntity
{
    [Serializable]
    [TableAttribute("dbo.Dat_ChargeInOutRecord")]
    public class DatChargeInOutRecord : BaseTO
    {
        private int _chargeinoutrecordid;
        [SQLField("chargeinoutrecordid", EnumDBFieldUsage.PrimaryKey, true)]
        public int chargeinoutrecordid
        {
            get { return _chargeinoutrecordid; }
            set { _chargeinoutrecordid = value; }
        }
        private long _entrustid;
        /// <summary>
        /// 业务Id
        /// </summary>
        public long entrustid
        {
            get { return _entrustid; }
            set { _entrustid = value; }
        }
        private int _inouttype;
        /// <summary>
        /// 收支类型，1:收入，2:支出
        /// </summary>
        public int inouttype
        {
            get { return _inouttype; }
            set { _inouttype = value; }
        }
        private decimal _money;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal money
        {
            get { return _money; }
            set { _money = value; }
        }
        private int _chargetype;
        /// <summary>
        /// 收费方式
        /// </summary>
        public int chargetype
        {
            get { return _chargetype; }
            set { _chargetype = value; }
        }
        private int _recordpersonid;
        /// <summary>
        /// 登记人
        /// </summary>
        public int recordpersonid
        {
            get { return _recordpersonid; }
            set { _recordpersonid = value; }
        }
        private DateTime _chargetime;
        /// <summary>
        /// 收费时间
        /// </summary>
        public DateTime chargetime
        {
            get { return _chargetime; }
            set { _chargetime = value; }
        }
        private int _handpersonid;
        /// <summary>
        /// 经手人
        /// </summary>
        public int handpersonid
        {
            get { return _handpersonid; }
            set { _handpersonid = value; }
        }
        private bool _isverify;
        /// <summary>
        /// 是否确认
        /// </summary>
        public bool isverify
        {
            get { return _isverify; }
            set { _isverify = value; }
        }
        private int? _verifypersonid;
        /// <summary>
        /// 确认人
        /// </summary>
        public int? verifypersonid
        {
            get { return _verifypersonid; }
            set { _verifypersonid = value; }
        }
        private DateTime? _verifytime;
        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? verifytime
        {
            get { return _verifytime; }
            set { _verifytime = value; }
        }
        private int _valid = 1;
        /// <summary>
        /// 状态
        /// </summary>
        public int valid
        {
            get { return _valid; }
            set { _valid = value; }
        }
        private string _remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private DateTime _createtime = DateTime.Now;
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        private int? _chargemonthlyid;
        /// <summary>
        /// 月结id
        /// </summary>
        public int? chargemonthlyid
        {
            get { return _chargemonthlyid; }
            set { _chargemonthlyid = value; }
        }

        private int? _chargeentrustid;
        /// <summary>
        /// 收费ID，对应表Dat_ChargeEntrust
        /// </summary>
        public int? chargeentrustid
        {
            get { return _chargeentrustid; }
            set { _chargeentrustid = value; }
        }
        private int? _outtype;
        /// <summary>
        /// 支出类型(1:其它，2:返利，3:提成)
        /// </summary>
        public int? outtype
        {
            get { return _outtype; }
            set { _outtype = value; }
        }

        private string _payeruser;
        /// <summary>
        /// 缴费人
        /// </summary>
        public string payeruser
        {
            get { return _payeruser; }
            set { _payeruser = value; }
        }
        private string _accountbank;
        /// <summary>
        /// 收款账户银行
        /// </summary>
        public string accountbank
        {
            get { return _accountbank; }
            set { _accountbank = value; }
        }
        private string _accountname;
        /// <summary>
        /// 收款账号
        /// </summary>
        public string accountname
        {
            get { return _accountname; }
            set { _accountname = value; }
        }
        private string _accounttruename;
        /// <summary>
        /// 开户名
        /// </summary>
        public string accounttruename
        {
            get { return _accounttruename; }
            set { _accounttruename = value; }
        }
        
    }
}