namespace xyoa.HumanResources.Hetong.HetongMg
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongMg_update : Page
    {
        protected Button Button1;
        protected TextBox ContractContent;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox HetongZdId;
        protected Label LeibieID;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label QdTime;
        protected DropDownList Qixian;
        protected Label QyRealname;
        protected TextBox QyUsername;
        protected TextBox Starttime;
        protected TextBox TextBox1;
        protected Label Zhuangtai;

        public void BindAttribute()
        {
            this.pulicss.QuanXianBack("eeee3dc", this.Session["perstr"].ToString());
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.divhr.Insertlsz(base.Request.QueryString["id"].ToString(), "6", "HumanResources/Hetong/HetongMg/HetongMg_show_lsz.aspx?id=" + base.Request.QueryString["id"].ToString() + "");
            string sql = "delete from qp_hr_HetongMgFile where  HetongID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            string str2 = "select  * from qp_hr_HetongZd where LeibieID='" + this.HetongZdId.Text + "' order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                string str3 = string.Concat(new object[] { "insert into qp_hr_HetongMgFile (HetongID,ZdBianhao,Neirong) values ('", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "','", list["Bianhao"], "','", base.Request.Form["" + list["Bianhao"] + ""], "')" });
                this.List.ExeSql(str3);
            }
            list.Close();
            string str4 = string.Concat(new object[] { "Update qp_hr_HetongMg  Set Qixian='", this.Qixian.SelectedValue, "',Neirong='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(str4);
            this.pulicss.InsertLog("修改[" + this.QyRealname.Text + "]的[" + this.LeibieID.Text + "]", "合同管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='HetongMg.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                string sql = "select * from qp_hr_HetongMg where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Qixian.SelectedValue = list["Qixian"].ToString();
                    this.LeibieID.Text = this.divhr.TypeCode("Mingcheng", "qp_hr_HetongMB", list["LeibieID"].ToString());
                    this.QyRealname.Text = list["QyRealname"].ToString();
                    this.QyUsername.Text = list["QyUsername"].ToString();
                    this.Starttime.Text = DateTime.Parse(list["Starttime"].ToString()).ToShortDateString();
                    this.Endtime.Text = DateTime.Parse(list["Endtime"].ToString()).ToShortDateString().Replace("1900-1-1", "");
                    this.QdTime.Text = DateTime.Parse(list["QdTime"].ToString()).ToShortDateString();
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正常状态").Replace("2", "到期终止").Replace("3", "强行终止").Replace("4", "合同解除");
                    this.TextBox1.Text = list["Neirong"].ToString().Replace("disabled=\"disabled\"", "").Replace("disabled", "");
                    if (list["Zhuangtai"].ToString() == "1")
                    {
                        this.Button1.Text = "提 交";
                        this.Button1.Enabled = true;
                    }
                    else
                    {
                        this.Button1.Text = "当前状态[" + this.Zhuangtai.Text + "]不允许修改";
                        this.Button1.Enabled = false;
                    }
                    string str2 = "select LeibieID from qp_hr_HetongMB where  id='" + list["LeibieID"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.HetongZdId.Text = reader2["LeibieID"].ToString();
                    }
                    reader2.Close();
                }
                list.Close();
            }
        }
    }
}

