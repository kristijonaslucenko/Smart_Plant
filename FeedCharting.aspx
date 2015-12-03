<%@ Page Title="Analysis & Forecast" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="FeedCharting.aspx.cs" Inherits="FeedCharting" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


    
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
   <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Settings</h2><br />[timespan, recommended levels, forecasting]<br /><br />
                </hgroup>
                <asp:DropDownList ID="DropDownTimeSpan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownTimeSpan_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">All entries</asp:ListItem>
                <asp:ListItem Value="1">Last day</asp:ListItem>
                <asp:ListItem Value="2">Last week</asp:ListItem>
                <asp:ListItem Value="3">Last month</asp:ListItem>
                <asp:ListItem Value="4">User Specified</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox_rec" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox_rec_CheckedChanged" Checked="True"/>&nbsp;Recommendations&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Select Forecast</asp:ListItem>
                <asp:ListItem Value="7">7 Days</asp:ListItem>
                <asp:ListItem Value="14">2 weeks</asp:ListItem>
                <asp:ListItem Value="30">Month</asp:ListItem>
                <asp:ListItem Value="20">Moving average</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Names="Segoe UI Semilight" Font-Overline="False" Font-Size="Small" Height="32px" OnClick="Button1_Click" Text="Compare Outside &amp; Inside Climate" Width="248px" />
            <hr width ="300px" align="left"/>
            <asp:Label ID="Label1" runat="server"></asp:Label> 
            entries for period <asp:Label ID="Label2" runat="server"></asp:Label>
            <hgroup>
            </hgroup>
           
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label ID="Label3" runat="server" Font-Names="Consolas" Font-Size="XX-Large">Inside</asp:Label> <br />
    <asp:Chart ID="Chart1" runat="server" BackColor="#EFEEEF" BorderlineColor="#EFEEEF" BackSecondaryColor="#EFEEEF" Width="400px">
        <Titles>
        <asp:Title Text="Temperature [C]"></asp:Title>
      </Titles> 
        <Series>
            <asp:Series Name="Temperature" ChartType="Line"></asp:Series>
            <asp:Series Name="Temperature Predicted" ChartType="Line" Color="Red"></asp:Series>
            <asp:Series Name="Recommended level" ChartType="Line" Color="Green"></asp:Series>
            <asp:Series Name="Temperature Outside" ChartType="Line" Color="Orange"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
            <asp:Chart ID="Chart3" runat="server" BackColor="#EFEEEF" BorderlineColor="#EFEEEF" BorderlineWidth="2" BackSecondaryColor="#EFEEEF" Width="400px">
        <Titles>
        <asp:Title Text="Soil Humidity [%]"></asp:Title>
      </Titles> 
        <Series>
            <asp:Series Name="Soil Humidity" ChartType="Line"></asp:Series>
            <asp:Series Name="Soil Humidity Predicted" ChartType="Line" Color="Red"></asp:Series>
            <asp:Series Name="Recommended level" ChartType="Line" Color="Green"></asp:Series>
            <asp:Series Name="Humidity Outside" ChartType="Line" Color="Orange"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea3"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
        <br />

        <asp:Chart ID="Chart5" runat="server" BackColor="#EFEEEF" BorderlineColor="#EFEEEF" BorderlineWidth="2" BackSecondaryColor="#EFEEEF" Width="400px">
        <Titles>
        <asp:Title Text="CO2 levels [ppm]"></asp:Title>
      </Titles> 
        <Series>
            <asp:Series Name="CO2 levels" ChartType="Line"></asp:Series>
            <asp:Series Name="CO2 levels Predicted" ChartType="Line" Color="Red"></asp:Series>
            <asp:Series Name="Recommended level" ChartType="Line" Color="Green"></asp:Series>
            <asp:Series Name="CO2 levels Outside" ChartType="Line" Color="Orange"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea5"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
        <asp:Chart ID="Chart4" runat="server" BackColor="#EFEEEF" BorderlineColor="#EFEEEF" BorderlineWidth="2" BackSecondaryColor="#EFEEEF" Width="400px">
        <Titles>
        <asp:Title Text="Lighting [lux]"></asp:Title>
      </Titles> 
        <Series>
            <asp:Series Name="Lighting" ChartType="Line"></asp:Series>
            <asp:Series Name="Lighting Predicted" ChartType="Line" Color="Red"></asp:Series>
            <asp:Series Name="Recommended level" ChartType="Line" Color="Green"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea4"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
        
        <br />
        <asp:Label ID="Label4" runat="server" Font-Names="Consolas" Font-Size="XX-Large">Outside</asp:Label> <br />
            
    
    <asp:Chart ID="Chart6" runat="server" BackColor="#EFEEEF" BorderlineColor="#EFEEEF" BorderlineWidth="2" BackSecondaryColor="#EFEEEF" Width="400px">
        <Titles>
        <asp:Title Text="Temperature [C]"></asp:Title>
      </Titles> 
        <Series>
            <asp:Series Name="Temperature" ChartType="Line"></asp:Series>
            <asp:Series Name="Temperature Predicted" ChartType="Line" Color="Red"></asp:Series>
            <asp:Series Name="Recommended level" ChartType="Line" Color="Green"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea6"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
        <asp:Chart ID="Chart2" runat="server" BackColor="#EFEEEF" BorderlineColor="#EFEEEF" BorderlineWidth="2" BackSecondaryColor="#EFEEEF" Width="400px">
        <Titles>
        <asp:Title Text="Humidity [%]"></asp:Title>
      </Titles> 
        <Series>
            <asp:Series Name="Humidity" ChartType="Line"></asp:Series>
            <asp:Series Name="Humidity Predicted" ChartType="Line" Color="Red"></asp:Series>
            <asp:Series Name="Recommended level" ChartType="Line" Color="Green"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
         <br />
   <asp:Chart ID="Chart7" runat="server" BackColor="#EFEEEF" BorderlineColor="#EFEEEF" BorderlineWidth="2" BackSecondaryColor="#EFEEEF" Width="400px">
        <Titles>
        <asp:Title Text="CO2 levels [ppm]"></asp:Title>
      </Titles> 
        <Series>
            <asp:Series Name="CO2 levels" ChartType="Line"></asp:Series>
            <asp:Series Name="CO2 levels Predicted" ChartType="Line" Color="Red"></asp:Series>
            <asp:Series Name="Recommended level" ChartType="Line" Color="Green"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea7"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

    </div>
    </asp:Content>