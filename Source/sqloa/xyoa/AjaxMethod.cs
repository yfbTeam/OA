﻿namespace xyoa
{
    using Ajax;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class AjaxMethod
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void AddTaolun(string Content, string KeyId)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_TaolunzuSms (Content,SUsername,SRealname,Settimes,KeyId) values('", Content, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["Realname"], "','", DateTime.Now.ToString(), "','", KeyId, "')" });
            this.List.ExeSql(sql);
            string str2 = "select A.Username,A.Realname,B.Name from qp_oa_TaolunzuRy as [A] inner join [qp_oa_Taolunzu] as [B] on [A].[Keyid] = [B].[Id] where  Tixing='1' and IfTixing='0' and KeyId='" + KeyId + "' and datediff(ss,A.Settime,getdate())>2";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                this.pulicss.InsertMessage("讨论组：[" + list["Name"].ToString() + "]有新消息，[<a href=\"/InfoManage/Taolunzu/TaolunzuView.aspx?id=" + KeyId + "\" target=_blank>点击进入</a>]", list["Username"].ToString(), list["Realname"].ToString(), "/InfoManage/Taolunzu/TaolunzuView.aspx?id=" + KeyId + "");
            }
            list.Close();
            string str3 = "update qp_oa_TaolunzuRy set Weidu=Weidu+1,IfTixing=1 where  KeyId='" + KeyId + "' and datediff(ss,Settime,getdate())>2";
            this.List.ExeSql(str3);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void addWin(string KeyFile, string menhu, string leixing, string paixun)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_MyUrl (paixun,leixing,menhu,KeyId,Username,Realname) values('", paixun, "','", leixing, "','", menhu, "','", KeyFile, "','", HttpContext.Current.Session["Username"], "','", HttpContext.Current.Session["Realname"], "')" });
            this.List.ExeSql(sql);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void dbsy(string KeyFile)
        {
            if (KeyFile == "1")
            {
                string sql = "  Delete from qp_oa_DaibanshiyiKey  where Username='" + HttpContext.Current.Session["Username"] + "'";
                this.List.ExeSql(sql);
            }
            else
            {
                string str2 = "insert into qp_oa_DaibanshiyiKey (Username) values('" + HttpContext.Current.Session["Username"] + "')";
                this.List.ExeSql(str2);
            }
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void delmessage(string user)
        {
            string sql = string.Concat(new object[] { "  Delete from qp_oa_Messages  where sendusername='", HttpContext.Current.Session["username"], "' and acceptusername='", user, "' and tablekey='2'" });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "  Delete from qp_oa_Messages  where acceptusername='", HttpContext.Current.Session["username"], "' and sendusername='", user, "' and tablekey='1'" });
            this.List.ExeSql(str2);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void delWin(string KeyFile)
        {
            string sql = "  Delete from qp_oa_MyUrl  where id='" + KeyFile + "'";
            this.List.ExeSql(sql);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet get_chatcount(string user)
        {
            return GetDataSet(string.Concat(new object[] { "select  count(id) as Scount  from qp_oa_Messages where ((acceptusername='", HttpContext.Current.Session["username"], "' and sendusername='", user, "') or (acceptusername='", user, "' and sendusername='", HttpContext.Current.Session["username"], "')) and sfck='0'" }));
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet Getchat(string user)
        {
            return GetDataSet(string.Concat(new object[] { "select *  from qp_oa_Messages where id    in   (Select   top   50     id   From   qp_oa_Messages where (acceptusername='", user, "' and sendusername='", HttpContext.Current.Session["username"], "' and tablekey='2') or (acceptusername='", HttpContext.Current.Session["username"], "' and sendusername='", user, "' and tablekey='1') order by id desc) order by id asc" }));
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet GetchatWd()
        {
            return GetDataSet("select  *  from qp_oa_Messages  where sfck='0' and acceptusername='" + HttpContext.Current.Session["username"] + "' and tablekey='1' order by id asc");
        }

        public static DataSet GetDataSet(string sql)
        {
            string selectConnectionString = ConfigurationSettings.AppSettings["connstr"];
            SqlDataAdapter adapter = new SqlDataAdapter(sql, selectConnectionString);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet InsertGs(string KeyId, string Gongsi)
        {
            return GetDataSet("insert into qp_oa_BaobiaoGs (KeyId,Gongsi) values('" + KeyId + "','" + Gongsi + "')");
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet InsertLb(string KeyFile, string Number, string Name, string Leixing)
        {
            return GetDataSet("insert into qp_oa_FormFile (KeyFile,Number,Name,Type,KxGuoLvUser,KxGuoLvName,BmGuoLvUser,BmGuoLvName) values('" + KeyFile + "','" + Number + "','" + Name + "','[" + Leixing + "]','','','','')");
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet InsertLbKj(string sqlstr, string KeyFile, string Number, string Name, string Leixing)
        {
            return GetDataSet("insert into qp_oa_FormFile (sqlstr,KeyFile,Number,Name,Type,KxGuoLvUser,KxGuoLvName,BmGuoLvUser,BmGuoLvName) values('" + sqlstr + "','" + KeyFile + "','" + Number + "','" + Name + "','[" + Leixing + "]','','','','')");
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet InsertTable(string keyid, string ziduan, string neirong)
        {
            return GetDataSet(string.Concat(new object[] { "insert into qp_oa_FormFilelog (keyid,ziduan,neirong,banliren,shijian) values ('", keyid, "','", ziduan, "','", neirong, "','", HttpContext.Current.Session["Realname"], "','", DateTime.Now.ToString(), "')" }));
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet ListAllUser()
        {
            string sql = "select * from qp_oa_Username ";
            return GetDataSet(sql);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet ListGetchat(string KeyId)
        {
            return GetDataSet("select *  from qp_oa_TaolunzuSms where  KeyId='" + KeyId + "'");
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet ListPeople(string KeyId)
        {
            return GetDataSet("select *,datediff(ss,Settime,getdate()) as times from qp_oa_TaolunzuRy where  KeyId='" + KeyId + "' order by datediff(ss,Settime,getdate()) asc");
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet ListPeopleUser()
        {
            string sql = "select * from qp_useronline where  datediff(ss,firsttime,lasttime)<=20  ";
            return GetDataSet(sql);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet sendmessage(string KeyFile, string Number, string Name)
        {
            return GetDataSet("insert into qp_oa_FormFile (KeyFile,Number,Name,Type,KxGuoLvUser,KxGuoLvName,BmGuoLvUser,BmGuoLvName) values('" + KeyFile + "','" + Number + "','" + Name + "','[常规型]','','','','')");
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void talkmessage(string titles, string acceptusername, string acceptrealname)
        {
            Random random = new Random();
            string str = random.Next(0x2710).ToString();
            string str2 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
            string sql = string.Concat(new object[] { "insert into qp_oa_Messages  (titles,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number,tablekey) values ('", titles, "','", DateTime.Now.ToString(), "','", acceptusername, "','", acceptrealname, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["realname"], "','0','/InfoManage/messages/Messages.aspx','", str2, "','1')" });
            this.List.ExeSql(sql);
            string str4 = string.Concat(new object[] { "insert into qp_oa_Messages  (titles,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number,tablekey) values ('", titles, "','", DateTime.Now.ToString(), "','", acceptusername, "','", acceptrealname, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["realname"], "','0','/InfoManage/messages/Messages.aspx','", str2, "','2')" });
            this.List.ExeSql(str4);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet UpdateBianqian(string content)
        {
            return GetDataSet(string.Concat(new object[] { " Update qp_oa_MakeTing  Set content='", content, "' where username='", HttpContext.Current.Session["username"], "'" }));
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet UpdateListPeople(string KeyId)
        {
            string str2;
            string sql = string.Concat(new object[] { "select id from qp_oa_TaolunzuRy where  KeyId='", KeyId, "' and username='", HttpContext.Current.Session["username"], "'" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str2 = string.Concat(new object[] { "Update qp_oa_TaolunzuRy  Set Settime='", DateTime.Now.ToString(), "' where KeyId='", KeyId, "' and username='", HttpContext.Current.Session["username"], "'" });
                list.Close();
                return GetDataSet(str2);
            }
            str2 = string.Concat(new object[] { "insert into qp_oa_TaolunzuRy (Keyid,Username,Realname,Settime,Tixing,IfTixing,Weidu) values('", KeyId, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["Realname"], "','", DateTime.Now.ToString(), "','1','0','0')" });
            list.Close();
            return GetDataSet(str2);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void UpdateMessages(string content)
        {
            string sql = "Update qp_oa_Messages  Set sfck='1' , CkTime='" + DateTime.Now.ToString() + "' where id='" + content + "'";
            this.List.ExeSql(sql);
            string str2 = "select number from qp_oa_Messages where  id='" + content + "'";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                string str3 = string.Concat(new object[] { "Update qp_oa_Messages  Set sfck='1' , CkTime='", DateTime.Now.ToString(), "' where number='", list["number"], "' and tablekey='2'" });
                this.List.ExeSql(str3);
            }
            list.Close();
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public void UpdateMessagesForJs(string user)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Messages  Set sfck='1' , CkTime='", DateTime.Now.ToString(), "' where acceptusername='", HttpContext.Current.Session["username"], "' and sendusername='", user, "' and sfck='0' and tablekey='1'" });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "Update qp_oa_Messages  Set sfck='1' , CkTime='", DateTime.Now.ToString(), "' where (acceptusername='", HttpContext.Current.Session["username"], "' and sendusername='", user, "')  and sfck='0' and tablekey='2'" });
            this.List.ExeSql(str2);
        }

        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public DataSet UpdateTixing(string Tixing, string KeyId)
        {
            return GetDataSet(string.Concat(new object[] { " Update qp_oa_TaolunzuRy  Set Tixing='", Tixing, "' where  KeyId='", KeyId, "' and username='", HttpContext.Current.Session["username"], "'" }));
        }
    }
}

