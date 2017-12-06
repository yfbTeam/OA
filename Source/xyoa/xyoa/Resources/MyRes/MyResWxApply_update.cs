namespace xyoa.Resources.MyRes
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyResWxApply_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected TextBox GmFeiyong;
        protected TextBox GmNum;
        protected TextBox GmTime;
        protected TextBox Gongyinshang;
        protected HtmlHead Head1;
        protected TextBox JbName;
        protected Label Label1;
        protected Label LcZhuangtai;
        private Db List = new Db();
        protected HtmlInputHidden NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Shuoming;
        protected HtmlInputHidden YjbNodeId;
        protected TextBox ZyId;
        protected TextBox ZyName;

        public void BindAttribute()
        {
            this.ZyName.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_ResWx  Set  JbName='", this.pulicss.GetFormatStr(this.JbName.Text), "',GmTime='", this.pulicss.GetFormatStr(this.GmTime.Text), "',GmNum='", this.pulicss.GetFormatStr(this.GmNum.Text), "',GmFeiyong='", this.GmFeiyong.Text, "',Gongyinshang='", this.Gongyinshang.Text, "',Shuoming='", this.Shuoming.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  and Username='", this.Session["username"], 
                "' "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改物品维修", "物品维修");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyResWxApply.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyResWxApply.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_ResWx  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  and Username='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ZyId.Text = list["ZyId"].ToString();
                    this.JbName.Text = list["JbName"].ToString();
                    this.GmTime.Text = DateTime.Parse(list["GmTime"].ToString()).ToShortDateString();
                    this.GmNum.Text = list["GmNum"].ToString();
                    this.GmFeiyong.Text = list["GmFeiyong"].ToString();
                    this.Gongyinshang.Text = list["Gongyinshang"].ToString();
                    this.Shuoming.Text = list["Shuoming"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    if ((list["LcZhuangtai"].ToString() == "1") || (list["LcZhuangtai"].ToString() == "4"))
                    {
                        this.Button1.Visible = true;
                    }
                    else
                    {
                        this.Label1.Text = "当前状态不允许修改";
                        this.Button1.Visible = false;
                    }
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                }
                list.Close();
                string str2 = "select * from qp_oa_ResourcesAdd  where id='" + this.ZyId.Text + "'  ";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ZyName.Text = reader2["ZyName"].ToString();
                }
                reader2.Close();
                this.BindAttribute();
            }
        }
    }
}

