namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WebDiskLx_qxbm_add : Page
    {
        protected DropDownList BLiulang;
        protected DropDownList BShanchu;
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected DropDownList BXinzeng;
        protected DropDownList BXiugai;
        protected DropDownList FLiulang;
        protected HtmlForm Form1;
        protected DropDownList FQuanXian;
        protected DropDownList FShanchu;
        protected DropDownList FXinzeng;
        protected DropDownList FXiugai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList PiZhu;
        private publics pulicss = new publics();
        protected TextBox requeststr;
        protected DropDownList RiZhi;
        protected ListBox SourceListBox;
        public string strlist;
        protected ListBox TargetListBox;
        protected TextBox TextBox1;
        protected TextBox TextBox2;

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
                string sql = "select nameid from qp_oa_WebDiskLxQx  where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]) + "' and Types='2' and  nameid='" + this.TargetListBox.Items[i].Value + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    string str2 = "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('" + this.TargetListBox.Items[i].Text.Replace("|", "").Replace("-", "") + "','" + this.TargetListBox.Items[i].Value + "','" + this.FLiulang.SelectedValue + "','" + this.FXinzeng.SelectedValue + "','" + this.FXiugai.SelectedValue + "','" + this.FShanchu.SelectedValue + "','" + this.FQuanXian.SelectedValue + "','" + this.BLiulang.SelectedValue + "','" + this.BXinzeng.SelectedValue + "','" + this.BXiugai.SelectedValue + "','" + this.BShanchu.SelectedValue + "','" + base.Request.QueryString["keyid"] + "','2','" + this.PiZhu.SelectedValue + "','" + this.RiZhi.SelectedValue + "')";
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
            if (!base.IsPostBack)
            {
                this.Button2.Attributes["onclick"] = "javascript:return checkbutton();";
                this.strlist = "";
                string sql = "select nameid from qp_oa_WebDiskLxQx  where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]) + "' and Types='2'";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    this.strlist = this.strlist + "" + list["nameid"].ToString() + ",";
                }
                list.Close();
                this.strlist = this.strlist + "0";
                this.SourceListBox.Items.Clear();
                this.pulicss.BindListListBox("qp_oa_Bumen", this.SourceListBox, "", "order by Bianhao asc");
            }
        }
    }
}

