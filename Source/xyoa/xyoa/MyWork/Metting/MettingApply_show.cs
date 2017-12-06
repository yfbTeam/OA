namespace xyoa.MyWork.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingApply_show : Page
    {
        protected Label _Label;
        protected Button Button1;
        protected Button Button3;
        protected Button Button6;
        protected CheckBox CheckBox2;
        protected Label CjRealname;
        protected Label Endtime;
        protected HtmlForm form1;
        protected Label fujian;
        protected TextBox GlNum;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Introduction;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MettingName;
        protected Label Name;
        protected Label NbPeopleName;
        protected TextBox NbPeopleUser;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Remark;
        protected Label Starttime;
        protected Label State;
        protected TextBox taolun;
        protected HtmlInputFile uploadFile;
        protected Label WbPeople;
        protected HtmlInputHidden YjbNodeId;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('6','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["back"].ToString() == "1")
            {
                base.Response.Redirect("MyMetting.aspx");
            }
            if (base.Request.QueryString["back"].ToString() == "2")
            {
                base.Response.Redirect("MyMettingYcy.aspx");
            }
            if (base.Request.QueryString["back"].ToString() == "3")
            {
                base.Response.Redirect("MyMettingWcy.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/OfficeMenu/Metting/file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                }
                else if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                }
                else
                {
                    Random random = new Random();
                    string str7 = random.Next(0x2710).ToString();
                    str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                    this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string filetype = this.pulicss.Getfiletype(extension);
                    string sql = string.Concat(new object[] { "insert into qp_oa_MettingApplyJy (Keyid,NewName,Name,username,realname,settime,filetype) values ('", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "','OfficeMenu/Metting/file/", str2, "','", fileName, "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "','", filetype, "')" });
                    this.List.ExeSql(sql);
                    this.Fujian();
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "我的会议");
                }
            }
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='6'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='6' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView1.DataBind();
        }

        public void Fujian()
        {
            string sql = "select  * from qp_oa_MettingApplyJy where Keyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            this._Label.Text = null;
            int num = 0;
            this._Label.Text = this._Label.Text + "<table width=100% border=0 cellspacing=0 cellpadding=4>";
            this._Label.Text = this._Label.Text + "<tr>";
            while (list.Read())
            {
                string text = this._Label.Text;
                this._Label.Text = text + " <td width=100% ><img src=\"/oaimg/filetype/" + list["filetype"].ToString() + ".gif\" align=\"baseline\"/> <a href=/huiyi_down.aspx?number=" + list["NewName"].ToString() + "  target=_blank>" + list["Name"].ToString() + "</a>&nbsp;&nbsp;&nbsp;(" + list["realname"].ToString() + "→" + list["settime"].ToString() + ")</td>";
                num++;
                if (num == 1)
                {
                    this._Label.Text = this._Label.Text + "</tr><TR>";
                    num = 0;
                }
            }
            this._Label.Text = this._Label.Text + " </table>";
            list.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "Delete from qp_oa_Taolun where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                Label label = (Label) e.Row.FindControl("FTUsername");
                if ((label.Text == this.Session["username"].ToString()) || (this.Session["username"].ToString() == "admin"))
                {
                    button.Visible = true;
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除此条讨论记录吗？')");
                }
                else
                {
                    button.Visible = false;
                }
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
                string sql = "select * from qp_oa_MettingApply   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CjRealname.Text = list["CjRealname"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.Introduction.Text = this.pulicss.TbToLb(list["Introduction"].ToString());
                    this.WbPeople.Text = list["WbPeople"].ToString();
                    this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                    this.NbPeopleName.Text = list["NbPeopleName"].ToString();
                    this.MettingName.Text = list["MettingName"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.pulicss.GetFile(this.Number.Text, this.fujian);
                    this.State.Text = list["State"].ToString().Replace("6", "通过审批").Replace("1", "正在审批").Replace("2", "已发起").Replace("3", "进行中").Replace("4", "结束").Replace("5", "终止");
                }
                list.Close();
                this.DataBindToGridview();
                this.Fujian();
            }
        }
    }
}

