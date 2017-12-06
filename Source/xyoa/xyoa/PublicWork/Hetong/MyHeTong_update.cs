namespace xyoa.PublicWork.Hetong
{
    using FredCK.FCKeditorV2;
    using qiupeng.crm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyHeTong_update : Page
    {
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected TextBox Danwei;
        protected TextBox Daoqi;
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        protected DropDownList Fenlei;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Hetonghao;
        protected TextBox Jine;
        protected Label Label1;
        protected TextBox LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected HtmlInputHidden NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Qianyue;
        protected DropDownList Qixian;
        protected HtmlInputFile uploadFile;
        protected HtmlInputHidden YjbNodeId;
        protected RadioButtonList Zhuangtai;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.LcZhuangtai.Attributes.Add("readonly", "readonly");
            this.Button6.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindDroList()
        {
            string sQL = "select * from qp_oa_HetongLb";
            this.list.Bind_DropDownList_kong(this.Fenlei, sQL, "id", "Name");
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyHetong.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("hetong/");
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
                    this.pulicss.Insertfile(fileName, "PublicWork/Hetong/hetong/" + str2 + "", this.Number.Text, filetype);
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_HeTong   Set Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), "',Hetonghao='", this.pulicss.GetFormatStr(this.Hetonghao.Text), "',Jine='", this.Jine.Text, "',Danwei='", this.pulicss.GetFormatStr(this.Danwei.Text), "',Fenlei='", this.Fenlei.SelectedValue, "',Zhuangtai='", this.pulicss.GetFormatStr(this.Zhuangtai.SelectedValue), "',Qianyue='", this.pulicss.GetFormatStr(this.Qianyue.Text), 
                "',Qixian='", this.Qixian.SelectedValue, "',Daoqi='", this.pulicss.GetFormatStr(this.Daoqi.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改合同[" + this.Zhuti.Text + "]", "我的合同");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyHetong.aspx'</script>");
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
                    this.BindDroList();
                    this.BindAttribute();
                    string sql = "select * from qp_oa_HeTong   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                        this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                        this.ViewState["FormId"] = list["FormId"].ToString();
                        this.Number.Text = list["Number"].ToString();
                        this.Zhuti.Text = list["Zhuti"].ToString();
                        this.Neirong.Value = list["Neirong"].ToString();
                        this.Hetonghao.Text = list["Hetonghao"].ToString();
                        this.Jine.Text = list["Jine"].ToString();
                        this.Danwei.Text = list["Danwei"].ToString();
                        this.Fenlei.SelectedValue = list["Fenlei"].ToString();
                        this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                        this.Qianyue.Text = DateTime.Parse(list["Qianyue"].ToString()).ToShortDateString();
                        this.Qixian.SelectedValue = list["Qixian"].ToString();
                        this.Daoqi.Text = DateTime.Parse(list["Daoqi"].ToString()).ToShortDateString();
                        this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                        if ((list["LcZhuangtai"].ToString() == "1") || (list["LcZhuangtai"].ToString() == "4"))
                        {
                            this.Button6.Visible = true;
                            this.Button3.Visible = true;
                            this.Button4.Visible = true;
                            this.Button12.Visible = true;
                        }
                        else
                        {
                            this.Label1.Text = "当前状态不允许修改";
                            this.Button6.Visible = false;
                            this.Button3.Visible = false;
                            this.Button4.Visible = false;
                            this.Button12.Visible = false;
                        }
                    }
                    list.Close();
                }
                this.BindFjlbList();
            }
        }
    }
}

