namespace xyoa.SystemManage.Pda
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class SysMk : Page
    {
        protected Button Button1;
    //    protected CheckBox CRM;
    //    protected CheckBoxList CRMLm;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected CheckBox OA;
        protected CheckBoxList OALm;
   //     protected CheckBox PM;
   //     protected CheckBoxList PMLm;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        //    string sql = "Update qp_pda_SysMk  Set OA='" + this.OA.Checked.ToString().Replace("True", "1").Replace("False", "0") + "',CRM='" + this.CRM.Checked.ToString().Replace("True", "1").Replace("False", "0") + "',PM='" + this.PM.Checked.ToString().Replace("True", "1").Replace("False", "0") + "',OALm='" + this.pulicss.GetChecked(this.OALm) + "',CRMLm='" + this.pulicss.GetChecked(this.CRMLm) + "',PMLm='" + this.pulicss.GetChecked(this.PMLm) + "'";
            string sql = "Update qp_pda_SysMk  Set OA='" + this.OA.Checked.ToString().Replace("True", "1").Replace("False", "0") + "',OALm='" + this.pulicss.GetChecked(this.OALm) + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改手机平台设置", "手机平台设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SysMk.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id, Name  from qp_pda_url  where leixing='1' order by paixu asc";
                this.list.Bind_DropDownList_CheckBoxList(this.OALm, sQL, "id", "Name");
        //        string str2 = "select id, Name  from qp_pda_url  where leixing='2' order by paixu asc";
        //        this.list.Bind_DropDownList_CheckBoxList(this.CRMLm, str2, "id", "Name");
        //        string str3 = "select id, Name  from qp_pda_url  where leixing='3' order by paixu asc";
        //        this.list.Bind_DropDownList_CheckBoxList(this.PMLm, str3, "id", "Name");
                string sql = "select * from qp_pda_SysMk";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["OA"].ToString() == "1")
                    {
                        this.OA.Checked = true;
                    }
         //           if (list["CRM"].ToString() == "1")
                    {
           //             this.CRM.Checked = true;
                    }
             //       if (list["PM"].ToString() == "1")
                    {
             //           this.PM.Checked = true;
                    }
                    this.pulicss.SetChecked(this.OALm, "," + list["OALm"].ToString() + ",");
            //        this.pulicss.SetChecked(this.CRMLm, "," + list["CRMLm"].ToString() + ",");
             //       this.pulicss.SetChecked(this.PMLm, "," + list["PMLm"].ToString() + ",");
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

