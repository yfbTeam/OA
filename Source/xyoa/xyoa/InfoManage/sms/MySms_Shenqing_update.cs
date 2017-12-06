namespace xyoa.InfoManage.sms
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MySms_Shenqing_update : Page
    {
        protected TextBox acceptrealname;
        protected TextBox acceptusername;
        protected Button Button1;
        protected Button Button2;
        protected TextBox Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected TextBox LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected HtmlInputHidden NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected TextBox wbRealname;
        protected TextBox wbUsername;
        protected HtmlInputHidden YjbNodeId;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.acceptrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_shouji   Set acceptusername='", this.pulicss.GetFormatStr(this.acceptusername.Text), "',acceptrealname='", this.pulicss.GetFormatStr(this.acceptrealname.Text), "',wbUsername='", this.wbUsername.Text, "',wbRealname='", this.pulicss.GetFormatStr(this.wbRealname.Text), "',Content='", this.pulicss.GetFormatStr(this.Content.Text), "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], 
                "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改短息申请", "发送短信申请");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MySms_Shenqing.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MySms_Shenqing.aspx");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_shouji   where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.acceptusername.Text = list["acceptusername"].ToString();
                    this.acceptrealname.Text = list["acceptrealname"].ToString();
                    this.wbUsername.Text = list["wbUsername"].ToString();
                    this.wbRealname.Text = list["wbRealname"].ToString();
                    this.Content.Text = list["Content"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    if ((list["LcZhuangtai"].ToString() == "1") || (list["LcZhuangtai"].ToString() == "4"))
                    {
                        this.Button1.Visible = true;
                    }
                    else
                    {
                        this.Label1.Text = "当前状态不允许修改";
                    }
                }
                list.Close();
            }
        }
    }
}

