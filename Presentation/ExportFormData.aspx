<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportFormData.aspx.cs" Inherits="WFFM8.To.SQL.Presentation.ExportFormData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Web Forms Export</title>
    <link rel="shortcut icon" href="/sitecore/images/favicon.ico" />
    <link href="/sitecore/shell/client/Speak/Assets/css/speak-default-theme.css" rel="stylesheet" type="text/css" />
</head>
<body class="sc sc-fullWidth">
    <header class="sc-globalHeader">
        <div class="row sc-globalHeader-content">
            <div class="col-md-6">
                <div class="sc-globalHeader-startButton">
                </div>
                <div class="sc-globalHeader-navigationToggler">
                </div>
            </div>
            <div class="col-md-6">
                <div class="sc-globalHeader-loginInfo">

                    <ul data-sc-id="AccountInformation" class="sc-accountInformation" data-sc-require="/-/speak/v1/business/AccountInformation.js">
                        <li><a class="logout" href="/api/sitecore/Authentication/Logout?sc_database=master">Logout</a></li>
                        <li>Administrator
                            <img src="/~/icon/People/16x16/Astrologer.png" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </header>


    <section class="sc-applicationContent">
        <header class="sc-applicationHeader">

            <div class="sc-applicationHeader-row1">
                <div class="sc-applicationHeader-content">
                    <div class="sc-applicationHeader-title">
                        Export Data as CSV
                    </div>
                </div>


            </div>
            <div class="sc-applicationHeader-row2">
                <div class="sc-applicationHeader-back">
                </div>
                <div class="sc-applicationHeader-contextSwitcher">
                </div>
                <div class="sc-applicationHeader-actions">
                </div>
            </div>

        </header>


        <div class="row sc-contentRowFix">
            <section class="col-md-9 sc-applicationContent-main">
                <div data-sc-id="Main" class="sc-border sc-show-padding sc_Border_98 data-sc-registered">

                    <form id="form1" runat="server">
                        <div class="col-md-12">
                            <asp:PlaceHolder ID="NotLoggedLoggedInPlaceHolder" runat="server" Visible="false">
                                <div style="color: red">You have to be logged in and or missing item id or name querystring</div>
                            </asp:PlaceHolder>
                            
                            <asp:PlaceHolder ID="WithDateRange" runat="server" Visible="false">
                                <div class="col-md-4">
                                    From Date:<asp:TextBox ID="txtFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-4">
                                    <asp:Label ID="warnFrom" runat="server" ForeColor="Red" ViewStateMode="Disabled"></asp:Label>
                                To Date:<asp:TextBox ID="txtTo" CssClass="form-control" runat="server"></asp:TextBox><asp:Label ID="warnTo" runat="server" ForeColor="Red" ViewStateMode="Disabled"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                <asp:Button ID="btnExport" runat="server" style="margin-top: 16px;" CssClass="btn-primary lg" OnClick="btnExport_Click" Text="Export" />
                                </div>
                            </asp:PlaceHolder>
                        </div>
                    </form>

                </div>
            </section>

        </div>
    </section>


</body>
</html>
