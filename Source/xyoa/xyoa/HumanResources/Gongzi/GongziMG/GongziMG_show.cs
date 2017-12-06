namespace xyoa.HumanResources.Gongzi.GongziMG
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GongziMG_show : Page
    {
        protected Button Button1;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label EndTime;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList JieGuo;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected CheckBox NbSms;
        protected DropDownList normalcontent;
        protected Label NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected TextBox SpContent;
        protected Label SpRealname;
        protected Label SpRemark;
        protected TextBox SpUsername;
        protected Label StartTime;
        protected TextBox Username;
        protected Label Zhangtao;
        protected Label Zhuangtai;
        protected Label Zhuti;
        protected TextBox ZjRealname;
        protected TextBox ZjUsername;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (this.JieGuo.SelectedValue == "1")
            {
                string text;
                string str3;
                string str4;
                string str5;
                str = string.Concat(new object[] { "Update qp_hr_GongziSB  Set  SpUsername='通过审批',SpRealname='通过审批',Zhuangtai='2',SpRemark=SpRemark+'<b>审批人：</b>", this.Session["Realname"], "<br><b>审批结果：</b>", this.JieGuo.SelectedItem.Text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>审批时间：</b>", DateTime.Now.ToString(), "<br><b>审批意见：</b>", this.SpContent.Text, "<hr>',YspUsername=YspUsername+'", this.Session["Username"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                this.List.ExeSql(str);
                foreach (GridViewRow row in this.GridView1.Rows)
                {
                    text = ((Label) row.FindControl("LabUserName")).Text;
                    str3 = ((Label) row.FindControl("LabRealname")).Text;
                    str4 = ((Label) row.FindControl("Label2")).Text;
                    str5 = string.Concat(new object[] { "insert into qp_hr_GongziUser (Gzid,Zhuti,Neirong,Username,Realname,NowTimes) values ('", int.Parse(base.Request.QueryString["id"]), "','", this.Zhuti.Text, "','", this.pulicss.GetFormatStrbjq(str4), "','", text, "','", str3, "','", DateTime.Now.ToString(), "')" });
                    this.List.ExeSql(str5);
                }
                if (this.NbSms.Checked)
                {
                    foreach (GridViewRow row in this.GridView1.Rows)
                    {
                        text = ((Label) row.FindControl("LabUserName")).Text;
                        str3 = ((Label) row.FindControl("LabRealname")).Text;
                        str4 = ((Label) row.FindControl("Label1")).Text;
                        str5 = string.Concat(new object[] { 
                            "insert into qp_oa_NbEmail_sj  (Number,Titles,Content,JsUsername,JsRealname,IfRead,IfDel,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','[", str3, "]您的工资单请注意查收','", this.pulicss.GetFormatStrbjq(str4), "','", text, "','", str3, "','0','0','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                            "')"
                         });
                        this.List.ExeSql(str5);
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您有“工资单”内部邮件需要接收，工资主题：", this.Zhuti.Text, "，发送人：", this.Session["realname"], "" }), text, str3, "/InfoManage/nbemail/NbEmail_sj.aspx");
                        string sql = string.Concat(new object[] { 
                            "insert into qp_oa_NbEmail_fj  (Number,Titles,Content,JsUsername,JsRealname,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','[", str3, "]您的工资单请注意查收','", this.pulicss.GetFormatStrbjq(str4), "','", text, "','", str3, "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                            "')"
                         });
                        this.List.ExeSql(sql);
                    }
                }
                this.pulicss.InsertMessage(string.Concat(new object[] { "薪资上报(主题：", this.Zhuti.Text, ")已通过审批，审批人：", this.Session["realname"], "" }), this.Username.Text, this.Realname.Text, "/HumanResources/Gongzi/GongziSB/GongziSB.aspx?Zhuangtai=2");
            }
            if (this.JieGuo.SelectedValue == "2")
            {
                str = string.Concat(new object[] { 
                    "Update qp_hr_GongziSB  Set  SpUsername='", this.pulicss.GetFormatStr(this.ZjUsername.Text), "',SpRealname='", this.pulicss.GetFormatStr(this.ZjRealname.Text), "',SpRemark=SpRemark+'<b>审批人：</b>", this.Session["Realname"], "<br><b>审批结果：</b>", this.JieGuo.SelectedItem.Text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>审批时间：</b>", DateTime.Now.ToString(), "<br><b>审批意见：</b>", this.SpContent.Text, "<hr>',YspUsername=YspUsername+'", this.Session["Username"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), 
                    "' "
                 });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage(string.Concat(new object[] { "薪资上报(主题：", this.Zhuti.Text, ")已转交给[", this.ZjRealname.Text, "]审批，审批人：", this.Session["realname"], "" }), this.Username.Text, this.Realname.Text, "/HumanResources/Gongzi/GongziSB/GongziSB.aspx?Zhuangtai=1");
                this.pulicss.InsertMessage(string.Concat(new object[] { "您有薪资上报(主题：", this.Zhuti.Text, ")需要审批，转交人：", this.Session["realname"], "" }), this.ZjUsername.Text, this.ZjRealname.Text, "/HumanResources/Gongzi/GongziMG/GongziMG.aspx?Zhuangtai=1");
            }
            if (this.JieGuo.SelectedValue == "3")
            {
                str = string.Concat(new object[] { "Update qp_hr_GongziSB  Set  SpUsername='拒绝审批',SpRealname='拒绝审批',Zhuangtai='3',SpRemark=SpRemark+'<b>审批人：</b>", this.Session["Realname"], "<br><b>审批结果：</b>", this.JieGuo.SelectedItem.Text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>审批时间：</b>", DateTime.Now.ToString(), "<br><b>审批意见：</b>", this.SpContent.Text, "<hr>',YspUsername=YspUsername+'", this.Session["Username"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage(string.Concat(new object[] { "薪资上报(主题：", this.Zhuti.Text, ")已被拒绝审批，审批人：", this.Session["realname"], "" }), this.Username.Text, this.Realname.Text, "/HumanResources/Gongzi/GongziSB/GongziSB.aspx?Zhuangtai=3");
            }
            this.pulicss.InsertLog("审批薪资上报", "薪资管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='GongziMG.aspx?Zhuangtai=1'</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select * from hr_" + this.Number.Text + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label1");
                label.Text = null;
                Label label2 = (Label) e.Row.FindControl("Label2");
                label2.Text = null;
                label.Text = label.Text + "<table align='center' style='border-collapse: collapse' border='1' cellpadding='3'cellspacing='0' width='400px' bordercolor='#000000'>";
                int num = int.Parse(this.ViewState["CountFile"].ToString());
                for (int i = 1; i < num; i++)
                {
                    string text = label.Text;
                    label.Text = text + "<tr><td align='right' height='17' width='30%'>" + this.GridView1.HeaderRow.Cells[i].Text.ToString().Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("(", "").Replace(")", "") + "：</td><td height='17' colspan='3' width='70%'>" + e.Row.Cells[i].Text.ToString() + "</td></tr>";
                    text = label2.Text;
                    label2.Text = text + "" + this.GridView1.HeaderRow.Cells[i].Text.ToString().Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("(", "").Replace(")", "") + "：" + e.Row.Cells[i].Text.ToString() + "|";
                }
                label.Text = label.Text + "</table>";
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
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                this.ZjRealname.Attributes.Add("readonly", "readonly");
                this.pulicss.QuanXianBack("eeee7c", this.Session["perstr"].ToString());
                string sql = string.Concat(new object[] { "select * from qp_hr_GongziSB where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and SpUsername='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Zhuangtai"].ToString() == "4")
                    {
                        string str2 = "Update qp_hr_GongziSB  Set  Zhuangtai='1'  where id='" + int.Parse(base.Request.QueryString["id"]) + "' ";
                        this.List.ExeSql(str2);
                    }
                    this.Number.Text = list["Number"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Zhangtao.Text = this.divhr.TypeCode("Name", "qp_hr_GongziSZ", list["Zhangtao"].ToString());
                    this.StartTime.Text = DateTime.Parse(list["StartTime"].ToString()).ToShortDateString();
                    this.EndTime.Text = DateTime.Parse(list["EndTime"].ToString()).ToShortDateString();
                    this.SpUsername.Text = list["SpUsername"].ToString();
                    this.SpRemark.Text = list["SpRemark"].ToString();
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正在审批").Replace("2", "通过审批").Replace("3", "拒绝审批").Replace("4", "等待审批");
                    this.NowTimes.Text = list["NowTimes"].ToString();
                    this.SpRealname.Text = list["SpRealname"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Username.Text = list["Username"].ToString();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('无相关数据！');window.location.href='GongziMG.aspx?Zhuangtai=1'</script>");
                }
                list.Close();
                string str3 = "select   count(a.name)   from   syscolumns   a,sysobjects   b     where   a.id=b.id     and   b.name='hr_" + this.Number.Text + "'";
                int num = this.List.GetCount(str3) + 1;
                this.ViewState["CountFile"] = this.List.GetCount(str3) + 1;
                this.DataBindToGridview();
                try
                {
                    for (int i = 0; i < num; i++)
                    {
                        this.GridView1.HeaderRow.Cells[i].Text = this.GridView1.HeaderRow.Cells[i].Text.ToString().Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("(", "").Replace(")", "");
                    }
                }
                catch
                {
                }
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
            }
        }
    }
}

