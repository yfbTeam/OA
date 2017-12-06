namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WebDiskLx_qxry_add : Page
    {
        protected DropDownList BLiulang;
        protected DropDownList BShanchu;
        protected DropDownList BuMenId;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected Button Button7;
        protected Button Button8;
        protected DropDownList BXinzeng;
        protected DropDownList BXiugai;
        protected DropDownList FLiulang;
        protected HtmlForm Form1;
        protected DropDownList FQuanXian;
        protected DropDownList FShanchu;
        protected DropDownList FXinzeng;
        protected DropDownList FXiugai;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MyUserList;
        protected DropDownList PiZhu;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox requeststr;
        protected DropDownList RiZhi;
        protected ListBox SourceListBox;
        protected ListBox TargetListBox;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected DropDownList Zhiweiid;

        protected void Button1_Click(object sender, EventArgs e)
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.TargetListBox.Items.Count - 1); i++)
            {
                string sql = "select nameid from qp_oa_WebDiskLxQx  where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]) + "' and Types='3' and  nameid='" + this.TargetListBox.Items[i].Value + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    string str2 = "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('" + this.TargetListBox.Items[i].Text + "','" + this.TargetListBox.Items[i].Value + "','" + this.FLiulang.SelectedValue + "','" + this.FXinzeng.SelectedValue + "','" + this.FXiugai.SelectedValue + "','" + this.FShanchu.SelectedValue + "','" + this.FQuanXian.SelectedValue + "','" + this.BLiulang.SelectedValue + "','" + this.BXinzeng.SelectedValue + "','" + this.BXiugai.SelectedValue + "','" + this.BShanchu.SelectedValue + "','" + base.Request.QueryString["keyid"] + "','3','" + this.PiZhu.SelectedValue + "','" + this.RiZhi.SelectedValue + "')";
                    this.List.ExeSql(str2);
                }
                list.Close();
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
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

        protected void Button4_Click1(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by id desc", this.CreateMidSql());
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

        public string CreateMidSql()
        {
            string str4;
            string str = string.Empty;
            if (this.Realname.Text != "")
            {
                str = str + " and Realname like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.Realname.Text)) + "%'";
            }
            if (this.JueseId.SelectedValue != "")
            {
                str = str + " and JueseId = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.JueseId.SelectedValue)) + "'";
            }
            if (this.Zhiweiid.SelectedValue != "")
            {
                str = str + " and Zhiweiid = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.Zhiweiid.SelectedValue)) + "'";
            }
            if (this.BuMenId.SelectedValue != "")
            {
                str = str + " and BuMenId = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.BuMenId.SelectedValue)) + "'";
            }
            if (this.MyUserList.SelectedValue != "")
            {
                string str2 = null;
                string str3 = null;
                str4 = null;
                string sql = "select GlUsername from qp_oa_MyUserList where id='" + this.MyUserList.SelectedValue + "'";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    str3 = "" + reader["GlUsername"].ToString() + "";
                    ArrayList list = new ArrayList();
                    string[] strArray = str3.Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        str2 = str2 + "'" + strArray[i] + "',";
                    }
                    str2 = str2 + "'0'";
                }
                else
                {
                    str2 = "'0'";
                }
                reader.Close();
                str4 = " and username in (" + str2 + ")";
                return (str + str4);
            }
            str4 = null;
            str4 = "";
            return (str + str4);
        }

        public void DataBindToGridview(string Sqlsort, string Sqlstr)
        {
            string sQL = ("select username, Realname  from qp_oa_username  where 1=1 and  ifdel='0'  and username not in (" + this.ViewState["strsql"] + ")") + Sqlstr;
            this.list.Bind_DropDownList_ListBox(this.SourceListBox, sQL, "Username", "Realname");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                StateBag bag = ViewState;
                this.ViewState["strsql"] = "";
                string sql = "select nameid from qp_oa_WebDiskLxQx  where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]) + "' and Types='3'";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    object obj2 = bag["strsql"];
                    (bag = this.ViewState)["strsql"] = string.Concat(new object[] { obj2, "'", list["nameid"].ToString(), "'," });
                }
                list.Close();
                (bag = this.ViewState)["strsql"] = bag["strsql"] + "'0'";
                this.pulicss.BindListkong("qp_oa_Bumen", this.BuMenId, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiweiid, sQL, "id", "name");
                string str3 = "select id,name  from qp_oa_Juese order by id asc";
                this.list.Bind_DropDownList_kong(this.JueseId, str3, "id", "name");
                string str4 = "select id,Name  from qp_oa_MyUserList where username='" + this.Session["username"] + "' order by Paixun asc";
                this.list.Bind_DropDownList_kong(this.MyUserList, str4, "id", "Name");
                this.DataBindToGridview("order by id desc", this.CreateMidSql());
            }
        }
    }
}

