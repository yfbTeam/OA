namespace xyoa.JqMain
{
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyLmUrl : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected ListBox SourceListBox;
        protected ListBox TargetListBox;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            string str3 = null;
            for (int i = 0; i <= (this.TargetListBox.Items.Count - 1); i++)
            {
                str2 = "" + this.TargetListBox.Items[i].Value + ",";
                str3 = str2.Remove(str2.LastIndexOf(","), 1);
                ArrayList list = new ArrayList();
                string[] strArray = str3.Split(new char[] { ',' });
                for (int j = 0; j < strArray.Length; j++)
                {
                    list.Add(strArray[j].ToString());
                    str = str + "" + strArray[j] + ",";
                }
            }
            string sql = string.Concat(new object[] { "select id from  [qp_oa_MyLmUrl] where  leixing='", base.Request.QueryString["leixing"], "' and Username='", this.Session["username"], "'" });
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                string str5 = string.Concat(new object[] { "Update qp_oa_MyLmUrl  Set UrlId='", str, "' where leixing='", base.Request.QueryString["leixing"], "' and Username='", this.Session["username"], "'" });
                this.List.ExeSql(str5);
            }
            else
            {
                string str6 = string.Concat(new object[] { "insert into qp_oa_MyLmUrl (Leixing,Username,UrlId) values ('", base.Request.QueryString["leixing"], "','", this.Session["Username"], "','", str, "')" });
                this.List.ExeSql(str6);
            }
            reader.Close();
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            int num = 0;
            while (num <= (this.SourceListBox.Items.Count - 1))
            {
                if (this.SourceListBox.Items[num].Selected)
                {
                    if (this.TargetListBox.Items.IndexOf(this.SourceListBox.Items[num]) >= 0)
                    {
                        base.Response.Write("<script language=javascript>alert('此项已经存在！');</script>");
                        break;
                    }
                    this.TargetListBox.Items.Add(new ListItem(this.SourceListBox.Items[num].Text, this.SourceListBox.Items[num].Value));
                    this.SourceListBox.Items.Remove(this.SourceListBox.Items[num]);
                }
                else
                {
                    num++;
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int num = 0;
            while (num <= (this.TargetListBox.Items.Count - 1))
            {
                if (this.TargetListBox.Items[num].Selected)
                {
                    this.SourceListBox.Items.Add(new ListItem(this.TargetListBox.Items[num].Text, this.TargetListBox.Items[num].Value));
                    this.TargetListBox.Items.Remove(this.TargetListBox.Items[num]);
                }
                else
                {
                    num++;
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (this.SourceListBox.Items.Count > 0)
            {
                foreach (ListItem item in this.SourceListBox.Items)
                {
                    this.TargetListBox.Items.Add(item);
                }
                this.SourceListBox.Items.Clear();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (this.TargetListBox.Items.Count > 0)
            {
                foreach (ListItem item in this.TargetListBox.Items)
                {
                    this.SourceListBox.Items.Add(item);
                }
                this.TargetListBox.Items.Clear();
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
                string str = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
                string str2 = "0,0";
                string sql = string.Concat(new object[] { "select UrlId from qp_oa_MyLmUrl  where leixing='", base.Request.QueryString["leixing"], "' and Username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    str2 = "" + list["UrlId"].ToString() + "0";
                }
                else
                {
                    str2 = "0,0";
                }
                list.Close();
                string sQL = "select * from qp_oa_AllUrl  where id not in (" + str2 + ") and (CHARINDEX(''+quanxian+'','" + str + "')   >   0 ) and leixing='" + base.Request.QueryString["leixing"] + "' and Kuaijie='1' and ParentNodesID!='0' and ifopen='1' order by paixu asc";
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, sQL, "id", "urlname");
                string str5 = "select * from qp_oa_AllUrl  where id in (" + str2 + ") and (CHARINDEX(''+quanxian+'','" + str + "')   >   0 ) and leixing='" + base.Request.QueryString["leixing"] + "' and Kuaijie='1' and ParentNodesID!='0' and ifopen='1' order by paixu asc";
                this.list.Bind_DropDownList_ListBox(this.TargetListBox, str5, "id", "urlname");
                this.BindAttribute();
            }
        }
    }
}

