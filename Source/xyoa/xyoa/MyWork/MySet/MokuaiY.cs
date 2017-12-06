namespace xyoa.MyWork.MySet
{
    using Ajax;
    using qiupeng.form;
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using xyoa;

    public class MokuaiY : Page
    {
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        private divform showform = new divform();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string str = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
                this.ViewState["myurl"] = "";
                string sql = string.Concat(new object[] { "select A.* from [qp_oa_MyUrl] as [A] where Username='", this.Session["username"], "' and A.menhu='", base.Request.QueryString["menhu"], "'  order by A.paixun desc" });
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    StateBag bag = ViewState;
                    object obj2;
                    if (list["leixing"].ToString() == "1")
                    {
                        string str3 = string.Concat(new object[] { "select B.[urlname], B.[url], B.[chuangzhi], B.[bigpic], B.[openkey], B.[id] as Bid from qp_oa_AllUrl as [B] where  [B].[Id]='", list["keyid"], "' and (CHARINDEX(''+B.quanxian+'','", str, "')   >   0 )   and B.xianshi='1'" });
                        SqlDataReader reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            obj2 = bag["myurl"];
                            (bag = this.ViewState)["myurl"] = string.Concat(new object[] { obj2, "<li  onclick=\"delWin('", list["id"], "','", reader2["Bid"], "')\" id=\"keyid", list["id"], "\"><img src=\"/Images/desktopIOC/", reader2["bigpic"], "\"/><br />", reader2["urlname"], "</li>" });
                        }
                        reader2.Close();
                    }
                    else if (list["leixing"].ToString() == "2")
                    {
                        string str4 = string.Concat(new object[] { "select B.[name], B.[urlname], B.[pic], B.[id] as Bid from qp_oa_OtherMenu as [B] where  [B].[Id]='", list["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                        SqlDataReader reader3 = this.List.GetList(str4);
                        if (reader3.Read())
                        {
                            obj2 = bag["myurl"];
                            (bag = this.ViewState)["myurl"] = string.Concat(new object[] { obj2, "<li  onclick=\"delWin1('", list["id"], "','", reader3["Bid"], "')\" id=\"keyid", list["id"], "\"><img src=\"/Images/desktopIOC/", reader3["pic"], "\"/><br />", reader3["name"], "</li>" });
                        }
                        reader3.Close();
                    }
                    else if (list["leixing"].ToString() == "3")
                    {
                        string str5 = string.Concat(new object[] { "select B.[name], B.[pic], B.[id] as Bid from qp_oa_Menhu as [B] where  [B].[Id]='", list["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                        SqlDataReader reader4 = this.List.GetList(str5);
                        if (reader4.Read())
                        {
                            obj2 = bag["myurl"];
                            (bag = this.ViewState)["myurl"] = string.Concat(new object[] { obj2, "<li onclick=\"delWin2('", list["id"], "','", reader4["Bid"], "')\" id=\"keyid", list["id"], "\"><img src=\"/Images/desktopIOC/", reader4["pic"], "\"/><br />", reader4["name"], "</li>" });
                        }
                        reader4.Close();
                    }
                }
                list.Close();
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            }
        }
    }
}

