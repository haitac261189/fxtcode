﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAS.DataAccess.DA;
using CAS.Common;
using System.Data.SqlClient;
using System.Data;
using CAS.DataAccess.BaseDAModels;
using CAS.Entity;
using CAS.Entity.DBEntity;

namespace FxtCenterService.DataAccess
{
    public class SYSAreaDA : Base
    {
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <param name="search"></param>
        /// <param name="areaid">指定区域ID集合</param>
        /// <returns></returns>
        public static List<SYSArea> GetSYSAreaList(SearchBase search, string areaid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = SQL.CityArea.AreaList;
            if (search.CityId > 0)
            {
                sql += " and cityid=" + search.CityId;
            }
            if (!string.IsNullOrEmpty(areaid))
            {
                sql += " and areaid in(" + areaid + ")";
            }
            sql = HandleSQL(search, sql);
            return ExecuteToEntityList<SYSArea>(sql, System.Data.CommandType.Text, parameters);
        }

    }
}