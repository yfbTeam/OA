namespace xyoa.Resources.ResSet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ResourcesAdd_add : Page
    {
        protected Button Button1;
        protected Button Button2;
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
        protected HtmlInputFile uploadFile;
        protected TextBox Xinghao;
        protected DropDownList Zhuangtai;
        protected TextBox ZyIntro;
        protected DropDownList ZyLeibie;
        protected TextBox ZyName;
        protected TextBox ZyNum;
        protected DropDownList ZyXingzhi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void BindDroList()
        {
            string sQL = "select *  from qp_oa_ResourcesType";
            this.list.Bind_DropDownList_nothing(this.ZyLeibie, sQL, "id", "Name");
            string str2 = "select *  from qp_oa_ResourcesCangKu";
            this.list.Bind_DropDownList_nothing(this.Cangku, str2, "id", "Name");
            string str3 = "select *  from qp_oa_ResourcesQuyu";
            this.list.Bind_DropDownList_nothing(this.Quyu, str3, "id", "Name");
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
                str9 = "insert into qp_oa_ResourcesAdd  (Xinghao,TuPian,Quyu,Cangku,Zhuangtai,BfKuCun,AllKuCun,ZyNum,ZyName,ZyIntro,ZyLeibie,ZyXingzhi,Danwei,Danjia,Gongyinshang,KuCun,LimitsS,LimitsE) values ('" + this.pulicss.GetFormatStr(this.Xinghao.Text) + "','Resources/ResSet/TuPian/" + str2 + "','" + this.Quyu.SelectedValue + "','" + this.Cangku.SelectedValue + "','" + this.Zhuangtai.SelectedValue + "','0','" + this.pulicss.GetFormatStr(this.KuCun.Text) + "','" + this.pulicss.GetFormatStr(this.ZyNum.Text) + "','" + this.pulicss.GetFormatStr(this.ZyName.Text) + "','" + this.pulicss.GetFormatStr(this.ZyIntro.Text) + "','" + this.ZyLeibie.SelectedValue + "','" + this.ZyXingzhi.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Danwei.Text) + "','" + this.pulicss.GetFormatStr(this.Danjia.Text) + "','" + this.pulicss.GetFormatStr(this.Gongyinshang.Text) + "','" + this.pulicss.GetFormatStr(this.KuCun.Text) + "','" + this.pulicss.GetFormatStr(this.LimitsS.Text) + "','" + this.pulicss.GetFormatStr(this.LimitsE.Text) + "')";
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = "insert into qp_oa_ResourcesAdd  (Xinghao,TuPian,Quyu,Cangku,Zhuangtai,BfKuCun,AllKuCun,ZyNum,ZyName,ZyIntro,ZyLeibie,ZyXingzhi,Danwei,Danjia,Gongyinshang,KuCun,LimitsS,LimitsE) values ('" + this.pulicss.GetFormatStr(this.Xinghao.Text) + "','Resources/ResSet/TuPian/nothing.jpg','" + this.Quyu.SelectedValue + "','" + this.Cangku.SelectedValue + "','" + this.Zhuangtai.SelectedValue + "','0','" + this.pulicss.GetFormatStr(this.KuCun.Text) + "','" + this.pulicss.GetFormatStr(this.ZyNum.Text) + "','" + this.pulicss.GetFormatStr(this.ZyName.Text) + "','" + this.pulicss.GetFormatStr(this.ZyIntro.Text) + "','" + this.ZyLeibie.SelectedValue + "','" + this.ZyXingzhi.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Danwei.Text) + "','" + this.pulicss.GetFormatStr(this.Danjia.Text) + "','" + this.pulicss.GetFormatStr(this.Gongyinshang.Text) + "','" + this.pulicss.GetFormatStr(this.KuCun.Text) + "','" + this.pulicss.GetFormatStr(this.LimitsS.Text) + "','" + this.pulicss.GetFormatStr(this.LimitsE.Text) + "')";
                this.List.ExeSql(str9);
            }
            this.pulicss.InsertLog("新增物品登记[" + this.ZyName.Text + "]", "物品登记");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ResourcesAdd.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ResourcesAdd.aspx");
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

