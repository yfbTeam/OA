namespace xyoa.SystemManage.User
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class username_dr : Page
    {
        protected DropDownList BuMenId;
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected HtmlInputFile fileExcel;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList Zhiweiid;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/UserFile/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.fileExcel.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.fileExcel.PostedFile.FileName));
                if ((extension != ".xls") && (extension != ".XLS"))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！只允许上传xls文件');</script>");
                }
                else
                {
                    Random random = new Random();
                    string str6 = random.Next(0x2710).ToString();
                    string str7 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str6 + "";
                    str3 = str7;
                    this.fileExcel.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string str8 = null;
                    string str9 = null;
                    string str10 = null;
                    string str11 = null;
                    string str12 = null;
                    string str13 = null;
                    string str14 = null;
                    string str15 = null;
                    string str16 = null;
                    string str17 = null;
                    string sql = "select * from qp_oa_Juese where id='" + this.JueseId.SelectedValue + "'";
                    SqlDataReader reader = this.List.GetList(sql);
                    if (reader.Read())
                    {
                        str8 = reader["Perstr"].ToString();
                        str9 = reader["Banmian1"].ToString();
                        str10 = reader["Banmian2"].ToString();
                        str11 = reader["Banmian3"].ToString();
                        str12 = reader["Banmian4"].ToString();
                        str13 = reader["Banmian5"].ToString();
                        str14 = reader["Kz"].ToString();
                        str15 = reader["KzBanmian"].ToString();
                        str16 = reader["Mh"].ToString();
                        str17 = reader["MhBanmian"].ToString();
                    }
                    reader.Close();
                    string str19 = null;
                    string str20 = "select * from qp_oa_Chushihua";
                    SqlDataReader reader2 = this.List.GetList(str20);
                    if (reader2.Read())
                    {
                        this.ViewState["Yangshi"] = reader2["Yangshi"].ToString();
                        this.ViewState["iftx"] = reader2["iftx"].ToString();
                        this.ViewState["txtime"] = reader2["txtime"].ToString();
                        this.ViewState["Sound"] = reader2["Sound"].ToString();
                        this.ViewState["Gongzuotai"] = reader2["Gongzuotai"].ToString();
                        this.ViewState["Biaotilan"] = reader2["Biaotilan"].ToString();
                        this.ViewState["MokuaiID"] = reader2["MokuaiID"].ToString();
                    }
                    reader2.Close();
                    string str21 = FormsAuthentication.HashPasswordForStoringInConfigFile("123", "MD5");
                    Random random2 = new Random();
                    string str22 = random2.Next(0x186a0).ToString();
                    string str23 = str + str7;
                    string str24 = "Select * INTO newtable" + str22 + " FROM  OpenDataSource( 'Microsoft.Jet.OLEDB.4.0','Data Source=" + str23 + ";User ID=Admin;Password=;Extended properties=Excel 5.0')...Sheet1$";
                    this.List.ExeSql(str24);
                    int num = 0;
                    string str25 = "select * from newtable" + str22 + "";
                    SqlDataReader reader3 = this.List.GetList(str25);
                    while (reader3.Read())
                    {
                        string str28;
                        string str26 = "select * from qp_oa_username where Username='" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "'";
                        SqlDataReader reader4 = this.List.GetList(str26);
                        if (reader4.Read())
                        {
                            return;
                        }
                        reader4.Close();
                        num++;
                        if (int.Parse(this.Session["cdk4"].ToString()) < 500)
                        {
                            string str27 = "select count(id) from  qp_oa_username where Iflogin='1'";
                            if (this.List.GetCount(str27) >= int.Parse(this.Session["cdk4"].ToString()))
                            {
                                str28 = "insert into qp_oa_username (pic,Kehushu,jifen,Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('0.gif','0','0','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "','" + str21 + "','" + this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()) + "','" + this.BuMenId.SelectedValue + "','" + this.JueseId.SelectedValue + "','1','" + this.Zhiweiid.SelectedValue + "','1','" + this.pulicss.GetFormatStr(reader3["Email"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["手机号"].ToString()) + "','0','" + this.pulicss.GetFormatStr(reader3["性别"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["备注"].ToString()) + "','" + DateTime.Now.ToString() + "','" + str8 + "','" + str19 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                                this.List.ExeSql(str28);
                            }
                            else
                            {
                                str28 = "insert into qp_oa_username (pic,Kehushu,jifen,Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('0.gif','0','0','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "','" + str21 + "','" + this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()) + "','" + this.BuMenId.SelectedValue + "','" + this.JueseId.SelectedValue + "','1','" + this.Zhiweiid.SelectedValue + "','1','" + this.pulicss.GetFormatStr(reader3["Email"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["手机号"].ToString()) + "','1','" + this.pulicss.GetFormatStr(reader3["性别"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["备注"].ToString()) + "','" + DateTime.Now.ToString() + "','" + str8 + "','" + str19 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                                this.List.ExeSql(str28);
                            }
                        }
                        else
                        {
                            str28 = "insert into qp_oa_username (pic,Kehushu,jifen,Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('0.gif','0','0','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "','" + str21 + "','" + this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()) + "','" + this.BuMenId.SelectedValue + "','" + this.JueseId.SelectedValue + "','1','" + this.Zhiweiid.SelectedValue + "','1','" + this.pulicss.GetFormatStr(reader3["Email"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["手机号"].ToString()) + "','1','" + this.pulicss.GetFormatStr(reader3["性别"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["备注"].ToString()) + "','" + DateTime.Now.ToString() + "','" + str8 + "','" + str19 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                            this.List.ExeSql(str28);
                        }
                        string str29 = "insert into qp_oa_yangshi (Username,Name,Biaotilan) values ('" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "','" + this.ViewState["Yangshi"].ToString() + "','" + this.ViewState["Biaotilan"].ToString() + "')";
                        this.List.ExeSql(str29);
                        string str30 = "insert into qp_oa_Bg (url,username) values ('" + this.ViewState["Gongzuotai"].ToString() + "','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "')";
                        this.List.ExeSql(str30);
                        string str31 = "insert into qp_oa_MyReminded (iftx,txtime,Sound,Username) values ('" + this.ViewState["iftx"].ToString() + "','" + this.ViewState["txtime"].ToString() + "','" + this.ViewState["Sound"].ToString() + "','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "')";
                        this.List.ExeSql(str31);
                        string str32 = "insert into qp_oa_MyState (States,Username) values ('在线','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "')";
                        this.List.ExeSql(str32);
                        string str33 = "insert into qp_oa_MyWeituo (States,Username) values ('0','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "')";
                        this.List.ExeSql(str33);
                        string str34 = "insert into qp_oa_MyData (Bothday,Username,Realname,Unit,Post,Sex,Email,MoveTel) values ('','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()) + "','" + this.BuMenId.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.Zhiweiid.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.pulicss.GetFormatStr(reader3["性别"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["Email"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["手机号"].ToString()) + "')";
                        this.List.ExeSql(str34);
                        int num3 = 0;
                        string str35 = "select * from qp_oa_AllUrl  where id in (" + this.ViewState["MokuaiID"] + "0)";
                        SqlDataReader reader5 = this.List.GetList(str35);
                        while (reader5.Read())
                        {
                            num3++;
                            string str36 = string.Concat(new object[] { "insert into qp_oa_DIYMould  (Name,PaiXun,Username,Realname,LookMuch,KeyId) values ('", reader5["urlname"].ToString(), "','", num3, "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','4','", reader5["id"].ToString(), "')" });
                            this.List.ExeSql(str36);
                        }
                        reader5.Close();
                        string str37 = "" + str9 + "";
                        ArrayList list = new ArrayList();
                        string[] strArray = str37.Split(new char[] { ',' });
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].ToString().Trim() != "")
                            {
                                string str38 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray[i], "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','1','1','", i, "')" });
                                this.List.ExeSql(str38);
                            }
                        }
                        string str39 = "" + str10 + "";
                        ArrayList list2 = new ArrayList();
                        string[] strArray2 = str39.Split(new char[] { ',' });
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            if (strArray2[j].ToString().Trim() != "")
                            {
                                string str40 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray2[j], "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','2','1','", j, "')" });
                                this.List.ExeSql(str40);
                            }
                        }
                        string str41 = "" + str11 + "";
                        ArrayList list3 = new ArrayList();
                        string[] strArray3 = str41.Split(new char[] { ',' });
                        for (int k = 0; k < strArray3.Length; k++)
                        {
                            if (strArray3[k].ToString().Trim() != "")
                            {
                                string str42 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray3[k], "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','3','1','", k, "')" });
                                this.List.ExeSql(str42);
                            }
                        }
                        string str43 = "" + str12 + "";
                        ArrayList list4 = new ArrayList();
                        string[] strArray4 = str43.Split(new char[] { ',' });
                        for (int m = 0; m < strArray4.Length; m++)
                        {
                            if (strArray4[m].ToString().Trim() != "")
                            {
                                string str44 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray4[m], "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','4','1','", m, "')" });
                                this.List.ExeSql(str44);
                            }
                        }
                        string str45 = "" + str13 + "";
                        ArrayList list5 = new ArrayList();
                        string[] strArray5 = str45.Split(new char[] { ',' });
                        for (int n = 0; n < strArray5.Length; n++)
                        {
                            if (strArray5[n].ToString().Trim() != "")
                            {
                                string str46 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray5[n], "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','5','1','", n, "')" });
                                this.List.ExeSql(str46);
                            }
                        }
                        string str47 = "" + str15 + "";
                        ArrayList list6 = new ArrayList();
                        string[] strArray6 = str47.Split(new char[] { ',' });
                        for (int num9 = 0; num9 < strArray6.Length; num9++)
                        {
                            if (strArray6[num9].ToString().Trim() != "")
                            {
                                string str48 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray6[num9], "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','", str14, "','2','", num9, "')" });
                                this.List.ExeSql(str48);
                            }
                        }
                        string str49 = "" + str17 + "";
                        ArrayList list7 = new ArrayList();
                        string[] strArray7 = str49.Split(new char[] { ',' });
                        for (int num10 = 0; num10 < strArray7.Length; num10++)
                        {
                            if (strArray7[num10].ToString().Trim() != "")
                            {
                                string str50 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray7[num10], "','", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','", str16, "','3','", num10, "')" });
                                this.List.ExeSql(str50);
                            }
                        }
                        if (this.CheckBox1.Checked)
                        {
                            string str51 = "insert into qp_hr_Yuangong  (Xiangpian,Xingming,Xingbie,Shouji,Youxiang,Bumen,Zhiwei,Zaizhi,Username) values ('/HumanResources/Employee/Yuangong/file/0.jpg','" + this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["性别"].ToString()).Replace("男", "1").Replace("女", "2") + "','" + this.pulicss.GetFormatStr(reader3["手机号"].ToString()) + "','" + this.pulicss.GetFormatStr(reader3["Email"].ToString()) + "','" + this.BuMenId.SelectedValue + "','" + this.Zhiweiid.SelectedValue + "','1','" + this.pulicss.GetFormatStr(reader3["用户名"].ToString()) + "')";
                            this.List.ExeSql(str51);
                        }
                        if (this.CheckBox2.Checked)
                        {
                            str28 = string.Concat(new object[] { 
                                "insert into qp_oa_CompanyGroup   (XtUsername,Name,BuMenId,JueseId,Zhiweiid,Sex,BothDay,Officetel,Fax,MoveTel,HomeTel,Email,QQNum,MsnNum,NbNum,Address,ZipCode,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(reader3["用户名"].ToString()), "','", this.pulicss.GetFormatStr(reader3["真实姓名"].ToString()), "','", this.BuMenId.SelectedValue, "','0','", this.Zhiweiid.SelectedValue, "','", this.pulicss.GetFormatStr(reader3["性别"].ToString()), "','','','','", this.pulicss.GetFormatStr(reader3["手机号"].ToString()), "','','", this.pulicss.GetFormatStr(reader3["Email"].ToString()), "','','','','','','','", this.Session["Username"], 
                                "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                             });
                            this.List.ExeSql(str28);
                        }
                    }
                    reader3.Close();
                    this.pulicss.InsertLog("导入用户", "用户管理");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.dialogArguments.window.location.href='username.aspx'; window.close()</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('导入文件不能为空！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("username.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListNothing("qp_oa_Bumen", this.BuMenId, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_nothing(this.Zhiweiid, sQL, "id", "name");
                string str2 = "select id,name  from qp_oa_Juese order by id asc";
                this.list.Bind_DropDownList_nothing(this.JueseId, str2, "id", "name");
                this.BindAttribute();
            }
        }
    }
}

