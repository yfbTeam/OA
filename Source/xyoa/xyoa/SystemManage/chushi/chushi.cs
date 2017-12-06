namespace xyoa.SystemManage.chushi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class chushi : Page
    {
        protected DropDownList Biaotilan;
        protected Button Button1;
        protected HtmlForm form1;
        protected DropDownList Gongzuotai;
        protected HtmlHead Head1;
        protected DropDownList iftx;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Mokuai;
        protected TextBox MokuaiID;
        private publics pulicss = new publics();
        protected DropDownList Sound;
        protected DropDownList txtime;
        protected DropDownList Yangshi;

        public void BindAttribute()
        {
            this.Mokuai.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_Chushihua  Set MokuaiID='" + this.MokuaiID.Text + "',Mokuai='" + this.Mokuai.Text + "',Biaotilan='" + this.Biaotilan.SelectedValue + "',Gongzuotai='" + this.Gongzuotai.SelectedValue + "',Yangshi='" + this.Yangshi.SelectedValue + "',iftx='" + this.iftx.SelectedValue + "',txtime='" + this.txtime.SelectedValue + "',Sound='" + this.Sound.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置用户初始化", "用户初始化");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='chushi.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select geturl,name from qp_oa_SysBg order by id asc";
                this.list.Bind_DropDownList_nothing(this.Gongzuotai, sQL, "geturl", "name");
                string sql = "select * from qp_oa_Chushihua";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Yangshi.SelectedValue = list["Yangshi"].ToString();
                    this.iftx.SelectedValue = list["iftx"].ToString();
                    this.txtime.SelectedValue = list["txtime"].ToString();
                    this.Sound.SelectedValue = list["Sound"].ToString();
                    this.Gongzuotai.SelectedValue = list["Gongzuotai"].ToString();
                    this.Biaotilan.SelectedValue = list["Biaotilan"].ToString();
                    this.MokuaiID.Text = list["MokuaiID"].ToString();
                    this.Mokuai.Text = list["Mokuai"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

