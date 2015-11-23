<%@ Page Title="Smart plant" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>See how your plant is doing</h2>
            </hgroup>
           
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
         <p>
                <iframe width="450" height="260" style="border: 1px solid #cccccc;" src="http://api.thingspeak.com/channels/62720/charts/4?width=450&height=260&results=200&dynamic=true&bgcolor=%23EEEEEE&color=%2300AA00&yaxis=Lux&xaxis=Date&title=Light" ></iframe>
                <iframe width="450" height="260" style="border: 1px solid #cccccc;" src="http://api.thingspeak.com/channels/62720/charts/1?width=450&height=260&results=200&dynamic=true&bgcolor=%23EEEEEE&color=%2300AA00&yaxis=Degrees%20(celcius)&xaxis=Date&title=Temperature" ></iframe>
                <br />
                <iframe width="450" height="260" style="border: 1px solid #cccccc;" src="http://api.thingspeak.com/channels/62720/charts/2?width=450&height=260&results=200&dynamic=true&bgcolor=%23EEEEEE&color=%2300AA00&yaxis=Humidity%20(%25)&xaxis=Date&title=Humidity%20Air" ></iframe>
                <iframe width="450" height="260" style="border: 1px solid #cccccc;" src="http://api.thingspeak.com/channels/62720/charts/3?width=450&height=260&results=200&dynamic=true&bgcolor=%23EEEEEE&color=%2300AA00&yaxis=Humidity%20(%25)&xaxis=Date&title=Humidity%20Soil" ></iframe>
            </p>
        <asp:Label runat="server" id="Hello"></asp:Label>
    </div>

    

    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            
            <h5>Getting Started</h5>
            Sign up and sync your plants in two minutes!
        </li>
        <li class="two">
            <h5>See how are you plants are doing at a given moment.</h5>
            See four different parameters about your plant growing coditions.
        </li>
        <li class="three">
            <h5>Analyze the data, see predictions</h5>
            Daily, weekly and monthly forecasts.
        </li>
    </ol>
</asp:Content>