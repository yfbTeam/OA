namespace xyoa.HumanResources.PeiXun.ShiJuan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ShiJuanMxSd_Add_Tiankong : Page
    {
        protected Button Button3;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.Button3.Attributes["onclick"] = "javascript:return _del();";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "select id from qp_hr_TianKongTi where  ID in (" + str + ")";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str3 = "insert into qp_hr_ShiJuanMx (ShijuanID,Leixing,TiMuID,Fenshu) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "','4','" + list["id"].ToString() + "','0')";
                this.List.ExeSql(str3);
            }
            list.Close();
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        private string CheckCbxDel()
        {
            string str = "0";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string str = "select A.*,D.[Mingcheng] as Mingcheng from [qp_hr_TianKongTi] as [A]  inner join [qp_hr_TikuLb] as [D] on [A].[MingchengID] = [D].[Id] where MingchengID='" + base.Request.QueryString["MingchengID"] + "'";
            string sql = "" + str + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
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
                this.DataBindToGridview(this.SortText.Value);
            }
        }
    }
}

