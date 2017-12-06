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

    public class Mokuai_show : Page
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
                string sql = string.Concat(new object[] { "select count(A.id) from [qp_oa_MyUrl] as [A] inner join [qp_oa_AllUrl] as [B] on [A].[KeyId] = [B].[Id] and (CHARINDEX(''+B.quanxian+'','", str, "')   >   0 )   and B.xianshi='1' and Username='", this.Session["username"], "' and A.menhu='", base.Request.QueryString["menhu"], "'" });
                this.TextBox1.Text = "" + this.List.GetCount(sql) + "";
                string str3 = string.Concat(new object[] { "select top 1 Paixun from qp_oa_MyUrl as [A] inner join [qp_oa_AllUrl] as [B] on [A].[KeyId] = [B].[Id] and (CHARINDEX(''+B.quanxian+'','", str, "')   >   0 )   and B.xianshi='1' and Username='", this.Session["username"], "' and A.menhu='", base.Request.QueryString["menhu"], "' order by Paixun desc" });
                SqlDataReader list = this.List.GetList(str3);
                if (list.Read())
                {
                    int num = int.Parse(list["Paixun"].ToString()) + 1;
                    this.Paixun.Text = "" + num + "";
                }
                list.Close();
                string str4 = null;
                string str5 = "select [keyid] from [qp_oa_MyUrl] where Username='" + this.Session["username"] + "'";
                SqlDataReader reader2 = this.List.GetList(str5);
                while (reader2.Read())
                {
                    obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, "", reader2["keyid"], "," });
                }
                reader2.Close();
                str4 = str4 + "0";
                this.ViewState["myurl"] = "";
                string str6 = "select [id],[urlname],bigpic,url,openkey,chuangzhi,bigpic from [qp_oa_AllUrl] where (CHARINDEX(''+quanxian+'','" + str + "')   >   0 ) and xianshi='1' and leixing='" + base.Request.QueryString["id"] + "' and id not in (" + str4 + ")  order by paixu asc";
                SqlDataReader reader3 = this.List.GetList(str6);
                while (reader3.Read())
                {
                    StateBag bag = ViewState;
                    obj2 = bag["myurl"];
                    (bag = this.ViewState)["myurl"] = string.Concat(new object[] { 
                        obj2, "<li onclick=\"addWin('keyid", reader3["id"], "','", reader3["id"], "','", reader3["urlname"], "','", reader3["url"], "','", reader3["openkey"], "','", reader3["chuangzhi"], "','", reader3["bigpic"], "')\" id=\"keyid", 
                        reader3["id"], "\"><img src=\"/Images/desktopIOC/", reader3["bigpic"], "\"/><br />", reader3["urlname"], "</li>"
                     });
                }
                reader3.Close();
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            }
        }
    }
}

