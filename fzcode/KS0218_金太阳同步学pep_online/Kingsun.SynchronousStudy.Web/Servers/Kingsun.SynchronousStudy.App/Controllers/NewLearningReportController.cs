﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Kingsun.SynchronousStudy.App.Common;
using Kingsun.SynchronousStudy.BLL;
using Kingsun.SynchronousStudy.Common;
using Kingsun.SynchronousStudy.Models;
using Kingsun.IBS.BLL;
using Kingsun.IBS.IBLL;

namespace Kingsun.SynchronousStudy.App.Controllers
{
    /// <summary>
    /// 新学习报告接口(2017-04-11,袁富林)
    /// </summary>
    public class NewLearningReportController : ApiController
    {
        private NewLearningReportBLL nlr = new NewLearningReportBLL();


        IIBSData_AreaSchRelationBLL areaBLL = new IBSData_AreaSchRelationBLL();
        IIBSData_UserInfoBLL userBLL = new IBSData_UserInfoBLL();
        IIBSData_ClassUserRelationBLL classBLL = new IBSData_ClassUserRelationBLL();
        IIBSData_SchClassRelationBLL schBLL = new IBSData_SchClassRelationBLL();
        /// <summary>
        /// 根据老师ID查询所属班级信息(2017-04-11,袁富林)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetClassInfoByTeacherId([FromBody] KingRequest request)
        {
            ClassInfoByTeaId submitData = JsonHelper.DecodeJson<ClassInfoByTeaId>(request.Data);
            if (submitData == null)
            {
                return ObjectToJson.GetErrorResult("参数为空！");
            }
            if (string.IsNullOrEmpty(submitData.UserId))
            {
                return ObjectToJson.GetErrorResult("用户ID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.Version))
            {
                return ObjectToJson.GetErrorResult("版本参数不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.AppID))
            {
                return ObjectToJson.GetErrorResult("版本参数不能为空！");
            }
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    var user = userBLL.GetUserInfoByUserId(Convert.ToInt32(submitData.UserId));
                    if (user != null) 
                    {
                        string classid = "";
                        List<ClassInfoList> classList = new List<ClassInfoList>();
                        if (user.ClassSchList != null && user.ClassSchList.Count > 0)
                        {
                            user.ClassSchList.ForEach(a =>
                            {
                                var classinfo = classBLL.GetClassUserRelationByClassId(a.ClassID);

                                if (!string.IsNullOrEmpty(classinfo.ClassNum))
                                {
                                    if (
                                        classList.FirstOrDefault(
                                            x => x.Id == classinfo.ClassNum.ToString()) == null)
                                    {

                                        classid += classinfo.ClassNum + ",";
                                        classList.Add(new ClassInfoList
                                        {

                                            Id = classinfo.ClassNum.ToString(),
                                            ClassName = classinfo.ClassName

                                        });
                                    }
                                }


                            });
                            htm = nlr.GetClassInfoByTeacherId(submitData.AppID, classid, classList);
                        }
                        else
                        {
                            return JsonHelper.GetErrorResult("班级不存在");
                        }
                    }
                    else
                    {
                        return JsonHelper.GetErrorResult("用户不存在");
                    }
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;

            }
            return htm;
        }


        /// <summary>
        /// 根据老师ID查询所属班级(2017-04-11,袁富林)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetClassInfoByTeacherIdTest()
        {
           var list= userBLL.GetVailUserInfoList(0,20);
            ClassInfoByTeaId submitData = new ClassInfoByTeaId();//JsonHelper.DecodeJson<ClassInfoByTeaId>(request.Data);
            //if (submitData == null)
            //{
            //    return ObjectToJson.GetErrorResult("参数为空！");
            //}
            //if (string.IsNullOrEmpty(submitData.UserId))
            //{
            //    return ObjectToJson.GetErrorResult("用户ID不能为空！");
            //}
            //if (string.IsNullOrEmpty(submitData.Version))
            //{
            //    return ObjectToJson.GetErrorResult("版本参数不能为空！");
            //}
            submitData.Version = "V1";
            submitData.UserId = "591084426";
            submitData.AppID = "241ea176-fce7-4bd7-a65f-a7978aac1cd2";
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                  var user = userBLL.GetUserAllInfoByUserId(Convert.ToInt32(submitData.UserId));
                    if (user != null) 
                    {

                        string classid = "'";
                        List<ClassInfoList> classList = new List<ClassInfoList>();
                        if (user.ClassSchDetailList != null && user.ClassSchDetailList.Count > 0) 
                        {
                            user.ClassSchDetailList.ForEach(a =>
                            {
                                var classinfo = classBLL.GetClassUserRelationALLInfoByClassId(a.ClassID);
                                classid += classinfo.iBS_ClassUserRelation.ClassNum + "','";
                                classList.Add(new ClassInfoList 
                                {
                                    Id=classinfo.iBS_ClassUserRelation.ClassNum.ToString(),
                                    ClassName=classinfo.iBS_ClassUserRelation.ClassName
                                    
                                });
                            });
                            classid += "'";
                            htm = nlr.GetClassInfoByTeacherId(submitData.AppID, classid, classList);
                        }
                    }
                    else
                    {
                        return JsonHelper.GetErrorResult("班级不存在");
                    }
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;

            }
            return htm;
        }

        /// <summary>
        /// 根据班级Id查询年级学习人数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetJuniorGradeNumByClassId([FromBody] KingRequest request)
        {
            JuniorGradeInfoByClassId submitData = JsonHelper.DecodeJson<JuniorGradeInfoByClassId>(request.Data);
            if (submitData == null)
            {
                return ObjectToJson.GetErrorResult("参数为空！");
            }
            if (string.IsNullOrEmpty(submitData.AppId))
            {
                return ObjectToJson.GetErrorResult("AppID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.ClassId))
            {
                return ObjectToJson.GetErrorResult("班级ID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.Version))
            {
                return ObjectToJson.GetErrorResult("版本参数不能为空！");
            }
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetJuniorGradeNumByClassId(submitData.AppId, submitData.ClassId);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }

        /// <summary>
        /// 根据班级Id查询年级学习人数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetJuniorGradeNumByClassIdTest()
        {
            JuniorGradeInfoByClassId submitData = new JuniorGradeInfoByClassId(); //JsonHelper.DecodeJson<JuniorGradeInfoByClassId>(request.Data);
            submitData.AppId = "241ea176-fce7-4bd7-a65f-a7978aac1cd2";
            submitData.ClassId = "69504640";
            submitData.Version = "V1";
            if (submitData == null)
            {
                return ObjectToJson.GetErrorResult("参数为空！");
            }
            if (string.IsNullOrEmpty(submitData.AppId))
            {
                return ObjectToJson.GetErrorResult("AppID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.ClassId))
            {
                return ObjectToJson.GetErrorResult("班级ID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.Version))
            {
                return ObjectToJson.GetErrorResult("版本参数不能为空！");
            }
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetJuniorGradeNumByClassId(submitData.AppId, submitData.ClassId);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }

        /// <summary>
        /// 根据书籍Id和班级Id查询单元学习人数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUnitLearningByBookId([FromBody] KingRequest request)
        {
            UnitLearningListByBookId submitData = JsonHelper.DecodeJson<UnitLearningListByBookId>(request.Data);
            if (submitData == null)
            {
                return ObjectToJson.GetErrorResult("参数为空！");
            }
            if (string.IsNullOrEmpty(submitData.BookId) || submitData.BookId == "0")
            {
                return ObjectToJson.GetErrorResult("BookID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.ClassId))
            {
                return ObjectToJson.GetErrorResult("班级ID不能为空！");
            }
            if (submitData.PageNumber < 0)
            {
                return ObjectToJson.GetErrorResult("分页参数不能为0！");
            }
            if (string.IsNullOrEmpty(submitData.Version))
            {
                return ObjectToJson.GetErrorResult("版本参数不能为空！");
            }
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetUnitLearningByBookId(submitData.BookId, submitData.ClassId, submitData.PageNumber);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }

        /// <summary>
        /// 根据书籍Id和班级Id查询单元学习人数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUnitLearningByBookIdTest()
        {
            UnitLearningListByBookId submitData = new UnitLearningListByBookId();//JsonHelper.DecodeJson<UnitLearningListByBookId>(request.Data);
            //if (submitData == null)
            //{
            //    return ObjectToJson.GetErrorResult("参数为空！");
            //}
            //if (string.IsNullOrEmpty(submitData.BookId))
            //{
            //    return ObjectToJson.GetErrorResult("AppID不能为空！");
            //}
            //if (string.IsNullOrEmpty(submitData.ClassId))
            //{
            //    return ObjectToJson.GetErrorResult("班级ID不能为空！");
            //}
            //if (string.IsNullOrEmpty(submitData.Version))
            //{
            //    return ObjectToJson.GetErrorResult("版本参数不能为空！");
            //}
            submitData.BookId = "176";
            submitData.ClassId = "42890438";
            submitData.Version = "V1";
            submitData.PageNumber = 0;
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetUnitLearningByBookId(submitData.BookId, submitData.ClassId, submitData.PageNumber);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }

        /// <summary>
        /// 根据班级Id、册别、目录统计趣配音学习情况
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetVideoDetailsByModuleId([FromBody] KingRequest request)
        {
            VideoDetailsByModuleId submitData = JsonHelper.DecodeJson<VideoDetailsByModuleId>(request.Data);
            if (submitData == null)
            {
                return ObjectToJson.GetErrorResult("参数为空！");
            }
            if (string.IsNullOrEmpty(submitData.BookId) || submitData.BookId == "0")
            {
                return ObjectToJson.GetErrorResult("书籍ID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.ClassId))
            {
                return ObjectToJson.GetErrorResult("班级ID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.FirstTitleID))
            {
                return ObjectToJson.GetErrorResult("单元ID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.SecondTitleID))
            {
                return ObjectToJson.GetErrorResult("模块ID不能为空！");
            }
            if (submitData.PageNumber < 0)
            {
                return ObjectToJson.GetErrorResult("分页参数不能为0！");
            }
            if (string.IsNullOrEmpty(submitData.Version))
            {
                return ObjectToJson.GetErrorResult("版本参数不能为空！");
            }
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetVideoDetailsByModuleId(submitData.BookId, submitData.ClassId, submitData.FirstTitleID, submitData.SecondTitleID);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }

        /// <summary>
        /// 根据班级Id、册别、目录统计趣配音学习情况
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetVideoDetailsByModuleIdTest()
        {
            VideoDetailsByModuleId submitData = new VideoDetailsByModuleId();//JsonHelper.DecodeJson<VideoDetailsByModuleId>(request.Data);

            submitData.BookId = "168";
            submitData.ClassId = "42890438";
            submitData.Version = "V1";
            submitData.FirstTitleID = "276194";
            submitData.SecondTitleID = "276195";
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetVideoDetailsByModuleId(submitData.BookId, submitData.ClassId, submitData.FirstTitleID, submitData.SecondTitleID);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }

        /// <summary>
        /// 根据书籍ID,班级ID获取班级详细学习情况
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetClassStudyDetailsByClassId([FromBody] KingRequest request)
        {
            UnitLearningListByBookId submitData = JsonHelper.DecodeJson<UnitLearningListByBookId>(request.Data);
            if (submitData == null)
            {
                return ObjectToJson.GetErrorResult("参数为空！");
            }
            if (string.IsNullOrEmpty(submitData.BookId) || submitData.BookId == "0")
            {
                return ObjectToJson.GetErrorResult("书籍ID不能为空！");
            }
            if (string.IsNullOrEmpty(submitData.ClassId))
            {
                return ObjectToJson.GetErrorResult("班级ID不能为空！");
            }
            if (submitData.VideoNumber <= 0)
            {
                return ObjectToJson.GetErrorResult("视频序号不能为0！");
            }
            if (submitData.PageNumber < 0)
            {
                return ObjectToJson.GetErrorResult("分页参数不能为0！");
            }
            if (string.IsNullOrEmpty(submitData.Version))
            {
                return ObjectToJson.GetErrorResult("版本参数不能为空！");
            }
            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetClassStudyDetailsByClassId(submitData.ClassId, submitData.BookId, submitData.VideoNumber, submitData.PageNumber);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }

        /// <summary>
        /// 根据书籍ID,班级ID获取班级详细学习情况
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetClassStudyDetailsByClassIdTest(string BookId, string Version, int VideoNumber, int pageNumber, string ClassID)
        {
            UnitLearningListByBookId submitData = new UnitLearningListByBookId();//JsonHelper.DecodeJson<UnitLearningListByBookId>(request.Data);


            submitData.BookId = BookId;
            submitData.ClassId = ClassID;
            submitData.PageNumber = pageNumber;
            submitData.VideoNumber = VideoNumber;
            submitData.Version = "V1";

            HttpResponseMessage htm = new HttpResponseMessage();
            switch (submitData.Version)
            {
                case "V1":
                    htm = nlr.GetClassStudyDetailsByClassId(submitData.ClassId, submitData.BookId, submitData.VideoNumber, submitData.PageNumber);
                    break;
                case "V2":
                    break;
                case "V3":
                    break;
                case "V4":
                    break;
                default:
                    htm = ObjectToJson.GetErrorResult("版本不存在！");
                    break;
            }
            return htm;
        }
    }
}