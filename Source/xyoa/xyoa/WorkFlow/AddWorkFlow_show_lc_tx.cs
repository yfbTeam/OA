namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_show_lc_tx : Page
    {
        protected TextBox FlowNumber;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox SET_SQL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                StateBag bag = ViewState;
                this.ViewState["LineContent"] = "";
                this.ViewState["ContentLable"] = "";
                this.FlowNumber.Text = base.Request.QueryString["FlowNumber"].ToString();
                string sql = "select * from qp_oa_WorkFlowNode   where  FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    object obj2;
                    if (list["NodeName"].ToString() == base.Request.QueryString["NodeName"].ToString())
                    {
                        obj2 = bag["ContentLable"];
                        (bag = this.ViewState)["ContentLable"] = string.Concat(new object[] { 
                            obj2, "<vml:roundrect id=", list["NodeNum"].ToString(), " ondblclick=Edit_Process(", list["id"].ToString(), "); style=\"Z-INDEX: 1; LEFT: ", list["SETLEFT"].ToString(), "px; VERTICAL-ALIGN: middle; WIDTH: 100px; CURSOR: hand; POSITION: absolute; TOP: ", list["SETTOP"].ToString(), "px; HEIGHT: 50px; TEXT-ALIGN: center\"   title=\"下一步骤：", list["UpNodeNum"].ToString(), "\";  coordsize=\"21600,21600\" arcsize=\"4321f\" fillcolor=\"#FFFF00\" receiverName=\"\" receiverID=\"\" readOnly=\"0\" flowFlag=\"0\" flowTitle=\"<b>", list["NodeNum"].ToString(), "</b><br>", list["NodeName"].ToString(), "\" passCount=\"0\" flowType=\"stay\" table_id=\"", 
                            list["id"].ToString(), "\" inset=\"2pt,2pt,2pt,2pt\"><vml:shadowoffset=\"3px,3px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow><vml:textbox onselectstart=\"return false;\" inset=\"1pt,2pt,1pt,1pt\"><B>", list["NodeNum"].ToString(), "</B><BR>", list["NodeName"].ToString(), "</vml:textbox></vml:roundrect>"
                         });
                    }
                    else if (list["NodeSite"].ToString() == "开始")
                    {
                        obj2 = bag["ContentLable"];
                        (bag = this.ViewState)["ContentLable"] = string.Concat(new object[] { 
                            obj2, "<vml:roundrect id=", list["NodeNum"].ToString(), " ondblclick=Edit_Process(", list["id"].ToString(), "); style=\"Z-INDEX: 1; LEFT: ", list["SETLEFT"].ToString(), "px; VERTICAL-ALIGN: middle; WIDTH: 100px; CURSOR: hand; POSITION: absolute; TOP: ", list["SETTOP"].ToString(), "px; HEIGHT: 50px; TEXT-ALIGN: center\"   title=\"下一步骤：", list["UpNodeNum"].ToString(), "\";  coordsize=\"21600,21600\" arcsize=\"4321f\" fillcolor=\"#00EE00\" receiverName=\"\" receiverID=\"\" readOnly=\"0\" flowFlag=\"0\" flowTitle=\"<b>", list["NodeNum"].ToString(), "</b><br>", list["NodeName"].ToString(), "\" passCount=\"0\" flowType=\"start\" table_id=\"", 
                            list["id"].ToString(), "\" inset=\"2pt,2pt,2pt,2pt\"><vml:shadowoffset=\"3px,3px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow><vml:textbox onselectstart=\"return false;\" inset=\"1pt,2pt,1pt,1pt\"><B>", list["NodeNum"].ToString(), "</B><BR>", list["NodeName"].ToString(), "</vml:textbox></vml:roundrect>"
                         });
                    }
                    else if (list["NodeSite"].ToString() == "结束")
                    {
                        obj2 = bag["ContentLable"];
                        (bag = this.ViewState)["ContentLable"] = string.Concat(new object[] { 
                            obj2, "<vml:roundrect id=", list["NodeNum"].ToString(), " ondblclick=Edit_Process(", list["id"].ToString(), "); style=\"Z-INDEX: 1; LEFT: ", list["SETLEFT"].ToString(), "px; VERTICAL-ALIGN: middle; WIDTH: 100px; CURSOR: hand; POSITION: absolute; TOP: ", list["SETTOP"].ToString(), "px; HEIGHT: 50px; TEXT-ALIGN: center\"   title=\"下一步骤：结束\";  coordsize=\"21600,21600\" arcsize=\"4321f\" fillcolor=\"#F4A8BD\" receiverName=\"\" receiverID=\"\" readOnly=\"0\" flowFlag=\"0\" flowTitle=\"<b>", list["NodeNum"].ToString(), "</b><br>", list["NodeName"].ToString(), "\" passCount=\"0\" flowType=\"end\" table_id=\"", list["id"].ToString(), "\" inset=\"2pt,2pt,2pt,2pt\"><vml:shadowoffset=\"3px,3px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow><vml:textbox onselectstart=\"return false;\" inset=\"1pt,2pt,1pt,1pt\"><B>", 
                            list["NodeNum"].ToString(), "</B><BR>", list["NodeName"].ToString(), "</vml:textbox></vml:roundrect>"
                         });
                    }
                    else
                    {
                        obj2 = bag["ContentLable"];
                        (bag = this.ViewState)["ContentLable"] = string.Concat(new object[] { 
                            obj2, "<vml:roundrect id=", list["NodeNum"].ToString(), " ondblclick=Edit_Process(", list["id"].ToString(), "); style=\"Z-INDEX: 1; LEFT: ", list["SETLEFT"].ToString(), "px; VERTICAL-ALIGN: middle; WIDTH: 100px; CURSOR: hand; POSITION: absolute; TOP: ", list["SETTOP"].ToString(), "px; HEIGHT: 50px; TEXT-ALIGN: center\"   title=\"下一步骤：", list["UpNodeNum"].ToString(), "\";  coordsize=\"21600,21600\" arcsize=\"4321f\" fillcolor=\"#EEEEEE\" receiverName=\"\" receiverID=\"\" readOnly=\"0\" flowFlag=\"0\" flowTitle=\"<b>", list["NodeNum"].ToString(), "</b><br>", list["NodeName"].ToString(), "\" passCount=\"0\" flowType=\"\" table_id=\"", 
                            list["id"].ToString(), "\" inset=\"2pt,2pt,2pt,2pt\"><vml:shadowoffset=\"3px,3px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow><vml:textbox onselectstart=\"return false;\" inset=\"1pt,2pt,1pt,1pt\"><B>", list["NodeNum"].ToString(), "</B><BR>", list["NodeName"].ToString(), "</vml:textbox></vml:roundrect>"
                         });
                    }
                }
                list.Close();
                string str2 = "select * from qp_oa_WorkFlowNodeLine   where  FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'  ";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    (bag = this.ViewState)["LineContent"] = bag["LineContent"] + reader2["LineContent"].ToString();
                }
                reader2.Close();
            }
        }
    }
}

