namespace xyoa.InfoManage.Taolunzu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TaolunzuMy_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox CyRealname;
        protected TextBox CyUsername;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Leixing;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;
        protected RadioButtonList Zhuangtai;

        public void BindAttribute()
        {
            this.CyRealname.Attributes.Add("readonly", "readonly");
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_Taolunzu (Leixing,Name,Username,Realname,Settime,Zhuangtai,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Paixun) values ('", this.Leixing.SelectedValue, "','", this.pulicss.GetFormatStr(this.Name.Text), "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "','", this.Zhuangtai.SelectedValue, "','", this.States.SelectedValue, "','", this.pulicss.GetFormatStr(this.ZdBumenId.Text), 
                "','", this.pulicss.GetFormatStr(this.ZdBumen.Text), "','", this.pulicss.GetFormatStr(this.ZdUsername.Text), "','", this.pulicss.GetFormatStr(this.ZdRealname.Text), "','", this.pulicss.GetFormatStr(this.Paixun.Text), "')"
             });
            this.List.ExeSql(sql);
            string str2 = "select top 1 id from qp_oa_Taolunzu where Username='" + this.Session["Username"] + "' order by id desc";
            SqlDataReader reader = this.List.GetList(str2);
            if (reader.Read())
            {
                string str3 = null;
                string str4 = null;
                str4 = "" + this.CyUsername.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str4.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str3 = str3 + "'" + strArray[i] + "',";
                }
                str3 = str3 + "'0'";
                string str5 = "select username,realname from qp_oa_Username where  username in (" + str3 + ") ";
                SqlDataReader reader2 = this.List.GetList(str5);
                while (reader2.Read())
                {
                    string str6 = string.Concat(new object[] { "insert into qp_oa_TaolunzuRy  (Keyid,Username,Realname,Settime,Tixing,IfTixing,Weidu) values ('", reader["id"], "','", reader2["username"], "','", reader2["realname"], "','", DateTime.Now.ToString(), "','1','0','0')" });
                    this.List.ExeSql(str6);
                }
                reader2.Close();
            }
            reader.Close();
            this.pulicss.InsertLog("新增讨论组", "讨论组");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='TaolunzuMy.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("TaolunzuMy.aspx");
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
            }
        }
    }
}

