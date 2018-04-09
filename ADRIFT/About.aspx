<%@ Page Title="About" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="About.aspx.vb" Inherits="ADRIFT._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div style="height:100%" onclick="_FocusInput()">
        <div style="position:absolute;left:0px;right:0px;padding-left:15px;height:24px;color:black;background-color:#D22527;font-size:18px;font-family:Arial,Helvetica" runat="server" ID="txtStatusBarAbout">About</div>        
        <div style="position:absolute;right:0px;top:3px;width:24px;height:24px"><asp:HyperLink ID="LinkDefault" ImageUrl="http://play.adrift.co/img/Back.png" NavigateUrl="~/Default.aspx" runat="server" /></div>
        <div style="left:0px;right:0px;padding:15px;position:absolute;top:24px;bottom:28px;background-color:black;overflow:scroll;display:inline-block;font-family:Arial,Helvetica" runat="server" ID="txtOutputWebAbout"></div>
    </div>

</asp:Content>
