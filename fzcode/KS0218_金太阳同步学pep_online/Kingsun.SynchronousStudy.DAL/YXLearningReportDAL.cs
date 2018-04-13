﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Kingsun.IBS.Model;
using Kingsun.IBS.Model.IBSLearnReport;
using Kingsun.SynchronousStudy.Common;
using Kingsun.SynchronousStudy.Common.Base;
using Kingsun.SynchronousStudy.Models;
using ServiceStack.Text;

namespace Kingsun.SynchronousStudy.DAL
{
    public class YXLearningReportDAL
    {
        static RedisHashHelper hashRedis = new RedisHashHelper();
        readonly BaseManagement _bm = new BaseManagement();
        readonly string _getOssFilesUrl = WebConfigurationManager.AppSettings["getOssFiles"];
        readonly string _getFilesUrl = WebConfigurationManager.AppSettings["getFiles"];
        private int ModelType = 4;//redis数据类型(1:趣配音,2:单元测试，3：说说看，4:优学趣配音，5：暂时保留，6：优学说说看)
        private int Subject = 3;//学科（3：英语）

        /// <summary>
        /// 根据老师ID查询班级信息
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetClassInfoByTeacherId(List<ClassInfoList> classList)
        {
            List<ClassInfoList> returnCinfoList = ClassOrder(classList);//排序后的班级新

            object obj = new { ClassList = returnCinfoList.OrderByDescending(i => i.ClassName) };//返回信息
            return JsonHelper.GetResult(obj, "操作成功");

        }

        /// <summary>
        /// 班级排序
        /// </summary>
        /// <param name="list"></param>
        private List<ClassInfoList> ClassOrder(List<ClassInfoList> list)
        {
            List<ClassInfoList> classList = list;
            List<ClassInfoList> returnList = new List<ClassInfoList>();
            if (classList != null && classList.Count > 0)
            {
                string[] gradeArr = { "一年级", "二年级", "三年级", "四年级", "五年级", "六年级" };
                for (int i = 0, length = gradeArr.Length; i < length; i++)
                {
                    returnList.AddRange(classList.Where(t => t.ClassName.IndexOf(gradeArr[i], StringComparison.Ordinal) > -1));
                }
            }
            return returnList;
        }

        /// <summary>
        /// 根据班级Id查询年级学习人数
        /// </summary>
        /// <param name="appId">版本ID</param>
        /// <param name="classId">班级ID</param>
        /// <returns></returns>
        public HttpResponseMessage GetJuniorGradeNumByClassId(string appId, string classId)
        {
            string sql = string.Format(@" SELECT  a.BookID ,
                                                    a.JuniorGrade ,
                                                    a.TeachingBooks
                                            FROM    dbo.TB_CurriculumManage a
                                                    LEFT JOIN TB_APPManagement b ON a.EditionID = b.VersionID
                                            WHERE   b.ID = '{0}'
                                            GROUP BY a.BookID ,
                                                    a.JuniorGrade ,
                                                    a.TeachingBooks", appId);

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
            List<JuniorGradeInfoList> listobj = new List<JuniorGradeInfoList>();

            using (var Redis = RedisManager.GetClient(0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    JuniorGradeInfoList obj = new JuniorGradeInfoList();
                    try
                    {
                        string value = Redis.GetValueFromHash("Rds_StudyReport_Book", classId + "_" + Subject + "_" + ModelType + "_" + ds.Tables[0].Rows[i]["BookID"]);
                        if (!string.IsNullOrEmpty(value))
                        {
                            int bookId = Convert.ToInt32(ds.Tables[0].Rows[i]["BookID"]);
                            string bookName = ds.Tables[0].Rows[i]["JuniorGrade"] + ds.Tables[0].Rows[i]["TeachingBooks"].ToString();
                            obj = new JuniorGradeInfoList { BookId = bookId, BookName = bookName, IsStudy = true };
                        }
                        else
                        {
                            int bookId = Convert.ToInt32(ds.Tables[0].Rows[i]["BookID"]);
                            string bookName = ds.Tables[0].Rows[i]["JuniorGrade"] + ds.Tables[0].Rows[i]["TeachingBooks"].ToString();
                            obj = new JuniorGradeInfoList { BookId = bookId, BookName = bookName, IsStudy = false };
                        }
                        Rds_StudyReport_Book study = JsonHelper.DecodeJson<Rds_StudyReport_Book>(value);
                        if (study != null)
                        {
                            study.Flag = 1;
                            try
                            {
                                string ve = JsonSerializer.SerializeToString<Rds_StudyReport_Book>(study);
                                Redis.SetEntryInHash("Rds_StudyReport_Book", classId + "_" + Subject + "_" + ModelType + "_" + ds.Tables[0].Rows[i]["BookID"], ve);
                            }
                            catch (Exception ex)
                            {
                                Log4Net.LogHelper.Error(ex, "错误：HashID为：Rds_StudyReport_Book|pairs为：" + classId + "_" + Subject + "_" + ModelType + "_" + ds.Tables[0].Rows[i]["BookID"]);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Log4Net.LogHelper.Error(ex, "错误：HashID为：Rds_StudyReport_Class|Key为：" + classId + "_" + Subject + "_" + ModelType + "_" + ds.Tables[0].Rows[i]["BookID"]);
                    }

                    listobj.Add(obj);
                }
            }

            if (listobj.Count > 0)
            {
                return JsonHelper.GetResult(CurriculumOrder(listobj), "操作成功");
            }
            else
            {
                return JsonHelper.GetErrorResult("数据不存在！");
            }
        }


        /// <summary>
        /// 年级排序
        /// </summary>
        /// <param name="list"></param>
        private List<JuniorGradeInfoList> CurriculumOrder(List<JuniorGradeInfoList> list)
        {
            List<JuniorGradeInfoList> returnList = new List<JuniorGradeInfoList>();
            if (list != null && list.Count > 0)
            {
                string[] gradeArr = { "一年级", "二年级", "三年级", "四年级", "五年级", "六年级" };
                for (int i = 0, length = gradeArr.Length; i < length; i++)
                {
                    returnList.AddRange(list.Where(t => t.BookName.IndexOf(gradeArr[i], StringComparison.Ordinal) > -1));
                }
            }
            return returnList;
        }

        /// <summary>
        /// 根据书籍Id和班级Id查询单元学习人数
        /// </summary>
        /// <param name="bookId">书籍ID</param>
        /// <param name="classId">班级ID</param>
        /// <param name="pageNumber">分页页码</param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetUnitLearningByBookId(string bookId, string classId, int pageNumber, List<UserClass> userClass)
        {
            string sql = string.Format(@"SELECT  BookID ,
                                        FirstTitleID ,
                                        FirstTitle ,
                                        SecondTitleID ,
                                        SecondTitle
                                FROM    FZ_InterestDubbing.dbo.TB_VideoDetails_YX
                                WHERE   BookID IS NOT NULL
                                        AND BookID <> 0
                                        AND BookID = '{0}'
                                GROUP BY BookID ,
                                        FirstTitleID ,
                                        FirstTitle ,
                                        SecondTitleID ,
                                        SecondTitle", bookId);
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
            if (ds == null)
            {
                return JsonHelper.GetErrorResult("无目录数据！");
            }
            List<VideoDetail> vdl = JsonHelper.DataSetToIList<VideoDetail>(ds, 0);

            List<UnitLearningInfoList> unit = new List<UnitLearningInfoList>();
            UnitLearningInfoList ull;

            using (var Redis = RedisManager.GetClient(0))
            {
                foreach (var item in vdl)
                {
                    ull = new UnitLearningInfoList();
                    string modName = "";
                    string uniName = "";
                    string muName = "";
                    modName = item.FirstTitle.Trim().Length >= 9
                        ? item.FirstTitle.Substring(0, 9).Trim() + "..."
                        : item.FirstTitle.Trim();
                    if (item.SecondTitle != null)
                    {
                        uniName = item.SecondTitle.Trim().Length >= 9
                        ? item.SecondTitle.Substring(0, 9).Trim() + "..."
                        : item.SecondTitle.Trim();
                    }
                    if (modName != "" && uniName != "")
                    {
                        muName = modName + "/" + uniName;
                    }
                    if (modName != "" && uniName == "")
                    {
                        muName = modName;
                    }
                    string Mkey = "";
                    if (item.SecondTitleID > 0)
                    {
                        Mkey = classId + "_" + Subject + "_" + ModelType + "_" + bookId + "_" + item.FirstTitleID + item.SecondTitleID;
                    }
                    else
                    {
                        Mkey = classId + "_" + Subject + "_" + ModelType + "_" + bookId + "_" + item.FirstTitleID;
                    }
                    string value = Redis.GetValueFromHash("Rds_StudyReport_Module", Mkey);
                    if (!string.IsNullOrEmpty(value))
                    {
                        ull.FirstTitleID = item.FirstTitleID;
                        ull.SecondTitleID = item.SecondTitleID;
                        ull.Catalague = muName;
                        ull.IsStudy = true;
                        unit.Add(ull);
                    }
                    else
                    {
                        ull.Catalague = muName;
                        ull.FirstTitleID = item.FirstTitleID;
                        ull.SecondTitleID = item.SecondTitleID;
                        ull.IsStudy = false;
                        unit.Add(ull);
                    }
                }
            }
            if (unit.Count <= 0)
            {
                return JsonHelper.GetErrorResult("暂无数据！" + vdl.Count);
            }
            else
            {
                unit = unit.OrderBy(i => i.FirstTitleID).ThenBy(i => i.SecondTitleID).Skip(pageNumber * 10).Take(10).ToList();
                return JsonHelper.GetResult(unit, "操作成功");
            }
        }

        /// <summary>
        /// 根据班级Id、册别、目录统计趣配音学习情况
        /// </summary>
        /// <param name="bookId">书籍id</param>
        /// <param name="classId">班级ID</param>
        /// <param name="firstTitleId">单元ID</param>
        /// <param name="secondTitleId">模块ID</param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetVideoDetailsByModuleId(string bookId, string classId, string firstTitleId, string secondTitleId, IBS_ClassUserRelation userClassList)
        {
            string where = "";
            if (secondTitleId != "0" || string.IsNullOrEmpty(secondTitleId))
            {
                where = string.Format(" AND FirstTitleID = '{0}'  AND SecondTitleID = '{1}' ", firstTitleId, secondTitleId);
            }
            else
            {
                where = string.Format(" AND FirstTitleID = '{0}' ", firstTitleId);
            }

            string sql = string.Format(@"SELECT  BookID ,
                                                FirstTitleID ,
                                                FirstTitle ,
                                                SecondTitleID ,
                                                SecondTitle ,
                                                FirstModularID ,
                                                FirstModular ,
                                                VideoNumber ,
                                                VideoTitle
                                        FROM    [FZ_InterestDubbing].dbo.TB_VideoDetails_YX
                                        WHERE   BookID = '{0}'  {1}", bookId, where);
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
            List<VideoDetail> vdl = JsonHelper.DataSetToIList<VideoDetail>(ds, 0);


            List<VideoDetailsList> videoList = new List<VideoDetailsList>();

            using (var Redis = RedisManager.GetClient(0))
            {
                foreach (var item in vdl)
                {
                    int cl = 0;
                    try
                    {
                        foreach (var stu in userClassList.ClassStuList)
                        {
                            string value = Redis.GetValueFromHash("Rds_StudyReport_ModuleTitle_" + stu.StuID.ToString().Substring(0, 2), stu.StuID + "_" + Subject + "_" + ModelType);
                            if (!string.IsNullOrEmpty(value))
                            {
                                Rds_StudyReport_ModuleTitle study = JsonHelper.DecodeJson<Rds_StudyReport_ModuleTitle>(value);
                                foreach (var userinfo in study.detail)
                                {
                                    if (userinfo.BookID == bookId.ToInt() && userinfo.VideoNumber == item.VideoNumber)
                                    {
                                        cl++;
                                    }
                                }
                            }
                        }

                        VideoDetailsList vlist = new VideoDetailsList()
                        {
                            ClassStudentCount = userClassList.ClassStuList.Count,
                            StudentStudyCount = cl,
                            ModuleId = Convert.ToInt32(item.FirstModularID),
                            ModuleName = item.FirstModular,
                            BookID = bookId.ToInt(),
                            VideoNumber = Convert.ToInt32(item.VideoNumber),
                            VideoTitle = item.VideoTitle
                        };
                        videoList.Add(vlist);

                    }
                    catch (Exception ex)
                    {
                        Log4Net.LogHelper.Error(ex, "错误：HashID为：Rds_StudyReport_ModuleTitle|Key为：" + classId + "_" + Subject + "_" + ModelType + "_" + bookId + "_" + item.VideoNumber);
                    }
                }
            }

            return JsonHelper.GetResult(videoList.OrderBy(i => i.VideoNumber), "操作成功");
        }

        /// <summary>
        /// 根据书籍ID,班级ID获取班级详细学习情况
        /// </summary>
        /// <param name="classId">班级ID</param>
        /// <param name="bookId">书籍ID</param>
        /// <param name="videoNumber">视频序号</param>
        /// <param name="pageNumber">分页代码</param>
        /// <returns></returns>
        public HttpResponseMessage GetClassStudyDetailsByClassId(string classId, string bookId, int videoNumber, int pageNumber, IBS_ClassUserRelation userClass)
        {
            double count = 0;
            double maxScore = 0;
            int sort = 1;
            double minScore = 100;
            int cl = 0;
            string ImgUrl = "";
            UserVideosInfo uvi;
            List<UserVideosInfo> uservideoinfo = new List<UserVideosInfo>();
            if (userClass != null)
            {
                foreach (var item in userClass.ClassStuList)
                {
                    Rds_StudyReport_ModuleTitle module = hashRedis.Get<Rds_StudyReport_ModuleTitle>("Rds_StudyReport_ModuleTitle_" + item.StuID.ToString().Substring(0, 2), item.StuID + "_" + Subject + "_" + ModelType);
                    uvi = new UserVideosInfo();
                    if (module != null)
                    {
                        Rds_StudyReport_BookDetail rdsBookDetail = module.detail.FirstOrDefault(i => i.BookID == bookId.ToInt() && i.VideoNumber == videoNumber);
                        if (rdsBookDetail != null)
                        {
                            Rds_StudyReport_BookCatalogues_BookID BookCatalogues = hashRedis.Get<Rds_StudyReport_BookCatalogues_BookID>("Rds_StudyReport_BookCatalogues_" + bookId, rdsBookDetail.FirstTitleID + "_" + rdsBookDetail.SecondTitleID + "_" + ModelType);
                            if (BookCatalogues != null)
                            {
                                foreach (var vi in BookCatalogues.Videos)
                                {
                                    if (vi.VideoNumber == videoNumber)
                                    {
                                        ImgUrl = vi.IsEnableOss != 0
                                            ? _getOssFilesUrl + vi.VideoImageAddress
                                            : _getFilesUrl + "?FileID=" + vi.VideoImageAddress;
                                    }
                                }
                            }

                            rdsBookDetail.BestScore = rdsBookDetail.BestScore.CutDoubleWithN(1);
                            cl++;
                            if (Convert.ToDouble(rdsBookDetail.BestScore) > maxScore)
                            {
                                maxScore = rdsBookDetail.BestScore.CutDoubleWithN(1);
                            }
                            if (Convert.ToDouble(rdsBookDetail.BestScore) <= minScore)
                            {
                                minScore = rdsBookDetail.BestScore.CutDoubleWithN(1);
                            }
                            count += rdsBookDetail.BestScore.CutDoubleWithN(1);

                            if (!string.IsNullOrEmpty(item.StuName))
                            {
                                uvi.UserName = item.StuName;
                            }
                            else
                            {
                                uvi.UserName = "暂未填写";
                            }

                            string imgUrl = item.IsEnableOss != 0 ? _getOssFilesUrl + item.UserImage : _getFilesUrl + "?FileID=" + item.UserImage;
                            uvi.UserId = (int)item.StuID;//返回UserId
                            if (item.UserImage != null) uvi.UserImg = imgUrl;

                            uvi.DubTimes = rdsBookDetail.DubbingNum;
                            uvi.VedioId = Convert.ToInt32(rdsBookDetail.VideoID);
                            uvi.IsStudy = true;
                            uvi.CreateTime = rdsBookDetail.CreateTime;
                            uvi.Score = rdsBookDetail.BestScore.ToString("0.0");
                        }
                        else
                        {
                            uvi.UserId = Convert.ToInt32(item.StuID);
                            uvi.UserImg = item.IsEnableOss != 0
                                            ? _getOssFilesUrl + item.UserImage
                                            : _getFilesUrl + "?FileID=" + item.UserImage;
                            uvi.UserName = item.StuName;
                            uvi.Score = "0.0";
                            uvi.IsStudy = false;
                        }
                    }
                    else
                    {
                        uvi.UserId = Convert.ToInt32(item.StuID);
                        uvi.UserImg = item.IsEnableOss != 0
                                          ? _getOssFilesUrl + item.UserImage
                                          : _getFilesUrl + "?FileID=" + item.UserImage;
                        uvi.UserName = item.StuName;
                        uvi.Score = "0.0";
                        uvi.IsStudy = false;
                    }
                    uservideoinfo.Add(uvi);
                }
            }
            if (cl == 0)
            {
                minScore = 0;
            }
            //以时间为单位，降序排列
            uservideoinfo = uservideoinfo.OrderByDescending(i => i.IsStudy).ThenByDescending(i => Convert.ToDouble(i.Score)).Skip(pageNumber * 10).Take(10).ToList();
            object obj =
                new
                {
                    AverageScore = count <= 0 ? "0" : (count / cl).ToString("0.0"),
                    HighestScore = maxScore,
                    LowestScore = minScore,
                    ImgUrl = ImgUrl,
                    Students = uservideoinfo
                };
            return JsonHelper.GetResult(obj, "操作成功");//返回信息 

        }
    }
}
