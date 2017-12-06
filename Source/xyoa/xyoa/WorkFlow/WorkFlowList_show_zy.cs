namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowList_show_zy : Page
    {
        protected HtmlInputButton Button10;
        protected HtmlInputButton Button14;
        protected HtmlInputButton Button16;
        protected HtmlInputButton Button5;
        protected HtmlInputButton Button7;
        protected HtmlInputButton Button8;
        protected TextBox ContractContent;
        public string ddstr;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        public string FormName;
        public string FormNumber;
        protected TextBox GqUpNodeNumKey;
        protected HtmlHead Head1;
        protected Label JinJiChengDu;
        public int LcNameId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        public int lshid;
        protected TextBox Number;
        public string Numbers;
        private publics pulicss = new publics();
        private divform showform = new divform();
        public string ShuXing;
        protected TextBox TextBox1;
        public string UpNodeNum;
        public string UpNodeNums;
        protected TextBox whname;
        public string YijianJb;
        public string YijianZb;
        public string YzSealNumber;

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    string sql = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", list["JinJiChengDu"].ToString());
                        this.whname.Text = list["Name"].ToString();
                        this.ShuXing = list["ShuXing"].ToString();
                        this.lshid = int.Parse(list["Sequence"].ToString());
                        this.Number.Text = list["Number"].ToString();
                        this.Numbers = list["Number"].ToString();
                        this.UpNodeNums = list["UpNodeNum"].ToString();
                        this.FormName = list["FormName"].ToString();
                        this.FormNumber = list["FormNumber"].ToString();
                        this.ContractContent.Text = this.showform.FormatKjStrZh(list["FileContent"].ToString());
                        this.TextBox1.Text = this.showform.FormatKjStrZh(list["FileContent"].ToString());
                        this.GqUpNodeNumKey.Text = list["UpNodeNum"].ToString();
                    }
                    list.Close();
                    this.showform.AddWorkFlowLog("110", this.Number.Text, this.FormName, "自由流程", "查看工作" + this.whname.Text + "", "主办");
                    this.YzSealNumber = this.Number.Text;
                }
                this.BindFjlbList();
            }
        }
    }
}

