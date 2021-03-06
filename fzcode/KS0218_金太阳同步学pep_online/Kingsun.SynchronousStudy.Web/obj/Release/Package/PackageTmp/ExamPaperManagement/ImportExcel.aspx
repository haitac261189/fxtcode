﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportExcel.aspx.cs" Inherits="Kingsun.SynchronousStudy.Web.ExamPaperManagement.ImportExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../AppTheme/themes/default/easyui.css" rel="stylesheet" />
    <title>导入资源</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbCatalogName" runat="server" Text="Label"></asp:Label><br />
        <span style="color: red">(*选择哪个模块的excel就点击对应的导入按钮)</span>
        <br />
        请选择excel文件：<asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnImport" runat="server" Text="导入目录页码" OnClick="btnImport_Click" />
        <div>
            <asp:Repeater ID="rpModule" runat="server" OnItemCommand="rpModule_ItemCommand">
                <HeaderTemplate>
                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                </HeaderTemplate>
                <ItemTemplate>
                    <!--GetStyle 只显示要显示的导入项-->
                    <tr style="<%#GetStyle(Eval("ModuleName").ToString())%>">
                        <td>
                            <%#(Eval("ModuleName").ToString())%>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbDownloadExcel" runat="server" CommandName="down" CommandArgument='<%#Eval("ID")+","+Eval("ModuleID") %>'>导入资源</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
