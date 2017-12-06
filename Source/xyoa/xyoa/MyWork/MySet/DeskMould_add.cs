namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DeskMould_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox LookMuch;
        private publics pulicss = new publics();
        protected DropDownList UrlName;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num;
            string sql = "select top 1 PaiXun from qp_oa_DIYMould  where username='" + this.Session["username"] + "' order by paixun desc";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                num = int.Parse(list["PaiXun"].ToString());
            }
            else
            {
                num = 0;
            }
            list.Close();
            int num2 = num + 1;
            string str2 = string.Concat(new object[] { "insert into qp_oa_DIYMould  (Name,PaiXun,Username,Realname,LookMuch,KeyId) values ('", this.UrlName.SelectedItem.Text, "','", num2, "','", this.Session["username"], "','", this.Session["realname"], "','", this.LookMuch.Text, "','", this.UrlName.SelectedValue, "')" });
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("新增工作台[" + this.UrlName.SelectedItem.Text + "]", "工作台设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DeskMould.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("DeskMould.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_DIYMould where username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.LookMuch.Text = list["LookMuch"].ToString();
                }
                else
                {
                    this.LookMuch.Text = "4";
                }
                list.Close();
                string sQL = string.Concat(new object[] { "select A.id,A.urlname from [qp_oa_AllUrl] as [A] LEFT JOIN [qp_oa_DIYMould] as [B] on [A].[id] = [B].[KeyId] and [B].username='", this.Session["username"], "' where [B].name IS NULL and menhulm='1' and ParentNodesID!='0' and ifopen='1' and CHARINDEX(A.quanxian,'", this.Session["perstr"], "') > 0  group by  A.id,A.urlname,A.quanxian,A.paixu  order by A.paixu asc " });
                this.list.Bind_DropDownList_nothing(this.UrlName, sQL, "id", "urlname");
                this.BindAttribute();
            }
        }
    }
}

