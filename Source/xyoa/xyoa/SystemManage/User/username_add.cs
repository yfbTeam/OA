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

    public class username_add : Page
    {
        protected TextBox Bothday;
        protected DropDownList BuMenId;
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected TextBox Email;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Iflogin;
        protected DropDownList IfResponUpdate;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox MoveTel;
        protected TextBox Number;
        protected TextBox paixu;
        protected TextBox Password;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox Remark;
        protected RadioButtonList Sex;
        protected DropDownList StardType;
        protected HtmlInputFile uploadFile;
        protected TextBox Username;
        protected DropDownList Zhiweiid;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         //   if (int.Parse(this.Session["cdk4"].ToString()) < 500)
            {
           //     string str = "select count(id) from  qp_oa_username where Iflogin='1'";
            //    if (this.List.GetCount(str) >= int.Parse(this.Session["cdk4"].ToString()))
                {
             //       base.Response.Write("<script>alert('您当前版本，软件使用人数限制为" + this.Session["cdk4"].ToString() + "人！如需增加用户数请联系开发商！');</Script>");
             //       return;
                }
            }
            string str2 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
            string sql = "select * from qp_oa_username where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "'";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                reader.Close();
                base.Response.Write("<script language=javascript>alert('此用户名在用户管理中已经存在，不能重复！');</script>");
            }
            else
            {
                string str39;
                string str40;
                reader.Close();
                string str4 = null;
                string str5 = null;
                string str6 = null;
                string str7 = null;
                string str8 = null;
                string str9 = null;
                string str10 = null;
                string str11 = null;
                string str12 = null;
                string str13 = null;
                string str14 = "select * from qp_oa_Juese where id='" + this.JueseId.SelectedValue + "'";
                SqlDataReader reader2 = this.List.GetList(str14);
                if (reader2.Read())
                {
                    if (this.IfResponUpdate.SelectedValue == "1")
                    {
                        str4 = reader2["Perstr"].ToString();
                    }
                    else
                    {
                        str4 = "";
                    }
                    str5 = reader2["Banmian1"].ToString();
                    str6 = reader2["Banmian2"].ToString();
                    str7 = reader2["Banmian3"].ToString();
                    str8 = reader2["Banmian4"].ToString();
                    str9 = reader2["Banmian5"].ToString();
                    str10 = reader2["Kz"].ToString();
                    str11 = reader2["KzBanmian"].ToString();
                    str12 = reader2["Mh"].ToString();
                    str13 = reader2["MhBanmian"].ToString();
                }
                reader2.Close();
                string str15 = "" + str5 + "";
                ArrayList list = new ArrayList();
                string[] strArray = str15.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToString().Trim() != "")
                    {
                        string str16 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray[i], "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','1','1','", i, "')" });
                        this.List.ExeSql(str16);
                    }
                }
                string str17 = "" + str6 + "";
                ArrayList list2 = new ArrayList();
                string[] strArray2 = str17.Split(new char[] { ',' });
                for (int j = 0; j < strArray2.Length; j++)
                {
                    if (strArray2[j].ToString().Trim() != "")
                    {
                        string str18 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray2[j], "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','2','1','", j, "')" });
                        this.List.ExeSql(str18);
                    }
                }
                string str19 = "" + str7 + "";
                ArrayList list3 = new ArrayList();
                string[] strArray3 = str19.Split(new char[] { ',' });
                for (int k = 0; k < strArray3.Length; k++)
                {
                    if (strArray3[k].ToString().Trim() != "")
                    {
                        string str20 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray3[k], "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','3','1','", k, "')" });
                        this.List.ExeSql(str20);
                    }
                }
                string str21 = "" + str8 + "";
                ArrayList list4 = new ArrayList();
                string[] strArray4 = str21.Split(new char[] { ',' });
                for (int m = 0; m < strArray4.Length; m++)
                {
                    if (strArray4[m].ToString().Trim() != "")
                    {
                        string str22 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray4[m], "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','4','1','", m, "')" });
                        this.List.ExeSql(str22);
                    }
                }
                string str23 = "" + str9 + "";
                ArrayList list5 = new ArrayList();
                string[] strArray5 = str23.Split(new char[] { ',' });
                for (int n = 0; n < strArray5.Length; n++)
                {
                    if (strArray5[n].ToString().Trim() != "")
                    {
                        string str24 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray5[n], "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','5','1','", n, "')" });
                        this.List.ExeSql(str24);
                    }
                }
                string str25 = "" + str11 + "";
                ArrayList list6 = new ArrayList();
                string[] strArray6 = str25.Split(new char[] { ',' });
                for (int num7 = 0; num7 < strArray6.Length; num7++)
                {
                    if (strArray6[num7].ToString().Trim() != "")
                    {
                        string str26 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray6[num7], "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','", str10, "','2','", num7, "')" });
                        this.List.ExeSql(str26);
                    }
                }
                string str27 = "" + str13 + "";
                ArrayList list7 = new ArrayList();
                string[] strArray7 = str27.Split(new char[] { ',' });
                for (int num8 = 0; num8 < strArray7.Length; num8++)
                {
                    if (strArray7[num8].ToString().Trim() != "")
                    {
                        string str28 = string.Concat(new object[] { "insert into qp_oa_MyUrl (KeyId,Username,Realname,menhu,leixing,paixun) values ('", strArray7[num8], "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','", str12, "','3','", num8, "')" });
                        this.List.ExeSql(str28);
                    }
                }
                string str29 = null;
                int num9 = 0;
                string str30 = "select * from qp_oa_AllUrl  where id in (" + this.ViewState["MokuaiID"] + "0)";
                SqlDataReader reader3 = this.List.GetList(str30);
                while (reader3.Read())
                {
                    num9++;
                    string str31 = string.Concat(new object[] { "insert into qp_oa_DIYMould  (Name,PaiXun,Username,Realname,LookMuch,KeyId) values ('", reader3["urlname"].ToString(), "','", num9, "','", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text), "','4','", reader3["id"].ToString(), "')" });
                    this.List.ExeSql(str31);
                }
                reader3.Close();
                string str32 = base.Server.MapPath("file/");
                string str33 = string.Empty;
                string str34 = string.Empty;
                if (this.uploadFile.PostedFile.ContentLength != 0)
                {
                    string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                    Random random = new Random();
                    string str38 = random.Next(0x2710).ToString();
                    str34 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str38;
                    this.uploadFile.PostedFile.SaveAs(str32 + str34 + extension);
                    str33 = str34 + extension;
                    str39 = "insert into qp_oa_username (pic,Kehushu,Bothday,jifen,paixu,Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('/SystemManage/User/file/" + str33 + "','50','" + this.Bothday.Text + "','0','" + this.pulicss.GetFormatStr(this.paixu.Text) + "','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + str2 + "','" + this.pulicss.GetFormatStr(this.Realname.Text).Replace(" ", "") + "','" + this.BuMenId.SelectedValue + "','" + this.JueseId.SelectedValue + "','" + this.IfResponUpdate.SelectedValue + "','" + this.Zhiweiid.SelectedValue + "','" + this.StardType.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Email.Text) + "','" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "','" + this.Iflogin.SelectedValue + "','" + this.Sex.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Remark.Text) + "','" + DateTime.Now.ToString() + "','" + str4 + "','" + str29 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                    this.List.ExeSql(str39);
                    if (this.CheckBox1.Checked)
                    {
                        str40 = "insert into qp_hr_Yuangong  (Xiangpian,Xingming,Xingbie,Shouji,Youxiang,Bumen,Zhiwei,Zaizhi,Username) values ('/SystemManage/User/file/" + str33 + "','" + this.pulicss.GetFormatStr(this.Realname.Text.Trim()) + "','" + this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2") + "','" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "','" + this.pulicss.GetFormatStr(this.Email.Text) + "','" + this.BuMenId.SelectedValue + "','" + this.Zhiweiid.SelectedValue + "','1','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                        this.List.ExeSql(str40);
                    }
                }
                else
                {
                    str39 = "insert into qp_oa_username (pic,Kehushu,Bothday,jifen,paixu,Username,Password,Realname,BuMenId,JueseId,IfResponUpdate,Zhiweiid,StardType,Email,MoveTel,Iflogin,Sex,Remark,settime,ResponQx,QxString,guanzhu,lasttime,onlinetime,ifdel) values ('/SystemManage/User/file/0.jpg','50','" + this.Bothday.Text + "','0','" + this.pulicss.GetFormatStr(this.paixu.Text) + "','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + str2 + "','" + this.pulicss.GetFormatStr(this.Realname.Text).Replace(" ", "") + "','" + this.BuMenId.SelectedValue + "','" + this.JueseId.SelectedValue + "','" + this.IfResponUpdate.SelectedValue + "','" + this.Zhiweiid.SelectedValue + "','" + this.StardType.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Email.Text) + "','" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "','" + this.Iflogin.SelectedValue + "','" + this.Sex.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Remark.Text) + "','" + DateTime.Now.ToString() + "','" + str4 + "','" + str29 + "','','" + DateTime.Now.AddDays(-1.0).ToString() + "','0','0')";
                    this.List.ExeSql(str39);
                    if (this.CheckBox1.Checked)
                    {
                        str40 = "insert into qp_hr_Yuangong  (Xiangpian,Xingming,Xingbie,Shouji,Youxiang,Bumen,Zhiwei,Zaizhi,Username) values ('/HumanResources/Employee/Yuangong/file/0.jpg','" + this.pulicss.GetFormatStr(this.Realname.Text.Trim()) + "','" + this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2") + "','" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "','" + this.pulicss.GetFormatStr(this.Email.Text) + "','" + this.BuMenId.SelectedValue + "','" + this.Zhiweiid.SelectedValue + "','1','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                        this.List.ExeSql(str40);
                    }
                }
                string str41 = "insert into qp_oa_yangshi (Username,Name,Biaotilan) values ('" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.ViewState["Yangshi"].ToString() + "','" + this.ViewState["Biaotilan"].ToString() + "')";
                this.List.ExeSql(str41);
                string str42 = "insert into qp_oa_Bg (url,username) values ('" + this.ViewState["Gongzuotai"].ToString() + "','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str42);
                string str43 = "insert into qp_oa_MyReminded (iftx,txtime,Sound,Username) values ('" + this.ViewState["iftx"].ToString() + "','" + this.ViewState["txtime"].ToString() + "','" + this.ViewState["Sound"].ToString() + "','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str43);
                string str44 = "insert into qp_oa_MyState (States,Username) values ('无','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str44);
                string str45 = "insert into qp_oa_MyWeituo (States,Username) values ('0','" + this.pulicss.GetFormatStr(this.Username.Text) + "')";
                this.List.ExeSql(str45);
                string str46 = "insert into qp_oa_MyData (Bothday,Username,Realname,Unit,Post,Sex,Email,MoveTel) values ('','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Realname.Text) + "','" + this.BuMenId.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.Zhiweiid.SelectedItem.Text.Replace("|", "").Replace("-", "") + "','" + this.Sex.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Email.Text) + "','" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "')";
                this.List.ExeSql(str46);
                this.pulicss.InsertLog("新增用户[" + this.Realname.Text + "]", "用户管理");
                if (this.CheckBox2.Checked)
                {
                    string str47 = string.Concat(new object[] { 
                        "insert into qp_oa_CompanyGroup   (XtUsername,Name,BuMenId,JueseId,Zhiweiid,Sex,BothDay,Officetel,Fax,MoveTel,HomeTel,Email,QQNum,MsnNum,NbNum,Address,ZipCode,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(this.Username.Text), "','", this.pulicss.GetFormatStr(this.Realname.Text.Trim()), "','", this.BuMenId.SelectedValue, "','0','", this.Zhiweiid.SelectedValue, "','", this.pulicss.GetFormatStr(this.Sex.SelectedValue), "','','','','", this.pulicss.GetFormatStr(this.MoveTel.Text), "','','", this.pulicss.GetFormatStr(this.Email.Text), "','','','','','','','", this.Session["Username"], 
                        "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                     });
                    this.List.ExeSql(str47);
                }
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='username.aspx'</script>");
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
                Random random = new Random();
                string str3 = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str3 + "";
                string sql = "select paixu from qp_oa_username order by paixu desc";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    decimal num = decimal.Parse(list["paixu"].ToString());
                    this.paixu.Text = "" + num + "";
                }
                list.Close();
                string str5 = "select * from qp_oa_Chushihua";
                SqlDataReader reader2 = this.List.GetList(str5);
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
                this.BindAttribute();
            }
        }
    }
}

