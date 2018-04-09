<%@ Page Title="ADRIFT WebRunner" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="ADRIFT._Default" MaintainScrollPositionOnPostback="false" %>

<%@ Register assembly="Infragistics4.Web.v13.2, Version=13.2.20132.2294, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.LayoutControls" tagprefix="ig" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
       
        function _FocusInput() {
            var TextBox = document.getElementById("<%=txtInputWeb.ClientID%>");
            TextBox.focus();
        }
        
    </script>
      
    <div style="height:100%; width:100%; background-color: purple" onclick="_FocusInput()">        

        <asp:UpdatePanel ID="UpdatePanelStatusBar" runat="server" UpdateMode="Conditional">
            <ContentTemplate>   
                <div style=" padding-top:2px; top:0px; height:24px; width:100%; right:0px; color: black; background-color: #D22527; font-size: 18px; font-family: Arial,Helvetica">
                <div id="txtStatusBar" runat="server" style="float: left;">
                    Game Not Loaded</div>
                <div style="float: right; padding-top:1px;">
                    <asp:HyperLink ID="LinkAbout" ImageUrl="http://play.adrift.co/img/Help.png" NavigateUrl="~/About.aspx" runat="server" />
                </div>
                <div id="txtScore" runat="server" style="float: right; width: 150px;">
                    Score: 0</div>
                <div id="txtUserStatus" runat="server" style="text-align: center;">
                    User Status</div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanelAudioChannels" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="height:0px; width:0px;" name="Channel1" id="Channel1" runat="server"></div>
                <div style="height:0px; width:0px;" name="Channel2" id="Channel2" runat="server"></div>
                <div style="height:0px; width:0px;" name="Channel3" id="Channel3" runat="server"></div>
                <div style="height:0px; width:0px;" name="Channel4" id="Channel4" runat="server"></div>
                <div style="height:0px; width:0px;" name="Channel5" id="Channel5" runat="server"></div>
                <div style="height:0px; width:0px;" name="Channel6" id="Channel6" runat="server"></div>
                <div style="height:0px; width:0px;" name="Channel7" id="Channel7" runat="server"></div>
                <div style="height:0px; width:0px;" name="Channel8" id="Channel8" runat="server"></div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <div style="position:absolute; top:24px; bottom:0px; width:100%">
            <ig:WebSplitter ID="WebSplitter1" runat="server" Height="100%" Width="100%" BackColor="Green"
                BorderStyle="None" BorderWidth="0px">
                <AutoPostBackFlags SplitterBarPositionChanged="On" />
                <Panes>
                    <ig:SplitterPane runat="server" BackColor="Black">
                        <Template>
                            <asp:UpdatePanel ID="UpdatePanelText" runat="server">
                                <ContentTemplate>           
                                    <div id="txtOutputWeb" runat="server" style="left:0px; right: 0px; padding: 15px;
                                        background-color: black; font-size: 14px; font-family: Arial,Helvetica">
                                        To play a game, please set the value for the &quot;game&quot; parameter in the address
                                        bar to be the URL of an ADRIFT game file.<p></p>
                                        Or why not try one of the games below:
                                        <ul>
                                            <li><a href="/?game=http://www.adrift.co/files/games/backtolife.taf" style="color: Red">
                                                Back To Life... Unfortunately</a></li>
                                            <li><a href="/?game=http://www.adrift.co/files/games/cursed.taf" style="color: Red">
                                                Cursed</a></li>
                                            <li><a href="/?game=http://www.adrift.co/files/games/jim.blorb" style="color: Red">Jacaranda
                                                Jim</a></li>
                                        </ul>                                                                                                                
                                    </div>
                                    <div id="InputWeb" style="background-color: black; padding-left: 13px; bottom:0px;" runat="server">
                                        <table border="0" cellpadding="0" cellspacing="0"> <!--position:absolute; -->
                                            <tr>
                                                <td>
                                                    <div style="font-size:18px;">➢&nbsp;</div>
                                                </td>
                                                <td style="width:100%">
                                                    <asp:TextBox ID="txtInputWeb" runat="server" BackColor="black" ForeColor="#33CC33"
                                                        Width="95%" Wrap="False" Font-Names="Arial" Font-Size="Medium" Height="100%"
                                                        BorderStyle="None" AutoPostBack="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Template>
                    </ig:SplitterPane>
                
                    <ig:SplitterPane runat="server" MaxSize="600px" Size="400px" CollapsedDirection="PreviousPane"
                        MinSize="200px" BorderStyle="None" ScrollBars="Hidden" BackColor="#E6FFFF" >
                        <Template>
                            <asp:UpdatePanel ID="UpdatePanelMap" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>                                
                                    <div style="vertical-align:middle; position:fixed; height:100%" >
                                        <table cellspacing="0" cellpadding="0" style="height:100%"><tr valign="middle"><td class="igspl_VSplitBarWidth">
                                            <asp:Image ID="MapImage" runat="server" ImageUrl="~/MapHandler.ashx" ImageAlign="Middle" />
                                            </td></tr>
                                        </table>
                                    </div>
                                </ContentTemplate>                            
                            </asp:UpdatePanel>                        
                        </Template>
                    </ig:SplitterPane>
                </Panes>
            </ig:WebSplitter>
        </div>
    </div>
</asp:Content>

