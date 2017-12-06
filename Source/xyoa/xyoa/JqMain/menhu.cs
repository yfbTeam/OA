namespace xyoa.JqMain
{
    using qiupeng.crm;
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class menhu : Page
    {
        protected System.Web.UI.WebControls.Label daibanshiyi;
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected System.Web.UI.WebControls.Label Label;
        protected LinkButton LinkButton1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Tupian;

        public void BindList(string leixing)
        {
            string str = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
            string sql = "select   * from qp_oa_AllUrl where (CHARINDEX(''+quanxian+'','" + str + "')   >   0 ) and leixing='" + leixing + "' and menhulm='1' and ParentNodesID!='0' and ifopen='1' order by paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            this.Label.Text = null;
            int num = 0;
            this.Label.Text = this.Label.Text + "<table width=\"100%\"   border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            this.Label.Text = this.Label.Text + "<tr>";
            while (list.Read())
            {
                SqlDataReader reader2;
                int num2;
                object text;
                string str3 = null;
                string str4 = null;
                if (list["urlname"].ToString() == "便签管理")
                {
                    str3 = "select top  4  * from qp_oa_MakeListTing  where username='" + this.Session["username"] + "'  order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/MyWork/MakeTing/MakeListTing_update.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();'><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["content"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "单位通讯录")
                {
                    num2 = 0;
                    str3 = "select top  12  A.id,A.MoveTel,A.Name, B.[Name] as BuMenName,  D.[Name] as ZhiweiName from [qp_oa_CompanyGroup] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id]";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr>";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<td>&nbsp;&nbsp;<a href=/MyWork/txl/CompanyGroup_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"部门：", reader2["BuMenName"].ToString(), "&#13;职位：", reader2["ZhiweiName"].ToString(), "&#13;手机号：", reader2["MoveTel"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Name"], "(", reader2["BuMenName"], ")</a></td>" });
                        num2++;
                        if (num2 == 2)
                        {
                            str4 = str4 + " </tr><tr>";
                            num2 = 0;
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "个人通讯录")
                {
                    num2 = 0;
                    str3 = "select top  12 id,Name,Sex,BothDay,Post,CName from qp_oa_MyGroup where username='" + this.Session["username"] + "' order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr>";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<td>&nbsp;&nbsp;<a href=/MyWork/txl/MyGroup_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"性别：", reader2["Sex"].ToString(), "&#13;生日：", reader2["BothDay"].ToString(), "&#13;职务：", reader2["Post"].ToString(), "&#13;单位名称：", reader2["CName"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Name"], "</a></td>" });
                        num2++;
                        if (num2 == 3)
                        {
                            str4 = str4 + " </tr><tr>";
                            num2 = 0;
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "外部通讯录")
                {
                    num2 = 0;
                    str3 = "select top  12 id,Name,Sex,Post,CName from qp_oa_WBGroup where username='" + this.Session["username"] + "' order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr>";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<td>&nbsp;&nbsp;<a href=/MyWork/txl/WBGroup_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"性别：", reader2["Sex"].ToString(), "&#13;职务：", reader2["Post"].ToString(), "&#13;单位名称：", reader2["CName"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Name"], "</a></td>" });
                        num2++;
                        if (num2 == 3)
                        {
                            str4 = str4 + " </tr><tr>";
                            num2 = 0;
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "个人文件柜")
                {
                    str3 = "select top  4 * from qp_oa_Paper where username='" + this.Session["username"] + "' order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/Foldersdown.aspx?number=", reader2["NewName"], "  target=\"_blank\" title=\"拥有人：", reader2["Realname"].ToString(), "&#13;上传时间：", reader2["NowTimes"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["OldName"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "员工动态监控")
                {
                    str3 = "select top  4 * from qp_oa_Quxian where CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_QuxianSz where ZgUsername='" + this.Session["username"] + "')+',') > 0 order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Zhuti"], "(", reader2["Realname"], "-", reader2["Nowtimes"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "日程监控")
                {
                    str3 = "select top  4 id,titles,StartTime,EndTime,Username,Realname,Gongkai from qp_oa_MyRicheng where CHARINDEX(','+Username+',',','+(select Glusername from qp_oa_Richengsz where Username='" + this.Session["username"] + "')+',') > 0 order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/MyWork/Richeng/Richengjk_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"开始时间：", reader2["StartTime"].ToString(), "&#13;结束时间：", reader2["EndTime"].ToString(), "&#13;是否公开：", reader2["Gongkai"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "(", reader2["Realname"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "我的会议")
                {
                    str3 = "select top  4 A.id,A.Name,A.MettingName,A.Starttime,A.Endtime,A.State from [qp_oa_MettingApply] as [A] where (State='2' or State='3'  or State='4' or State='5' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0   order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/MyWork/Metting/MettingApply_show.aspx?back=1&id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"会议室：", reader2["MettingName"].ToString(), "&#13;开始时间：", reader2["Starttime"].ToString(), "&#13;结束时间：", reader2["Endtime"].ToString(), "&#13;当前状态：", reader2["State"].ToString().Replace("6", "通过审批").Replace("1", "正在审批").Replace("2", "已发起").Replace("3", "进行中").Replace("4", "结束").Replace("5", "终止"), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Name"], "(", reader2["MettingName"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "我的日程")
                {
                    str3 = "select top  4 id,titles,StartTime,EndTime,Username,Gongkai from qp_oa_MyRicheng  where username='" + this.Session["username"] + "'  order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/MyWork/Richeng/RichengmyList_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"开始时间：", reader2["StartTime"].ToString(), "&#13;结束时间：", reader2["EndTime"].ToString(), "&#13;是否公开：", reader2["Gongkai"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "图片新闻")
                {
                    string str5 = null;
                    string str6 = null;
                    int num3 = 0;
                    str3 = string.Concat(new object[] { "select top 5 id,titles,Photo from qp_oa_TupianNew where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        num3++;
                        text = str5;
                        str5 = string.Concat(new object[] { text, "<li><a href=/PublicWork/TupianNew/TupianNewList_show.aspx?id=", reader2["id"], "><img src=\"/", reader2["Photo"], "\" border=0/></a></li>" });
                        text = str6;
                        str6 = string.Concat(new object[] { text, "<li>", num3, "</li>" });
                    }
                    reader2.Close();
                    this.Tupian.Text = "" + num3 + "";
                    string str9 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    str4 = (str9 + "<tr><td align=\"center\"><div class=\"container\" id=\"idTransformView\"><ul class=\"slider\" id=\"idSlider\">" + str5 + "</ul><ul class=\"num\" id=\"idNum\">" + str6 + "</ul></div></td></tr>") + "</table>";
                }
                if (list["urlname"].ToString() == "部门主页浏览")
                {
                    str3 = string.Concat(new object[] { "select top 4 A.id,A.ZhuyeId,A.titles,A.Settime,A.Username,A.Realname,B.[Name] as BuMenName from [qp_oa_BumenWz] as [A] inner join [qp_oa_BumenZy] as [C] on [A].[ZhuyeId] = [C].[Id] inner join [qp_oa_Bumen] as [B] on [C].[BuMenId] = [B].[Id] inner join [qp_oa_BumenWzLb] as [D] on [A].[WzLeibie] = [D].[Id]  where ((CHARINDEX(',", this.Session["BuMenId"], ",',','+C.ZdBumenId1+',') > 0 and C.States1='2') or (CHARINDEX(',", this.Session["username"], ",',','+C.ZdUsername1+',') > 0 and C.States1='3') or (C.States1='1')) order by A.id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/BumenPage/Zhuye_show.aspx?key=1&id=", reader2["id"], "&ZhuyeId=", reader2["ZhuyeId"], " \"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "(", reader2["BuMenName"], "→", reader2["Realname"], " ", DateTime.Parse(reader2["Settime"].ToString()).ToShortDateString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "通知浏览")
                {
                    str3 = string.Concat(new object[] { "select top  4 id,titles,Settime,Username,Realname,YdUsername from qp_oa_BumenNewsMg where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        string str7 = "," + reader2["YdUsername"] + ",";
                        string str8 = "," + this.Session["username"].ToString() + ",";
                        if (str7.IndexOf(str8) < 0)
                        {
                            text = str4;
                            str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/BumenNewsMg/BumenNewsMgList_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"发布时间：", reader2["Settime"].ToString(), "&#13;发布人：", reader2["Realname"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" /><font color=red>", reader2["titles"], "<font></a></td></tr>" });
                        }
                        else
                        {
                            text = str4;
                            str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/BumenNewsMg/BumenNewsMgList_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"发布时间：", reader2["Settime"].ToString(), "&#13;发布人：", reader2["Realname"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "</a></td></tr>" });
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "新闻浏览")
                {
                    str3 = "select top  4 id,titles,Settime,Realname,Username from qp_oa_NewsMg  order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/NewsMg/NewsMgList_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();' title=\"发布时间：", reader2["Settime"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "大事记浏览")
                {
                    str3 = "select top  4 id,titles from qp_oa_ComThingMg   order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/ComThingMg/ComThingMgList_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();'><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "期刊浏览")
                {
                    str3 = string.Concat(new object[] { "select top 4 A.id,A.Titles,A.Settime,A.username,A.Realname from [qp_oa_QikanMg] as [A] join [qp_oa_QikanLx] as [C] on [A].[TypeId] = [C].id  and   ((CHARINDEX(',", this.Session["BuMenId"], ",',','+[C].ZdBumenId+',') > 0 and [C].States='2') or (CHARINDEX(',", this.Session["username"], ",',','+[C].ZdUsername+',') > 0 and [C].States='3') or ([C].States='1')) order by A.id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/Qikan/QikanLxList_show_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Titles"], "(", reader2["Settime"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "制度浏览")
                {
                    str3 = string.Concat(new object[] { "select top 4 A.id,A.Titles,A.Settime,A.username,A.Realname from [qp_oa_ZhiduMg] as [A] join [qp_oa_ZhiduLx] as [C] on [A].[TypeId] = [C].id  and   ((CHARINDEX(',", this.Session["BuMenId"], ",',','+[C].ZdBumenId+',') > 0 and [C].States='2') or (CHARINDEX(',", this.Session["username"], ",',','+[C].ZdUsername+',') > 0 and [C].States='3') or ([C].States='1')) order by A.id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/Zhidu/ZhiduLxList_show_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Titles"], "(", reader2["Settime"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "视频赏识")
                {
                    str3 = string.Concat(new object[] { "select top 4 A.id,A.Titles,A.Settime,A.username,A.Realname from [qp_oa_ShipinMg] as [A] join [qp_oa_ShipinLx] as [C] on [A].[TypeId] = [C].id  and   ((CHARINDEX(',", this.Session["BuMenId"], ",',','+[C].ZdBumenId+',') > 0 and [C].States='2') or (CHARINDEX(',", this.Session["username"], ",',','+[C].ZdUsername+',') > 0 and [C].States='3') or ([C].States='1')) order by A.id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/Shipin/Shipin_play.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Titles"], "(", reader2["Settime"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "合同审批")
                {
                    str3 = "select top 4 A.Username as AUsername,A.Realname as ARealname,A.id,A.LcZhuangtai,A.DqBlXinming,A.DqBlUsername,A.Zhuti,A.Hetonghao,A.Fenlei,A.Zhuangtai,A.Danwei,A.Jine,B.Name as FenleiName from [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2') order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/PublicWork/Hetong/HetongSp_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Zhuti"], "(", reader2["ARealname"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "会议审批")
                {
                    str3 = "select A.* from [qp_oa_MettingApply] as [A]  where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0  and (LcZhuangtai='1' or LcZhuangtai='2')  order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { 
                            text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/Metting/MettingApply_sp_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();'  title=\"会议名称：", reader2["Name"], "&#13;会议室：", reader2["MettingName"], "&#13;开始时间：", reader2["Starttime"], "&#13;结束时间：", reader2["Endtime"], "&#13;申请人：", reader2["Realname"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Name"], "(", 
                            reader2["Realname"], " ", reader2["Starttime"], "→", reader2["Endtime"], ")</a></td></tr>"
                         });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "用车审批")
                {
                    str3 = "select top  4  A.*, C.CarName from [qp_oa_CarApply] as [A] join [qp_oa_CarInfo] as [C] on [A].[CarId] = [C].id where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')   order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { 
                            text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/Car/CarApply_sp_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();'  title=\"车辆名称：", reader2["CarName"], "&#13;驾驶员：", reader2["Drivers"], "&#13;开始时间：", reader2["Starttime"], "&#13;结束时间：", reader2["Endtime"], "&#13;申请人：", reader2["Realname"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["CarName"], "(", 
                            reader2["Realname"], " ", reader2["Starttime"], "→", reader2["Endtime"], ")</a></td></tr>"
                         });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "我的计划")
                {
                    str3 = "select top 4 A.id,A.Biaoti,A.Leixing,A.StartTime,A.EndTime,A.Youxian,A.DqState,A.SetTimes,A.Username,A.Realname, B.[Leixing] as LeixingName from [qp_oa_MyPlan] as [A] inner join [qp_oa_MyPlanLx] as [B] on [A].[Leixing] = [B].[Id]  where 1=1 and Username='" + this.Session["Username"] + "' order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/WorkPlan/MyPlan_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Biaoti"], "(", reader2["StartTime"], "-", reader2["EndTime"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "计划监控")
                {
                    str3 = "select top 4 A.id,A.Biaoti,A.Leixing,A.StartTime,A.EndTime,A.Youxian,A.DqState,A.SetTimes,A.Username,A.Realname, B.[Leixing] as LeixingName from [qp_oa_MyPlan] as [A] inner join [qp_oa_MyPlanLx] as [B] on [A].[Leixing] = [B].[Id]  where 1=1 and  CHARINDEX(','+A.Username+',',','+(select RyUsername from qp_oa_MyPlanSz where ZgUsername='" + this.Session["username"] + "')+',') > 0 order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/WorkPlan/MyPlanJk_lb_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Biaoti"], "(", reader2["Realname"], "  ", reader2["StartTime"], "-", reader2["EndTime"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "我的日志")
                {
                    str3 = "select top 4 A.id,A.titles,A.NowTimes,A.Username,A.Realname,A.LeiBie, B.[name] as LeiBieName from [qp_oa_MyRizhi] as [A] inner join [qp_oa_RizhiLx] as [B] on [A].[LeiBie] = [B].[Id]  where username='" + this.Session["username"] + "' order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/Rizhi/MyRizhi_show.aspx?key=2&id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "(", DateTime.Parse(reader2["NowTimes"].ToString()), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "日志批注")
                {
                    str3 = "select top 4 A.id,A.titles,A.NowTimes,A.Username,A.Realname,A.LeiBie, B.[name] as LeiBieName from [qp_oa_MyRizhi] as [A] inner join [qp_oa_RizhiLx] as [B] on [A].[LeiBie] = [B].[Id]  where CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_Rizhisz where ZgUsername='" + this.Session["username"] + "')+',') > 0 order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/Rizhi/MyRizhiJk_lb_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "(", reader2["Realname"], " ", DateTime.Parse(reader2["NowTimes"].ToString()), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "我的任务")
                {
                    str3 = string.Concat(new object[] { "select top 4 A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime, B.[name] as LeiBieName from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where (ZbUsername='", this.Session["username"], "' or (CHARINDEX(',", this.Session["username"], ",',','+JbUsername+',')   >   0 )) order by A.id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/Renwu/MyRenwu_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "(", reader2["Starttime"], "→", reader2["Endtime"].ToString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "任务监控")
                {
                    str3 = string.Concat(new object[] { "select top 4 A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime, B.[name] as LeiBieName from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id] inner join [qp_oa_RenwuXb] as [C] on [A].[id] = [C].[Keyid]  where ((CHARINDEX(','+A.ZbUsername+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", this.Session["username"], "')+',') > 0) or (CHARINDEX(','+C.Username+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", this.Session["username"], "')+',') > 0)) group by  A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime,B.[name] order by A.id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/OfficeMenu/Renwu/RenwuJk_lb_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "(", reader2["ZbRealname"], "  ", reader2["Starttime"], "→", reader2["Endtime"].ToString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "未读消息")
                {
                    str3 = "select top  4  * from qp_oa_Messages  where  sfck='0' and  acceptusername='" + this.Session["username"] + "' and tablekey='1'  order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/messages/Messages_show.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();'  title=\"发送人：", reader2["sendrealname"], "&#13;发送时间：", reader2["itimes"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["titles"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "收件箱")
                {
                    str3 = "select top  4  id,Titles,IfRead,FsUsername,FsRealname,FsTime  from qp_oa_NbEmail_sj  where IfDel='0' and  JsUsername='" + this.Session["username"] + "'  order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        if (reader2["IfRead"].ToString() == "True")
                        {
                            text = str4;
                            str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/nbemail/NbEmail_sj_show.aspx?id=", reader2["id"], "&pagemg=1  onclick='parent.UploadComplete();'  title=\"发件人：", reader2["FsRealname"], "&#13;发送时间：", reader2["FsTime"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" /><font color=#000000>", reader2["titles"], "</font></a></td></tr>" });
                        }
                        else
                        {
                            text = str4;
                            str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/nbemail/NbEmail_sj_show.aspx?id=", reader2["id"], "&pagemg=1  onclick='parent.UploadComplete();'  title=\"发件人：", reader2["FsRealname"], "&#13;发送时间：", reader2["FsTime"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" /><font color=Red>", reader2["titles"], "</font></a></td></tr>" });
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "接收文件")
                {
                    str3 = "select top  4 * from qp_oa_InfoSend where CHARINDEX('," + this.Session["username"] + ",',','+JsUsername+',') > 0 order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/filesend/JsInfoSend_show.aspx?id=", reader2["id"], "  \"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Name"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "发送短信审批")
                {
                    str3 = "select top 4 A.* from [qp_oa_shouji] as [A]  where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2') order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/sms/MySms_Shenpi_show.aspx?id=", reader2["id"], "  \"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Content"], "(", reader2["Realname"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "意见管理")
                {
                    str3 = string.Concat(new object[] { "select A.id,A.Titles,A.TxTime,A.Username,A.TxRealname, C.Name from [qp_oa_YjBox] as [A] join [qp_oa_YjBoxSz] as [C] on [A].[BoxId] = [C].id and CHARINDEX('", this.Session["username"], ",',C.Username) > 0 where  CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   =0 order by A.id desc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/YjBox/YjBoxMg_show.aspx?id=", reader2["id"], "  \"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Titles"], "(", reader2["TxRealname"], ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "投票浏览")
                {
                    str3 = "select top  4 *  from qp_oa_toupiaobt  where (type='1' or type='2') and  (CHARINDEX('," + this.Session["Username"] + ",',','+Gkusername+',')   >   0 or Gkusername='0')  order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/toupiao/toupiao_tp.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();'  title=\"选择类型：", reader2["xuanze"], "&#13;当前状态：", reader2["type"], "&#13;公开投票：", reader2["ifopen"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["title"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "论坛BBS")
                {
                    num2 = 0;
                    str3 = string.Concat(new object[] { "select top  12  id,Name  from qp_oa_InsideBBSBig  where ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) and Zhuangtai=1  order by Paixun asc" });
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr>";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<td>&nbsp;&nbsp;<a href=/InfoManage/bbs/InsideBBSList.aspx?id=", reader2["id"], "  onclick='parent.UploadComplete();'><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Name"], "</a></td>" });
                        num2++;
                        if (num2 == 3)
                        {
                            str4 = str4 + " </tr><tr>";
                            num2 = 0;
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "报告批阅")
                {
                    str3 = "select top 4 id,Titles,Realname,Username,State,TxTime from qp_oa_QingShi  where JsUsername='" + this.Session["username"] + "'  order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/InfoManage/QingShi/QingShiList_py.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Titles"], "</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "我拥有的物品")
                {
                    num2 = 0;
                    str3 = "select top 4 A.id,A.shuliang,A.Laiyuan,C.ZyNum, C.ZyName, D.Name as ZyLeibieName from [qp_oa_MyRes] as [A] inner join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id inner join [qp_oa_ResourcesType] as [D] on [C].[ZyLeibie] = [D].id where username='" + this.Session["username"] + "'   order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr>";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<td>&nbsp;&nbsp;<a href='javascript:void(0)'style=\"cursor:help\" title=\"物品编号：", reader2["ZyNum"].ToString(), "&#13;物品名称：", reader2["ZyName"].ToString(), "&#13;物品类别：", reader2["ZyLeibieName"].ToString(), "&#13;拥有数量：", reader2["shuliang"].ToString(), "&#13;物品来源：", reader2["Laiyuan"].ToString(), "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["ZyName"], "(", reader2["shuliang"].ToString(), ")</a></td>" });
                        num2++;
                        if (num2 == 3)
                        {
                            str4 = str4 + " </tr><tr>";
                            num2 = 0;
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "物品购买审批")
                {
                    str3 = "select top 4 A.*, C.ZyName, C.ZyNum from [qp_oa_ResGm] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')  order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/Resources/ResMg/MyResGmApply_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["ZyName"], "(", reader2["Realname"], "→", DateTime.Parse(reader2["GmTime"].ToString()), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "物品报废审批")
                {
                    str3 = "select top 4 A.*, C.ZyName, C.ZyNum from [qp_oa_ResBf] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')  order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/Resources/ResMg/MyResBfApply_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["ZyName"], "(", reader2["Realname"], "→", DateTime.Parse(reader2["GmTime"].ToString()), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "物品借用审批")
                {
                    str3 = "select top 4 A.*, C.ZyName, C.ZyNum from [qp_oa_ResAppJy] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')  order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/Resources/ResMg/MyResJyApply_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["ZyName"], "(", reader2["Realname"], " ", reader2["Starttime"].ToString(), "→", reader2["Endtime"].ToString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "物品使用审批")
                {
                    str3 = "select top 4 A.*, C.ZyName, C.ZyNum from [qp_oa_ResAppSy] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')  order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/Resources/ResMg/MyResSyApply_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["ZyName"], "(", reader2["Realname"], "→", reader2["NowTimes"].ToString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "物品维修审批")
                {
                    str3 = "select top 4 A.*, C.ZyName, C.ZyNum from [qp_oa_ResWx] as [A] join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2')  order by A.id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/Resources/ResMg/MyResWxApply_show.aspx?id=", reader2["id"], "><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["ZyName"], "(", reader2["Realname"], "→", DateTime.Parse(reader2["GmTime"].ToString()), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "待办工作")
                {
                    str3 = "select A.JinJiChengDu,A.id,A.Shuxing,A.Number,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile and [A].[UpNodeNum] = [C].xuhao and [A].[GlNum] = [C].GlNum where BLusername='" + this.Session["username"] + "' and ((States='未接收' and State='正在办理') or (States='办理中' and State='正在办理')) and Ifdel='0' order by A.UpTimeSet desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        if (reader2["Shuxing"].ToString() == "自由流程")
                        {
                            text = str4;
                            str4 = string.Concat(new object[] { 
                                text, "<tr><td>&nbsp;&nbsp;<a href='javascript:void(0)' onclick='window.open (\"/WorkFlow/WorkFlowListSp_zy.aspx?id=", reader2["id"].ToString(), "&UpNodeId=", reader2["UpNodeId"].ToString(), "&FlowNumber=", reader2["FlowNumber"].ToString(), "&FormId=", reader2["FormId"].ToString(), "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")' title=\"流水号：", reader2["Sequence"].ToString(), "&#13;表单类型：", reader2["FormName"], "&#13;工作名称/文号：", reader2["Name"], "&#13;发起人：", 
                                reader2["FqRealname"], "&#13;步骤与流程图：", reader2["NodeName"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" /><img src=\"/oaimg/menu/", reader2["JinJiChengDu"], ".gif\"  border=0/>", reader2["Name"], "</a></td></tr>"
                             });
                        }
                        else
                        {
                            text = str4;
                            str4 = string.Concat(new object[] { 
                                text, "<tr><td>&nbsp;&nbsp;<a href='javascript:void(0)' onclick='window.open (\"/WorkFlow/WorkFlowListSp.aspx?id=", reader2["id"].ToString(), "&UpNodeId=", reader2["UpNodeId"].ToString(), "&FlowNumber=", reader2["FlowNumber"].ToString(), "&FormId=", reader2["FormId"].ToString(), "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")' title=\"流水号：", reader2["Sequence"].ToString(), "&#13;表单类型：", reader2["FormName"], "&#13;工作名称/文号：", reader2["Name"], "&#13;发起人：", 
                                reader2["FqRealname"], "&#13;步骤与流程图：", reader2["NodeName"], "\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" /><img src=\"/oaimg/menu/", reader2["JinJiChengDu"], ".gif\"  border=0/>", reader2["Name"], "</a></td></tr>"
                             });
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "员工档案浏览")
                {
                    num2 = 0;
                    str3 = "select top 30 id,Xingming  from [qp_hr_Yuangong] order by Xingming asc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr>";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<td>&nbsp;&nbsp;<a href='javascript:void(0)'  onclick=\"showfrom1('", reader2["id"].ToString(), "')\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Xingming"], "</a></td>" });
                        num2++;
                        if (num2 == 4)
                        {
                            str4 = str4 + " </tr><tr>";
                            num2 = 0;
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "员工生日")
                {
                    num2 = 0;
                    str3 = "select top 30 A.id,A.Xingming,A.Xingbie,A.Zhiwei,A.Chusheng,A.Xuexi,A.Zaizhi,D.[Name] as ZhiweiName ,B.[Name] as BumenName  from [qp_hr_Yuangong] as [A]   inner join [qp_oa_Bumen] as [B] on [A].[Bumen] = [B].[Id]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id] where ((month(ChuSheng)=month(getdate())) and (day(ChuSheng)-day(getdate())) between 0 and 15 or ((month(ChuSheng-15)=month(getdate())) and (day(ChuSheng-15)-day(getdate())) between -15 and 0)) and (ChuSheng!='1900-1-1' or ChuSheng!='1900-01-01') order by A.Xingming asc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr>";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<td>&nbsp;&nbsp;<a href='javascript:void(0)' onclick='showfrom2(\"", reader2["id"], "\")'><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Xingming"], "(", DateTime.Parse(reader2["ChuSheng"].ToString()).Month.ToString().PadLeft(2, '0'), "-", DateTime.Parse(reader2["ChuSheng"].ToString()).Day.ToString().PadLeft(2, '0'), ")</a></td>" });
                        num2++;
                        if (num2 == 3)
                        {
                            str4 = str4 + " <tr></tr>";
                            num2 = 0;
                        }
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "出差审批")
                {
                    str3 = "select * from [qp_hr_MyAttendance]  where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2') and type='1' order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/HumanResources/WorkTime/MyAttendance_show.aspx?id=", reader2["id"], "&type=1><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Subject"], "(", reader2["Realname"].ToString(), "  ", reader2["StartTime"].ToString(), "→", reader2["EndTime"].ToString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "休假审批")
                {
                    str3 = "select * from [qp_hr_MyAttendance]  where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2') and type='2' order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/HumanResources/WorkTime/MyAttendance_show.aspx?id=", reader2["id"], "&type=2><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Subject"], "(", reader2["Realname"].ToString(), "  ", reader2["StartTime"].ToString(), "→", reader2["EndTime"].ToString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                if (list["urlname"].ToString() == "加班审批")
                {
                    str3 = "select * from [qp_hr_MyAttendance]  where CHARINDEX('," + this.Session["username"] + ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2') and type='3' order by id desc";
                    reader2 = this.List.GetList(str3);
                    str4 = str4 + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                    while (reader2.Read())
                    {
                        text = str4;
                        str4 = string.Concat(new object[] { text, "<tr><td>&nbsp;&nbsp;<a href=/HumanResources/WorkTime/MyAttendance_show.aspx?id=", reader2["id"], "&type=3><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\" border=\"0\" />", reader2["Subject"], "(", reader2["Realname"].ToString(), "  ", reader2["StartTime"].ToString(), "→", reader2["EndTime"].ToString(), ")</a></td></tr>" });
                    }
                    str4 = str4 + "</table>";
                    reader2.Close();
                }
                text = this.Label.Text;
                this.Label.Text = string.Concat(new object[] { text, " <td width=\"50%\" valign=\"top\" > <table width=\"100%\" height=\"12\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td></td> </tr></table><table width=\"100%\"  border=\"0\"  cellspacing=\"1\" cellpadding=\"0\"   class=\"maincss\"><tr><td valign=\"top\"  bgcolor=\"#FFFFFF\"><table width=\"100%\" height=\"5\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr>  <td width=\"25\" class=\"mainbody1\" height=\"25\" align=\"center\" ><img src=\"/oaimg/menu/", list["pic"].ToString(), "\"/></td><td width=\"200\" class=\"mainbody1\" height=\"25\" ><a href=\"", list["url"], "\" onclick='parent.UploadComplete();' class=\"MainLine\"><strong>", list["urlname"].ToString(), "</strong></a></td><td class=\"mainbody2\" align=\"right\">&nbsp;</td><td width=\"12\" class=\"mainbody2\">&nbsp;</td></tr></table><table width=\"100%\" height=\"100px\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr> <td valign=\"top\">", str4, "</td></tr></table><table width=\"100%\" height=\"3\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"mainbody3\"><tr> <td></td></tr></table>  </td></tr> </table></td><td width=\"1%\"></td>" });
                num++;
                if (num == 2)
                {
                    this.Label.Text = this.Label.Text + "</tr><TR>";
                    num = 0;
                }
            }
            this.Label.Text = this.Label.Text + " </table>";
            list.Close();
        }

        public void Kuaijie()
        {
            string str3;
            SqlDataReader reader2;
            string text;
            string str = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
            this.daibanshiyi.Text = null;
            this.daibanshiyi.Text = "<table width=\"200\" border=\"0\" cellspacing=\"0\" cellpadding=\"1\">";
            string sql = string.Concat(new object[] { "select UrlId from qp_oa_MyLmUrl  where leixing='", base.Request.QueryString["id"], "' and Username='", this.Session["username"], "' " });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str3 = "select   * from qp_oa_AllUrl where id in (" + list["UrlId"].ToString() + "0) and (CHARINDEX(''+quanxian+'','" + str + "')   >   0 ) and leixing='" + base.Request.QueryString["id"] + "' and Kuaijie='1' and ParentNodesID!='0' and ifopen='1' order by paixu asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    this.daibanshiyi.Text = this.daibanshiyi.Text + "<tr>";
                    text = this.daibanshiyi.Text;
                    this.daibanshiyi.Text = text + "<td align=\"center\" height=\"30\" background=\"/oaimg/zst/dd.jpg\" width=\"40\">&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.jpg\" width=\"160\" height=\"30\"><a href='" + reader2["Url"].ToString() + "' onclick='parent.UploadComplete();'>" + reader2["urlname"].ToString() + "</a></td>";
                    this.daibanshiyi.Text = this.daibanshiyi.Text + " </tr>";
                }
                reader2.Close();
            }
            else
            {
                str3 = "select   * from qp_oa_AllUrl where (CHARINDEX(''+quanxian+'','" + str + "')   >   0 ) and leixing='" + base.Request.QueryString["id"] + "' and Kuaijie='1' and ParentNodesID!='0' and ifopen='1' order by paixu asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    this.daibanshiyi.Text = this.daibanshiyi.Text + "<tr>";
                    text = this.daibanshiyi.Text;
                    this.daibanshiyi.Text = text + "<td align=\"center\" height=\"30\" background=\"/oaimg/zst/dd.jpg\" width=\"40\">&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.jpg\" width=\"160\" height=\"30\"><a href='" + reader2["Url"].ToString() + "' onclick='parent.UploadComplete();'>" + reader2["urlname"].ToString() + "</a></td>";
                    this.daibanshiyi.Text = this.daibanshiyi.Text + " </tr>";
                }
                reader2.Close();
            }
            list.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.Kuaijie();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = 'default.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                this.LinkButton1.Attributes["onclick"] = "javascript:return AddUrl();";
                this.Kuaijie();
                this.BindList(base.Request.QueryString["id"].ToString());
            }
        }
    }
}

