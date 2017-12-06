namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WebDiskLx_qx_update : Page
    {
        protected DropDownList BLiulang;
        protected DropDownList BShanchu;
        protected Button Button2;
        protected DropDownList BXinzeng;
        protected DropDownList BXiugai;
        protected DropDownList FLiulang;
        protected HtmlForm Form1;
        protected DropDownList FQuanXian;
        protected DropDownList FShanchu;
        protected DropDownList FXinzeng;
        protected DropDownList FXiugai;
        private Db List = new Db();
        protected TextBox name;
        protected DropDownList PiZhu;
        private publics pulicss = new publics();
        protected DropDownList RiZhi;

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_WebDiskLxQx  Set  FLiulang='", this.FLiulang.SelectedValue, "',FXinzeng='", this.FXinzeng.SelectedValue, "',FXiugai='", this.FXiugai.SelectedValue, "',FShanchu='", this.FShanchu.SelectedValue, "',FQuanXian='", this.FQuanXian.SelectedValue, "',name='", this.pulicss.GetFormatStr(this.name.Text), "',BLiulang='", this.BLiulang.SelectedValue, "',PiZhu='", this.PiZhu.SelectedValue, 
                "',RiZhi='", this.RiZhi.SelectedValue, "',BXinzeng='", this.BXinzeng.SelectedValue, "',BXiugai='", this.BXiugai.SelectedValue, "',BShanchu='", this.BShanchu.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改硬盘目录权限", "网络硬盘目录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.name.Attributes.Add("readonly", "readonly");
                string sql = "select * from qp_oa_WebDiskLxQx  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.name.Text = list["name"].ToString();
                    this.BLiulang.SelectedValue = list["BLiulang"].ToString();
                    this.PiZhu.SelectedValue = list["PiZhu"].ToString();
                    this.RiZhi.SelectedValue = list["RiZhi"].ToString();
                    this.BXinzeng.SelectedValue = list["BXinzeng"].ToString();
                    this.BXiugai.SelectedValue = list["BXiugai"].ToString();
                    this.BShanchu.SelectedValue = list["BShanchu"].ToString();
                    this.FLiulang.SelectedValue = list["FLiulang"].ToString();
                    this.FXinzeng.SelectedValue = list["FXinzeng"].ToString();
                    this.FXiugai.SelectedValue = list["FXiugai"].ToString();
                    this.FShanchu.SelectedValue = list["FShanchu"].ToString();
                    this.FQuanXian.SelectedValue = list["FQuanXian"].ToString();
                }
                list.Close();
            }
        }
    }
}

