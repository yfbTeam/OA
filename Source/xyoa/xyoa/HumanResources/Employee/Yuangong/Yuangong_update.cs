namespace xyoa.HumanResources.Employee.Yuangong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Yuangong_update : Page
    {
        protected TextBox Beizhu;
        protected TextBox Bianhao;
        protected DropDownList Bumen;
        protected Button Button1;
        protected TextBox Chuanzhen;
        protected TextBox Chusheng;
        protected TextBox CjShijian;
        protected TextBox Dizhi;
        protected HtmlForm form1;
        protected TextBox GzJingli;
        protected HtmlHead Head1;
        protected TextBox Hukou;
        protected RadioButtonList Hunyin;
        protected TextBox Jiangcheng;
        protected TextBox Jiating;
        protected DropDownList Jiguan;
        protected TextBox Jineng;
        protected TextBox JrShijian;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Mianmao;
        protected DropDownList Mingzhu;
        protected TextBox MSN;
        protected TextBox Neibu;
        private publics pulicss = new publics();
        protected TextBox QQ;
        protected TextBox Shehui;
        protected TextBox Shenfenzheng;
        protected TextBox Shouji;
        protected TextBox Tijian;
        protected HtmlInputFile uploadFile;
        protected Label Username;
        protected Image Xiangpian;
        protected RadioButtonList Xingbie;
        protected TextBox Xingming;
        protected DropDownList Xuexi;
        protected TextBox XxJingli;
        protected TextBox Youbian;
        protected TextBox Youxiang;
        protected TextBox Yuanxiao;
        protected DropDownList Zhicheng;
        protected DropDownList Zhiwei;
        protected DropDownList Zhuanye;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str8;
            string str9;
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = string.Concat(new object[] { 
                    "Update qp_hr_Yuangong  Set Jiangcheng='", this.pulicss.GetFormatStr(this.Jiangcheng.Text), "',Chuanzhen='", this.pulicss.GetFormatStr(this.Chuanzhen.Text), "',Shouji='", this.pulicss.GetFormatStr(this.Shouji.Text), "',QQ='", this.pulicss.GetFormatStr(this.QQ.Text), "',MSN='", this.pulicss.GetFormatStr(this.MSN.Text), "',Neibu='", this.pulicss.GetFormatStr(this.Neibu.Text), "',Youbian='", this.pulicss.GetFormatStr(this.Youbian.Text), "',Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), 
                    "',Bianhao='", this.pulicss.GetFormatStr(this.Bianhao.Text), "',Xingbie='", this.Xingbie.SelectedValue, "',Chusheng='", this.pulicss.GetFormatStr(this.Chusheng.Text), "',Mingzhu='", this.Mingzhu.SelectedValue, "',Jiguan='", this.Jiguan.SelectedValue, "',Mianmao='", this.Mianmao.SelectedValue, "',Hunyin='", this.Hunyin.SelectedValue, "',Xuexi='", this.Xuexi.SelectedValue, 
                    "',Yuanxiao='", this.Yuanxiao.Text, "',Zhuanye='", this.Zhuanye.SelectedValue, "',Shenfenzheng='", this.pulicss.GetFormatStr(this.Shenfenzheng.Text), "',Hukou='", this.pulicss.GetFormatStr(this.Hukou.Text), "',Xiangpian='/HumanResources/Employee/Yuangong/file/", str2, "',Jiating='", this.pulicss.GetFormatStr(this.Jiating.Text), "',Youxiang='", this.pulicss.GetFormatStr(this.Youxiang.Text), "',Dizhi='", this.pulicss.GetFormatStr(this.Dizhi.Text), 
                    "',Bumen='", this.Bumen.SelectedValue, "',Leixing='", this.Leixing.SelectedValue, "',Zhiwei='", this.Zhiwei.SelectedValue, "',Zhicheng='", this.Zhicheng.SelectedValue, "',CjShijian='", this.pulicss.GetFormatStr(this.CjShijian.Text), "',JrShijian='", this.pulicss.GetFormatStr(this.JrShijian.Text), "',Shehui='", this.pulicss.GetFormatStr(this.Shehui.Text), "',GzJingli='", this.pulicss.GetFormatStr(this.GzJingli.Text), 
                    "',XxJingli='", this.pulicss.GetFormatStr(this.XxJingli.Text), "',Jineng='", this.pulicss.GetFormatStr(this.Jineng.Text), "',Tijian='", this.pulicss.GetFormatStr(this.Tijian.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'  "
                 });
                this.List.ExeSql(str8);
                str9 = "Update qp_oa_username  Set  pic='/HumanResources/Employee/Yuangong/file/" + str2 + "',Bothday='" + this.pulicss.GetFormatStr(this.Chusheng.Text) + "',Realname='" + this.pulicss.GetFormatStr(this.Xingming.Text) + "',Email='" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.Shouji.Text) + "',Sex='" + this.Xingbie.SelectedItem.Text + "',BuMenId='" + this.Bumen.SelectedValue + "',Zhiweiid='" + this.Zhiwei.SelectedValue + "' where Username='" + this.Username.Text + "'";
                this.List.ExeSql(str9);
            }
            else
            {
                str8 = string.Concat(new object[] { 
                    "Update qp_hr_Yuangong  Set Jiangcheng='", this.pulicss.GetFormatStr(this.Jiangcheng.Text), "',Chuanzhen='", this.pulicss.GetFormatStr(this.Chuanzhen.Text), "',Shouji='", this.pulicss.GetFormatStr(this.Shouji.Text), "',QQ='", this.pulicss.GetFormatStr(this.QQ.Text), "',MSN='", this.pulicss.GetFormatStr(this.MSN.Text), "',Neibu='", this.pulicss.GetFormatStr(this.Neibu.Text), "',Youbian='", this.pulicss.GetFormatStr(this.Youbian.Text), "',Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), 
                    "',Bianhao='", this.pulicss.GetFormatStr(this.Bianhao.Text), "',Xingbie='", this.Xingbie.SelectedValue, "',Chusheng='", this.pulicss.GetFormatStr(this.Chusheng.Text), "',Mingzhu='", this.Mingzhu.SelectedValue, "',Jiguan='", this.Jiguan.SelectedValue, "',Mianmao='", this.Mianmao.SelectedValue, "',Hunyin='", this.Hunyin.SelectedValue, "',Xuexi='", this.Xuexi.SelectedValue, 
                    "',Yuanxiao='", this.Yuanxiao.Text, "',Zhuanye='", this.Zhuanye.SelectedValue, "',Shenfenzheng='", this.pulicss.GetFormatStr(this.Shenfenzheng.Text), "',Hukou='", this.pulicss.GetFormatStr(this.Hukou.Text), "',Jiating='", this.pulicss.GetFormatStr(this.Jiating.Text), "',Youxiang='", this.pulicss.GetFormatStr(this.Youxiang.Text), "',Dizhi='", this.pulicss.GetFormatStr(this.Dizhi.Text), "',Bumen='", this.Bumen.SelectedValue, 
                    "',Leixing='", this.Leixing.SelectedValue, "',Zhiwei='", this.Zhiwei.SelectedValue, "',Zhicheng='", this.Zhicheng.SelectedValue, "',CjShijian='", this.pulicss.GetFormatStr(this.CjShijian.Text), "',JrShijian='", this.pulicss.GetFormatStr(this.JrShijian.Text), "',Shehui='", this.pulicss.GetFormatStr(this.Shehui.Text), "',GzJingli='", this.pulicss.GetFormatStr(this.GzJingli.Text), "',XxJingli='", this.pulicss.GetFormatStr(this.XxJingli.Text), 
                    "',Jineng='", this.pulicss.GetFormatStr(this.Jineng.Text), "',Tijian='", this.pulicss.GetFormatStr(this.Tijian.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'  "
                 });
                this.List.ExeSql(str8);
                str9 = "Update qp_oa_username  Set  Bothday='" + this.pulicss.GetFormatStr(this.Chusheng.Text) + "',Realname='" + this.pulicss.GetFormatStr(this.Xingming.Text) + "',Email='" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.Shouji.Text) + "',Sex='" + this.Xingbie.SelectedItem.Text + "',BuMenId='" + this.Bumen.SelectedValue + "',Zhiweiid='" + this.Zhiwei.SelectedValue + "' where Username='" + this.Username.Text + "'";
                this.List.ExeSql(str9);
            }
            string sql = "Update qp_oa_MyData  Set Sex='" + this.pulicss.GetFormatStr(this.Xingbie.SelectedItem.Text) + "',Bothday='" + this.pulicss.GetFormatStr(this.Chusheng.Text) + "',Tel='" + this.pulicss.GetFormatStr(this.Jiating.Text) + "',Fax='" + this.pulicss.GetFormatStr(this.Chuanzhen.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.Shouji.Text) + "',Email='" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "',QQNum='" + this.pulicss.GetFormatStr(this.QQ.Text) + "',Msn='" + this.pulicss.GetFormatStr(this.MSN.Text) + "',ICQ='" + this.pulicss.GetFormatStr(this.Neibu.Text) + "',ZipCode='" + this.pulicss.GetFormatStr(this.Youbian.Text) + "',HomeTel='" + this.pulicss.GetFormatStr(this.Jiating.Text) + "' where  Username='" + this.Username.Text + "'";
            this.List.ExeSql(sql);
            string str11 = "Update qp_oa_CompanyGroup  Set BuMenId='" + this.Bumen.SelectedValue + "',Zhiweiid='" + this.Zhiwei.SelectedValue + "',Name='" + this.pulicss.GetFormatStr(this.Xingming.Text) + "',Bothday='" + this.pulicss.GetFormatStr(this.Chusheng.Text) + "',Sex='" + this.pulicss.GetFormatStr(this.Xingbie.SelectedItem.Text) + "',Email='" + this.pulicss.GetFormatStr(this.Youxiang.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.Shouji.Text) + "'  where XtUsername='" + this.Username.Text + "'";
            this.List.ExeSql(str11);
            this.pulicss.InsertLog("修改员工档案[" + this.Xingming.Text + "]", "员工档案");
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'> winClose(1);</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee4ac", this.Session["perstr"].ToString());
                this.pulicss.BindListkong("qp_oa_Bumen", this.Bumen, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                string str2 = "select id,Name from qp_hr_YuangongLx where Type=1 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Mingzhu, str2, "id", "Name");
                string str3 = "select id,Name from qp_hr_YuangongLx where Type=2 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Jiguan, str3, "id", "Name");
                string str4 = "select id,Name from qp_hr_YuangongLx where Type=3 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Mianmao, str4, "id", "Name");
                string str5 = "select id,Name from qp_hr_YuangongLx where Type=4 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Xuexi, str5, "id", "Name");
                string str6 = "select id,Name from qp_hr_YuangongLx where Type=5 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhuanye, str6, "id", "Name");
                string str7 = "select id,Name from qp_hr_YuangongLx where Type=6 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhicheng, str7, "id", "Name");
                string str8 = "select id,Name from qp_hr_YuangongLx where Type=7 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, str8, "id", "Name");
                string sql = "select * from qp_hr_Yuangong  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Bianhao.Text = list["Bianhao"].ToString();
                    this.Xingbie.SelectedValue = list["Xingbie"].ToString();
                    this.Chusheng.Text = list["Chusheng"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Mingzhu.SelectedValue = list["Mingzhu"].ToString();
                    this.Jiguan.SelectedValue = list["Jiguan"].ToString();
                    this.Mianmao.SelectedValue = list["Mianmao"].ToString();
                    this.Hunyin.SelectedValue = list["Hunyin"].ToString();
                    this.Xuexi.SelectedValue = list["Xuexi"].ToString();
                    this.Yuanxiao.Text = list["Yuanxiao"].ToString();
                    this.Zhuanye.SelectedValue = list["Zhuanye"].ToString();
                    this.Shenfenzheng.Text = list["Shenfenzheng"].ToString();
                    this.Hukou.Text = list["Hukou"].ToString();
                    this.Xiangpian.ImageUrl = list["Xiangpian"].ToString();
                    this.Jiating.Text = list["Jiating"].ToString();
                    this.Youxiang.Text = list["Youxiang"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Bumen.SelectedValue = list["Bumen"].ToString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Zhiwei.SelectedValue = list["Zhiwei"].ToString();
                    this.Zhicheng.SelectedValue = list["Zhicheng"].ToString();
                    this.CjShijian.Text = list["CjShijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.JrShijian.Text = list["JrShijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Shehui.Text = list["Shehui"].ToString();
                    this.GzJingli.Text = list["GzJingli"].ToString();
                    this.XxJingli.Text = list["XxJingli"].ToString();
                    this.Jineng.Text = list["Jineng"].ToString();
                    this.Tijian.Text = list["Tijian"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                    this.Username.Text = list["Username"].ToString();
                    this.Chuanzhen.Text = list["Chuanzhen"].ToString();
                    this.Shouji.Text = list["Shouji"].ToString();
                    this.QQ.Text = list["QQ"].ToString();
                    this.MSN.Text = list["MSN"].ToString();
                    this.Neibu.Text = list["Neibu"].ToString();
                    this.Youbian.Text = list["Youbian"].ToString();
                    this.Jiangcheng.Text = list["Jiangcheng"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

