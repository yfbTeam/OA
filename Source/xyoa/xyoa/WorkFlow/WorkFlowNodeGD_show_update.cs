namespace xyoa.WorkFlow
{
    using FredCK.FCKeditorV2;
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowNodeGD_show_update : Page
    {
        protected Button Button1;
        protected FCKeditor d_content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        private divform showform = new divform();

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlowGd  Set FileContent='", this.pulicss.GetFormatStrbjq(this.d_content.Value), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改归档工作表单[" + this.ViewState["Name"] + "]", "归档工作");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='WorkFlowNodeGD_show_show.aspx?id=" + base.Request.QueryString["id"] + "';window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return closefrom();";
                this.pulicss.QuanXianBack("mmmm7c", this.Session["perstr"].ToString());
                string sql = "select * from qp_oa_AddWorkFlowGd  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.d_content.Value = this.showform.FormatKjStrZh(list["FileContent"].ToString());
                }
                list.Close();
            }
        }
    }
}

