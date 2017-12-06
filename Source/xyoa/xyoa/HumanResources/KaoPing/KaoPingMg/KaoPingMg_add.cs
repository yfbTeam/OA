namespace xyoa.HumanResources.KaoPing.KaoPingMg
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoPingMg_add : Page
    {
        protected Button Button1;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList LeixingID;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Miaoshu;
        private publics pulicss = new publics();
        protected TextBox RealnameCy;
        protected TextBox Starttime;
        protected TextBox UsernameCy;
        protected RadioButtonList Zhuangtai;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.RealnameCy.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_hr_KaoPingSz where id='" + this.LeixingID.SelectedValue + "'";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                this.ViewState["Zongfen"] = reader["Zongfen"].ToString();
                this.ViewState["Neirong"] = reader["Neirong"].ToString();
                this.ViewState["Jishu"] = reader["Jishu"].ToString();
                this.ViewState["QuanzhongMy"] = reader["QuanzhongMy"].ToString();
                this.ViewState["User1"] = reader["User1"].ToString();
                this.ViewState["Name1"] = reader["Name1"].ToString();
                this.ViewState["Quanzhong1"] = reader["Quanzhong1"].ToString();
                this.ViewState["User2"] = reader["User2"].ToString();
                this.ViewState["Name2"] = reader["Name2"].ToString();
                this.ViewState["Quanzhong2"] = reader["Quanzhong2"].ToString();
                this.ViewState["User3"] = reader["User3"].ToString();
                this.ViewState["Name3"] = reader["Name3"].ToString();
                this.ViewState["Quanzhong3"] = reader["Quanzhong3"].ToString();
                this.ViewState["User4"] = reader["User4"].ToString();
                this.ViewState["Name4"] = reader["Name4"].ToString();
                this.ViewState["Quanzhong4"] = reader["Quanzhong4"].ToString();
                this.ViewState["User5"] = reader["User5"].ToString();
                this.ViewState["Name5"] = reader["Name5"].ToString();
                this.ViewState["Quanzhong5"] = reader["Quanzhong5"].ToString();
            }
            reader.Close();
            string str2 = "insert into qp_hr_KaoPingMg  (LeixingID,Zhuti,Starttime,Endtime,Miaoshu,UsernameCy,RealnameCy,Zhuangtai) values ('" + this.LeixingID.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "','" + this.pulicss.GetFormatStr(this.Starttime.Text) + "','" + this.pulicss.GetFormatStr(this.Endtime.Text) + "','" + this.pulicss.GetFormatStr(this.Miaoshu.Text) + "','" + this.pulicss.GetFormatStr(this.UsernameCy.Text) + "','" + this.pulicss.GetFormatStr(this.RealnameCy.Text) + "','" + this.Zhuangtai.SelectedValue + "')";
            this.List.ExeSql(str2);
            string str3 = "select top 1 id from qp_hr_KaoPingMg order by id desc";
            SqlDataReader reader2 = this.List.GetList(str3);
            if (reader2.Read())
            {
                string str4 = null;
                string str5 = null;
                str5 = "" + this.UsernameCy.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str5.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str4 = str4 + "'" + strArray[i] + "',";
                }
                str4 = str4 + "'0'";
                string str6 = "select username,realname from qp_oa_Username where  username in (" + str4 + ") ";
                SqlDataReader reader3 = this.List.GetList(str6);
                while (reader3.Read())
                {
                    string str7 = string.Concat(new object[] { 
                        "insert into qp_hr_KaoPingMgMx (NeirongMy,Jieduan,KpZhuangtaiMy,KpZhuangtai1,KpZhuangtai2,KpZhuangtai3,KpZhuangtai4,KpZhuangtai5,KaopingId,UsernameCy,RealnameCy,Zongfen,Jishu,FenshuMy,QuanzhongMy,User1,Name1,Fenshu1,Quanzhong1,Neirong1,User2,Name2,Fenshu2,Quanzhong2,Neirong2,User3,Name3,Fenshu3,Quanzhong3,Neirong3,User4,Name4,Fenshu4,Quanzhong4,Neirong4,User5,Name5,Fenshu5,Quanzhong5,Neirong5,Zhuangtai,Queren,Shijian) values ('", this.ViewState["Neirong"], "','0','1','3','3','3','3','3','", reader2["id"].ToString(), "','", reader3["username"].ToString(), "','", reader3["realname"].ToString(), "','", this.ViewState["Zongfen"], "','", this.ViewState["Jishu"], "','0','", this.ViewState["QuanzhongMy"], "','", this.ViewState["User1"], 
                        "','", this.ViewState["Name1"], "','0','", this.ViewState["Quanzhong1"], "','", this.ViewState["Neirong"], "','", this.ViewState["User2"], "','", this.ViewState["Name2"], "','0','", this.ViewState["Quanzhong2"], "','", this.ViewState["Neirong"], "','", this.ViewState["User3"], 
                        "','", this.ViewState["Name3"], "','0','", this.ViewState["Quanzhong3"], "','", this.ViewState["Neirong"], "','", this.ViewState["User4"], "','", this.ViewState["Name4"], "','0','", this.ViewState["Quanzhong4"], "','", this.ViewState["Neirong"], "','", this.ViewState["User5"], 
                        "','", this.ViewState["Name5"], "','0','", this.ViewState["Quanzhong5"], "','", this.ViewState["Neirong"], "','1','2','')"
                     });
                    this.List.ExeSql(str7);
                    this.pulicss.InsertMessage("您有考评需要参加，考评主题：" + this.Zhuti.Text + "<br>生效时间：" + this.Starttime.Text + "，终止时间：" + this.Endtime.Text + "", reader3["username"].ToString(), reader3["realname"].ToString(), "/HumanResources/KaoPing/MyPage/KaoPingMgMx.aspx?KpZhuangtaiMy=1");
                }
                reader3.Close();
            }
            reader2.Close();
            this.pulicss.InsertLog("发布考评管理", "考评管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KaoPingMg.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                string sQL = "select id,Leixing from qp_hr_KaoPingSz order by id asc";
                this.list.Bind_DropDownList_kong(this.LeixingID, sQL, "id", "Leixing");
                this.Starttime.Text = DateTime.Now.ToString();
                this.pulicss.QuanXianBack("eeee6fa", this.Session["perstr"].ToString());
            }
        }
    }
}

