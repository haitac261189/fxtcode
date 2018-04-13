﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInformation.aspx.cs" Inherits="Kingsun.SynchronousStudy.Web.StudyReportManagement.AddInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <title>完善资料</title>
    <link href="../AppTheme/css/hear.css" rel="stylesheet" />
    <link href="../AppTheme/css/LArea.min.css" rel="stylesheet" />
    <style type="text/css">
        .on {
            background: #1C9EEA;
            color: #fff;
            border: 1px solid #1C9EEA;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="head_back">
                <a class="h_left" href="javascript:history.go(-1)"></a>
                <a class="h_close" id="close">[关闭]</a>
                <h2>完善资料</h2>
            </div>
            <div class="Html2">
                <ul>
                    <li><span>姓名</span><input id="name" type="text" placeholder="输入真实姓名，例如：张三3" /></li>
                    <li><span>学段</span><b id="stage" class="on">小学</b></li>
                    <li><span>学科</span><b id="subject" class="on">英语</b></li>
                    <li><span>学校</span>

                        <div class="content-block content-block2" id="div_province">
                            <input id="province" type="text" readonly="" placeholder="--选择省份--" />
                            <input id="provinceID" type="hidden" />
                            <a href="#"></a>
                        </div>
                    </li>
                    <li>
                        <div class="content-block content-block1" id="div_city">
                            <input id="city" type="text" readonly="true" placeholder="--选择地市--" />
                            <input id="cityID" type="hidden" />
                            <a href="#"></a>
                        </div>

                    </li>
                    <li>
                        <div class="content-block content-block1" id="div_district">
                            <input id="district" type="text" readonly="true" placeholder="--选择区县--" />
                            <input id="districtID" type="hidden" />
                            <a href="#"></a>
                        </div>
                    </li>
                    <li>
                        <div class="content-block content-block1" id="div_school">
                            <input id="school" type="text" readonly="true" placeholder="--选择学校--" />
                            <input id="schoolID" type="hidden" />
                            <a href="#"></a>
                        </div>

                    </li>
                 
                </ul>
                <a class="next" id="next">下一步</a>
            </div>
        </div>
    </form>

    <script src="../AppTheme/js/jquery-1.11.2.min.js"></script>
    <%--<script src="../AppTheme/js/artDialog/artDialogAll.js?skin=aero"></script>--%>
    <script src="../AppTheme/js/jquery.json-2.4.js"></script>
    <script src="../AppTheme/js/jquery.cookie.js"></script>
    <script src="../AppTheme/js/CommonDB.js"></script>
    <script src="../Scripts/MobileTerminal/JsBridge.js"></script>
    <script src="../Scripts/MobileTerminal/mobile.js"></script>
    <script src="../Scripts/MobileTerminal/demo.js"></script>
    <script src="../Scripts/MobileTerminal/LArea.js"></script>
    <script src="../Scripts/MobileTerminal/AddInformationInit.js"></script>
</body>
</html>
