namespace xyoa.HumanResources.Hetong.HetongMB
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongMB_add_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private Db List = new Db();
        private publics pulicss = new publics();
        public string showtitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sql = "select id from qp_hr_HetongZd where LeibieID='" + base.Request.QueryString["LeibieID"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.showtitle = "";
                }
                else
                {
                    this.showtitle = "无相关字段";
                }
                list.Close();
                this.Label1.Text = null;
                string str2 = "select * from qp_hr_HetongZd where LeibieID='" + base.Request.QueryString["LeibieID"] + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    string text;
                    if (reader2["Leixing"].ToString() == "1")
                    {
                        text = this.Label1.Text;
                        this.Label1.Text = text + "<input id=\"Button2\" onclick=\"window.parent.nextrform.FCKeditorAPI.GetInstance('Neirong').InsertHtml('<input id=" + reader2["Bianhao"].ToString() + "  name=" + reader2["Bianhao"].ToString() + "  type=text class=mbcss  style=mbcss disabled=disabled/>');\" style=\"width: 120px\" type=\"button\" value=\"" + reader2["Mingcheng"].ToString() + "\" /><br><br>";
                    }
                    if (reader2["Leixing"].ToString() == "2")
                    {
                        text = this.Label1.Text;
                        this.Label1.Text = text + "<input id=\"Button14\" onclick=\"window.parent.nextrform.FCKeditorAPI.GetInstance('Neirong').InsertHtml('<textarea id=" + reader2["Bianhao"].ToString() + " name=" + reader2["Bianhao"].ToString() + " cols=20 rows=2 disabled=disabled></textarea>');\" style=\"width: 120px\" type=\"button\" value=\"" + reader2["Mingcheng"].ToString() + "\" /><br><br>";
                    }
                }
                reader2.Close();
            }
        }
    }
}

