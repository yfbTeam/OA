namespace xyoa.MyWork.MySet
{
    using Ajax;
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using xyoa;

    public class MokuaiMh_show : Page
    {
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected TextBox TextBox1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                object obj2;
                string str = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
                string sql = string.Concat(new object[] { "select count(A.id) from [qp_oa_MyUrl] as [A] where Username='", this.Session["username"], "' and A.menhu='", base.Request.QueryString["menhu"], "'" });
                this.TextBox1.Text = "" + this.List.GetCount(sql) + "";
                string str3 = string.Concat(new object[] { "select top 1 Paixun from qp_oa_MyUrl as [A] where Username='", this.Session["username"], "' and A.menhu='", base.Request.QueryString["menhu"], "' order by Paixun desc" });
                SqlDataReader list = this.List.GetList(str3);
                if (list.Read())
                {
                    int num = int.Parse(list["Paixun"].ToString()) + 1;
                    this.Paixun.Text = "" + num + "";
                }
                list.Close();
                string str4 = null;
                string str5 = "select [keyid] from [qp_oa_MyUrl] where Username='" + this.Session["username"] + "' and leixing='3'";
                SqlDataReader reader2 = this.List.GetList(str5);
                while (reader2.Read())
                {
                    obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, "", reader2["keyid"], "," });
                }
                reader2.Close();
                str4 = str4 + "0";
                this.ViewState["myurl"] = "";
                string str6 = string.Concat(new object[] { "select * from qp_oa_Menhu where ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) and id not in (", str4, ")  order by Paixun asc" });
                SqlDataReader reader3 = this.List.GetList(str6);
                while (reader3.Read())
                {
                    StateBag bag = ViewState;
                    obj2 = bag["myurl"];
                    (bag = this.ViewState)["myurl"] = string.Concat(new object[] { 
                        obj2, "<li onclick=\"addWin('mhkeyid", reader3["id"], "91221','", reader3["id"], "','", reader3["name"], "','/JqMain/Main.aspx?p=12&id=", reader3["id"], "','0','1','", reader3["pic"], "')\" id=\"mhkeyid", reader3["id"], "\"><img src=\"/Images/desktopIOC/", reader3["pic"], "\"/><br />", 
                        reader3["name"], "</li>"
                     });
                }
                reader3.Close();
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            }
        }
    }
}

