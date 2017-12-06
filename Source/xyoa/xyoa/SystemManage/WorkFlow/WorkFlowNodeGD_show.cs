namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowNodeGD_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public string LineW;
        public string LineWSta;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        protected TextBox ParentNodes;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        public string QxString;
        public string QxStringSta;
        protected DropDownList States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.Button2.Attributes.Add("onclick", "javascript:return sc();");
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_WorkFlowNodeGD  Set  Name='", this.pulicss.GetFormatStr(this.Name.Text), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',Paixun='", this.Paixun.Text, "',ParentNodesID='", this.ParentNodesID.SelectedValue, 
                "'   where id='", int.Parse(base.Request.QueryString["id"]), "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改归档目录[" + this.Name.Text + "]", "归档目录");
            if (this.CheckBox1.Checked)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.nexthead.location = 'WorkFlowNodeGD_left.aspx'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！'); </script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 id from qp_oa_AddWorkFlowGd where GdId='" + base.Request.QueryString["id"].ToString() + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('此目录存在已归档文件，请先在【工作流程】-【归档工作】中删除已归档文件！'); </script>");
            }
            else
            {
                list.Close();
                if (base.Request.QueryString["id"].ToString() == "0")
                {
                    base.Response.Write("<script language=javascript>alert('没有找到此文件夹！');</script>");
                }
                else
                {
                    this.DelNode(base.Request.QueryString["id"], base.Request.QueryString["id"]);
                    base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'WorkFlowNodeGD.aspx'</script>");
                }
            }
        }

        private void DelNode(string IDStr, string PID)
        {
            string sql = "  Delete from qp_oa_WorkFlowNodeGD  where id='" + IDStr + "'";
            this.List.ExeSql(sql);
            string str2 = "select * from qp_oa_WorkFlowNodeGD where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                string str3 = "  Delete from qp_oa_WorkFlowNodeGD  where id='" + list["ID"].ToString() + "'";
                this.List.ExeSql(str3);
                string str4 = "  Delete from qp_oa_AddWorkFlowGd  where GdId='" + list["ID"].ToString() + "'";
                this.List.ExeSql(str4);
                string str5 = "select * from qp_oa_WorkFlowNodeGD where ParentNodesID=" + list["id"] + " ";
                SqlDataReader reader2 = this.List.GetList(str5);
                if (reader2.Read())
                {
                    string iDStr = list["ID"].ToString();
                    string pID = list["ParentNodesID"].ToString();
                    this.DelNode(iDStr, pID);
                }
                reader2.Close();
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListBm("qp_oa_WorkFlowNodeGD", this.ParentNodesID, "", "order by Paixun asc");
                string sql = "select * from qp_oa_WorkFlowNodeGD  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ParentNodesID.SelectedValue = list["ParentNodesID"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                    this.ParentNodes.Text = list["ParentNodesID"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

