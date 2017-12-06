namespace xyoa.Resources.ResSet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ResourcesAdd_update : Page
    {
        protected TextBox AllKuCun;
        protected TextBox BfKuCun;
        protected Button Button1;
        protected DropDownList Cangku;
        protected TextBox Danjia;
        protected TextBox Danwei;
        protected HtmlForm form1;
        protected TextBox Gongyinshang;
        protected HtmlHead Head1;
        protected TextBox KuCun;
        protected TextBox LimitsE;
        protected TextBox LimitsS;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList Quyu;
        protected Image TuPian;
        protected HtmlInputFile uploadFile;
        protected TextBox Xinghao;
        protected TextBox YjyKuCun;
        protected DropDownList Zhuangtai;
        protected TextBox ZyIntro;
        protected DropDownList ZyLeibie;
        protected TextBox ZyName;
        protected TextBox ZyNum;
        protected DropDownList ZyXingzhi;

        public void BindAttribute()
        {
            this.AllKuCun.Attributes.Add("readonly", "readonly");
            this.BfKuCun.Attributes.Add("readonly", "readonly");
            this.YjyKuCun.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDroList()
        {
            string sQL = "select *  from qp_oa_ResourcesType";
            this.list.Bind_DropDownList_nothing(this.ZyLeibie, sQL, "id", "Name");
            string str2 = "select *  from qp_oa_ResourcesCangKu";
            this.list.Bind_DropDownList_nothing(this.Cangku, str2, "id", "Name");
            string str3 = "select *  from qp_oa_ResourcesQuyu";
            this.list.Bind_DropDownList_nothing(this.Quyu, str3, "id", "Name");
            string sql = "select * from qp_oa_ResourcesAdd  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.Xinghao.Text = list["Xinghao"].ToString();
                this.ZyNum.Text = list["ZyNum"].ToString();
                this.ZyName.Text = list["ZyName"].ToString();
                this.ZyIntro.Text = list["ZyIntro"].ToString();
                this.ZyLeibie.SelectedValue = list["ZyLeibie"].ToString();
                this.ZyXingzhi.SelectedValue = list["ZyXingzhi"].ToString();
                this.Danwei.Text = list["Danwei"].ToString();
                this.Danjia.Text = list["Danjia"].ToString();
                this.Gongyinshang.Text = list["Gongyinshang"].ToString();
                this.KuCun.Text = list["KuCun"].ToString();
                this.LimitsS.Text = list["LimitsS"].ToString();
                this.LimitsE.Text = list["LimitsE"].ToString();
                this.AllKuCun.Text = list["AllKuCun"].ToString();
                this.BfKuCun.Text = list["BfKuCun"].ToString();
                this.Quyu.SelectedValue = list["Quyu"].ToString();
                this.Cangku.SelectedValue = list["Cangku"].ToString();
                this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                this.TuPian.ImageUrl = "/" + list["TuPian"].ToString();
                decimal num = (decimal.Parse(this.AllKuCun.Text) - decimal.Parse(this.KuCun.Text)) - decimal.Parse(this.BfKuCun.Text);
                this.YjyKuCun.Text = "" + num + "";
            }
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str9;
            string str = base.Server.MapPath("TuPian/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                string filetype = this.pulicss.Getfiletype(extension);
                Random random = new Random();
                string str8 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str8;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str9 = string.Concat(new object[] { 
                    "Update qp_oa_ResourcesAdd  Set  Xinghao='", this.pulicss.GetFormatStr(this.Xinghao.Text), "',TuPian='Resources/ResSet/TuPian/", str2, "',Quyu='", this.Quyu.SelectedValue, "',Cangku='", this.Cangku.SelectedValue, "',Zhuangtai='", this.Zhuangtai.SelectedValue, "',ZyNum='", this.pulicss.GetFormatStr(this.ZyNum.Text), "',ZyName='", this.pulicss.GetFormatStr(this.ZyName.Text), "',ZyIntro='", this.pulicss.GetFormatStr(this.ZyIntro.Text), 
                    "',ZyLeibie='", this.ZyLeibie.SelectedValue, "',ZyXingzhi='", this.ZyXingzhi.SelectedValue, "',Danwei='", this.Danwei.Text, "',Danjia='", this.Danjia.Text, "',Gongyinshang='", this.Gongyinshang.Text, "',KuCun='", this.KuCun.Text, "',LimitsS='", this.LimitsS.Text, "',LimitsE='", this.LimitsE.Text, 
                    "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
                 });
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = string.Concat(new object[] { 
                    "Update qp_oa_ResourcesAdd  Set  Xinghao='", this.pulicss.GetFormatStr(this.Xinghao.Text), "',TuPian='Resources/ResSet/TuPian/nothing.jpg',Quyu='", this.Quyu.SelectedValue, "',Cangku='", this.Cangku.SelectedValue, "',Zhuangtai='", this.Zhuangtai.SelectedValue, "',ZyNum='", this.pulicss.GetFormatStr(this.ZyNum.Text), "',ZyName='", this.pulicss.GetFormatStr(this.ZyName.Text), "',ZyIntro='", this.pulicss.GetFormatStr(this.ZyIntro.Text), "',ZyLeibie='", this.ZyLeibie.SelectedValue, 
                    "',ZyXingzhi='", this.ZyXingzhi.SelectedValue, "',Danwei='", this.Danwei.Text, "',Danjia='", this.Danjia.Text, "',Gongyinshang='", this.Gongyinshang.Text, "',KuCun='", this.KuCun.Text, "',LimitsS='", this.LimitsS.Text, "',LimitsE='", this.LimitsE.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), 
                    "'  "
                 });
                this.List.ExeSql(str9);
            }
            this.pulicss.InsertLog("修改物品登记[" + this.ZyName.Text + "]", "物品登记");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ResourcesAdd.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindDroList();
                this.BindAttribute();
            }
        }
    }
}

