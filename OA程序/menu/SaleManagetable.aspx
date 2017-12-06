<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SaleManagetable.aspx.cs"
    Inherits="xyoa.menu.SaleManagetable" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body style="overflow: auto" bgcolor=white>
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="/oaimg/menu/knowledge2.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="SaleManagetable.aspx"><font class="lefttd">CRM管理</font></a></td>
            </tr>
        </table>
               <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>
        <asp:TreeView ID="TreeView6" runat="server" CollapseImageUrl="~/oaimg/2.gif" ExpandImageUrl="~/oaimg/1.gif"
            NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Text="客户管理" Value="ffff1" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu285.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SaleManage/CustomerBb.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户信息报备&lt;/a&gt;"
                        Value="ffff1e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户基本信息" Value="ffff1a"
                        ImageUrl="~/oaimg/menu/Menu285.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SaleManage/Customer.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户信息管理&lt;/a&gt;"
                            Value="ffff1a1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SaleManage/CustomerLxrAll.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户联系人&lt;/a&gt;"
                            Value="ffff1a2" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SaleManage/ContactsLog.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户交往记录&lt;/a&gt;"
                        Value="ffff1b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SaleManage/ServicesLog.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户服务&lt;/a&gt;"
                        Value="ffff1c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SaleManage/CustomerMove.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户转移&lt;/a&gt;"
                        Value="ffff1d" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="客户忠诚度管理" Value="ffff2" Expanded="False" SelectAction="Expand"
                    ImageUrl="~/oaimg/menu/training.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsCare.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户关怀&lt;/a&gt;"
                        Value="ffff2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsVisit.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户回访&lt;/a&gt;"
                        Value="ffff2b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsComp.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户投诉&lt;/a&gt;"
                        Value="ffff2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsSurvey.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户满意度调查&lt;/a&gt;"
                        Value="ffff2d" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="产品信息" Value="ffff3" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/office_Product.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/office_Product.gif" Text="&lt;a href='../SaleManage/SupplierPro.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;产品信息管理&lt;/a&gt;"
                        Value="ffff3c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="销售平台" Value="ffff4" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/sale_manage.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/SaleContract.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售合同&lt;/a&gt;"
                        Value="ffff4a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Text="销售记录管理" Value="ffff4b" Expanded="False" SelectAction="Expand"
                        ImageUrl="~/oaimg/menu/sale_manage.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/SaleProduct.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;常规产品&lt;/a&gt;"
                            Value="ffff4b1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/SaleProductFw.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;服务产品&lt;/a&gt;"
                            Value="ffff4b2" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="供应商管理" Value="ffff5" ImageUrl="~/oaimg/menu/training.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/Supplier.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;供应商信息管理&lt;/a&gt;"
                        Value="ffff5c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="统计分析" Value="ffff6" ImageUrl="~/oaimg/menu/finance.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/AnalysisCustomer.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户综合信息&lt;/a&gt;"
                        Value="ffff6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="销售统计" Value="ffff6c" ImageUrl="~/oaimg/menu/training.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleContract.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;合同统计&lt;/a&gt;"
                            Value="ffff6c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleProduct.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;产品销售&lt;/a&gt;"
                            Value="ffff6c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleProductFw.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;服务销售&lt;/a&gt;"
                            Value="ffff6c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户属性统计" Value="ffff6d"
                        ImageUrl="~/oaimg/menu/diary.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AllSaleDataQy.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户区域&lt;/a&gt;"
                            Value="ffff6d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AllSaleData.aspx?type=2 '  target='rform' onclick='parent.UploadComplete();' &gt;客户行业&lt;/a&gt;"
                            Value="ffff6d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AllSaleDataKhly.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户来源&lt;/a&gt;"
                            Value="ffff6d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AllSaleDataKhzyd.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户重要度&lt;/a&gt;"
                            Value="ffff6d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AllSaleDataXsfs.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售方式&lt;/a&gt;"
                            Value="ffff6d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AllSaleDataQyxz.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;企业性质&lt;/a&gt;"
                            Value="ffff6d" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户归属统计" Value="ffff6e"
                        ImageUrl="~/oaimg/menu/diary.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AttributionBm.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;部门统计&lt;/a&gt;"
                            Value="ffff6e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AttributionXsz.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售组统计&lt;/a&gt;"
                            Value="ffff6e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/diary.gif" Text="&lt;a href='../SaleManage/AttributionYwy.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;业务员统计&lt;/a&gt;"
                            Value="ffff6e" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="基础数据设置" Value="ffff7"
                    ImageUrl="~/oaimg/menu/person_info.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleGroup.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售组维护&lt;/a&gt;"
                        Value="ffff7a" NavigateUrl="~/SaleManage/SaleGroup.aspx" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="数据字典维护" Value="ffff7b"
                        ImageUrl="~/oaimg/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=1 '  target='rform' onclick='parent.UploadComplete();' &gt;区域&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=2 '  target='rform' onclick='parent.UploadComplete();' &gt;行业&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=3'  target='rform' onclick='parent.UploadComplete();' &gt;客户来源&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=4'  target='rform' onclick='parent.UploadComplete();' &gt;重要度&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=5 '  target='rform' onclick='parent.UploadComplete();' &gt;交往方式&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=6 '  target='rform' onclick='parent.UploadComplete();' &gt;企业性质&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=7 '  target='rform' onclick='parent.UploadComplete();' &gt;销售方式&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=8 '  target='rform' onclick='parent.UploadComplete();' &gt;服务方式&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=9 '  target='rform' onclick='parent.UploadComplete();' &gt;计量单位&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=10 '  target='rform' onclick='parent.UploadComplete();' &gt;产品类别&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=11 '  target='rform' onclick='parent.UploadComplete();' &gt;合同类型&lt;/a&gt;"
                            Value="ffff7b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="自定义字段" Value="ffff7c" Expanded="False" SelectAction="Expand"
                        ImageUrl="~/oaimg/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=1 '  target='rform' onclick='parent.UploadComplete();' &gt;客户管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=2'  target='rform' onclick='parent.UploadComplete();' &gt;客户联系人管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=3 '  target='rform' onclick='parent.UploadComplete();' &gt;客户服务管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=4'  target='rform' onclick='parent.UploadComplete();' &gt;产品管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=5'  target='rform' onclick='parent.UploadComplete();' &gt;服务型产品管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=6'  target='rform' onclick='parent.UploadComplete();' &gt;合同管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=7'  target='rform' onclick='parent.UploadComplete();' &gt;供应商信息管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=8'  target='rform' onclick='parent.UploadComplete();' &gt;供应商联系人管理&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=11'  target='rform' onclick='parent.UploadComplete();' &gt;供应商产品信息&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=9'  target='rform' onclick='parent.UploadComplete();' &gt;产品销售记录&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=10'  target='rform' onclick='parent.UploadComplete();' &gt;服务性产品销售记录&lt;/a&gt;"
                            Value="ffff7c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
                        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
