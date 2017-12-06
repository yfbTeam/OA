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

    public class WorkFlowList_show : Page
    {
        protected HtmlInputButton Button10;
        protected HtmlInputButton Button14;
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
        public string IfZb;
        public string JbHuitui;
        public string JbQuanxian;
        public string JcZhuanjiao;
        protected Label JinJiChengDu;
        public int LcNameId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        public int lshid;
        public string NodeId;
        public string NodeName;
        protected TextBox Number;
        public string Numbers;
        private publics pulicss = new publics();
        public string SecFileID;
        private divform showform = new divform();
        public string ShuXing;
        protected TextBox TextBox1;
        public string UpNodeNum;
        public string UpNodeNumKey;
        public string UpNodeNums;
        protected TextBox whendname;
        protected TextBox whname;
        protected Label whname1;
        protected TextBox whstartname;
        public string WriteFileID;
        public string YijianJb;
        public string YijianZb;
        public string YzSealNumber;
        public string ZbHuitui;
        public string ZbQuanxian;
        public string ZbZhuanjiao;

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
                string sql = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ZbQuanxian = list["ZbQuanxian"].ToString();
                    this.JbQuanxian = list["JbQuanxian"].ToString();
                    this.YijianZb = list["YijianZb"].ToString();
                    this.YijianJb = list["YijianJb"].ToString();
                    this.ZbHuitui = list["ZbHuitui"].ToString();
                    this.JbHuitui = list["JbHuitui"].ToString();
                    this.JcZhuanjiao = list["JcZhuanjiao"].ToString();
                    this.ZbZhuanjiao = list["ZbZhuanjiao"].ToString();
                    this.NodeName = list["NodeName"].ToString();
                    this.UpNodeNum = list["UpNodeNum"].ToString();
                    this.UpNodeNumKey = list["UpNodeNum"].ToString();
                    this.GqUpNodeNumKey.Text = list["UpNodeNum"].ToString();
                    this.NodeId = list["id"].ToString();
                    this.WriteFileID = "" + list["WriteFileID"].ToString() + "0";
                    this.SecFileID = "" + list["SecFileID"].ToString() + "0";
                    string str2 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader2["JinJiChengDu"].ToString());
                        string str3 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", reader2["UpNodeNum"], "'" });
                        SqlDataReader reader3 = this.List.GetList(str3);
                        if (reader3.Read())
                        {
                            this.IfZb = reader3["IfZb"].ToString();
                        }
                        else
                        {
                            base.Response.Write("<script language=javascript>alert('未找到相关信息！');window.location = '/main_d.aspx'</script>");
                            return;
                        }
                        reader3.Close();
                        this.whname1.Text = reader2["Name"].ToString();
                        this.whname.Text = reader2["Name"].ToString();
                        this.ShuXing = reader2["ShuXing"].ToString();
                        this.lshid = int.Parse(reader2["Sequence"].ToString());
                        this.Number.Text = reader2["Number"].ToString();
                        this.Numbers = reader2["Number"].ToString();
                        this.UpNodeNums = reader2["UpNodeNum"].ToString();
                        if (this.IfZb == "主办")
                        {
                            this.whname1.Visible = true;
                            this.whname.Visible = false;
                            this.whstartname.Visible = false;
                            this.whendname.Visible = false;
                            if (this.YijianZb == "4")
                            {
                                this.Button8.Visible = false;
                            }
                            else
                            {
                                this.Button8.Visible = true;
                            }
                            this.pulicss.QuanXianVis(this.Button5, "2,", this.ZbQuanxian);
                            this.pulicss.QuanXianVis(this.Button7, "12,", this.ZbQuanxian);
                            this.pulicss.QuanXianVis(this.Button10, "7,", this.ZbQuanxian);
                            this.FormName = reader2["FormName"].ToString();
                            this.FormNumber = reader2["FormNumber"].ToString();
                            this.ContractContent.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                            this.TextBox1.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                        }
                        else
                        {
                            this.whname1.Visible = true;
                            this.whname.Visible = false;
                            this.whstartname.Visible = false;
                            this.whendname.Visible = false;
                            if (this.YijianJb == "4")
                            {
                                this.Button8.Visible = false;
                            }
                            else
                            {
                                this.Button8.Visible = true;
                            }
                            this.pulicss.QuanXianVis(this.Button5, "2,", this.JbQuanxian);
                            this.pulicss.QuanXianVis(this.Button7, "12,", this.JbQuanxian);
                            this.pulicss.QuanXianVis(this.Button10, "7,", this.JbQuanxian);
                            this.FormName = reader2["FormName"].ToString();
                            this.FormNumber = reader2["FormNumber"].ToString();
                            this.ContractContent.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                            this.TextBox1.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                        }
                        this.showform.AddWorkFlowLog("110", this.Number.Text, this.FormName, this.NodeName, "查看工作" + this.whstartname.Text + "" + this.whname.Text + "" + this.whendname.Text + "", this.IfZb);
                    }
                    reader2.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到此流程，有可能此流程已被删除！');window.close();</script>");
                    return;
                }
                list.Close();
                this.YzSealNumber = this.Number.Text;
                this.BindFjlbList();
            }
        }
    }
}

