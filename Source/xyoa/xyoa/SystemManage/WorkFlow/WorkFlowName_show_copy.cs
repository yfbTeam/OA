namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_copy : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected DropDownList FlowNumber;
        protected HtmlForm form1;
        protected TextBox FormName;
        protected TextBox FormNumber;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_WorkFlowName where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = "select * from qp_oa_WorkFlowNode where FlowNumber='" + this.FlowNumber.SelectedValue + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    string str3 = "insert into qp_oa_WorkFlowNode (XbTimes,YijianZb,YijianJb,WhJbSet,WhZbSet,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,SETLEFT,SETTOP,GlGuize,XrGuize,JcZhuanjiao,ZbZhuanjiao,ZbHuitui,JbHuitui,ZbQuanxian,JbQuanxian,ZbUsername,ZbRealname,JbUsername,JbRealname,UpNodeNum,NodeSite,WriteFileID,WriteFileName,SecFileID,SecFileName) values ('" + reader2["XbTimes"].ToString() + "','" + reader2["YijianZb"].ToString() + "','" + reader2["YijianJb"].ToString() + "','" + reader2["WhJbSet"].ToString() + "','" + reader2["WhZbSet"].ToString() + "','" + base.Request.QueryString["FormId"] + "','" + this.FormNumber.Text + "','" + this.FormName.Text + "','" + list["id"].ToString() + "','" + base.Request.QueryString["FlowNumber"].ToString() + "','" + list["FlowName"].ToString() + "','" + reader2["NodeNumber"].ToString() + "','" + reader2["NodeNum"].ToString() + "','" + reader2["NodeName"].ToString() + "','" + reader2["SETLEFT"].ToString() + "','" + reader2["SETTOP"].ToString() + "','" + reader2["GlGuize"].ToString() + "','" + reader2["XrGuize"].ToString() + "','" + reader2["JcZhuanjiao"].ToString() + "','" + reader2["ZbZhuanjiao"].ToString() + "','" + reader2["ZbHuitui"].ToString() + "','" + reader2["JbHuitui"].ToString() + "','" + reader2["ZbQuanxian"].ToString() + "','" + reader2["JbQuanxian"].ToString() + "','" + reader2["ZbUsername"].ToString() + "','" + reader2["ZbRealname"].ToString() + "','" + reader2["JbUsername"].ToString() + "','" + reader2["JbRealname"].ToString() + "','" + reader2["UpNodeNum"].ToString() + "','" + reader2["NodeSite"].ToString() + "','','','','')";
                    this.List.ExeSql(str3);
                }
                reader2.Close();
                string str4 = "select * from qp_oa_WorkFlowNodeLine where FlowNumber='" + this.FlowNumber.SelectedValue + "'";
                SqlDataReader reader3 = this.List.GetList(str4);
                while (reader3.Read())
                {
                    string str5 = "insert into qp_oa_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FlowNumber) values ('" + reader3["Source"].ToString() + "','" + reader3["Object"].ToString() + "','" + reader3["LineContent"].ToString() + "','" + reader3["NodeNumber"].ToString() + "','" + list["FlowNumber"].ToString() + "')";
                    this.List.ExeSql(str5);
                }
                reader2.Close();
            }
            list.Close();
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='FlowMg_list.aspx?FormId=" + base.Request.QueryString["FormId"] + "';</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlow.aspx?FormId=" + base.Request.QueryString["FormId"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (!base.IsPostBack)
                {
                    string sQL = "select FlowNumber,FlowName from qp_oa_WorkFlowName  where FlowNumber!='" + base.Request.QueryString["FlowNumber"] + "' order by id desc";
                    this.list.Bind_DropDownList(this.FlowNumber, sQL, "FlowNumber", "FlowName");
                    string sql = "select  Number,FormName  from qp_oa_DIYForm where id='" + base.Request.QueryString["FormId"] + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.FormNumber.Text = list["Number"].ToString();
                        this.FormName.Text = list["FormName"].ToString();
                    }
                    list.Close();
                }
                this.BindAttribute();
            }
        }
    }
}

