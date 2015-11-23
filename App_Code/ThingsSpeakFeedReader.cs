using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.UI.DataVisualization.Charting;

/// <summary>
/// Summary description for Class1
/// </summary>
public partial class ThingsSpeakFeedReader : Page
{
    public int channelID;
    public int noResults;
    public DateTime start;
    public DateTime end;
    public int timescale;
    bool extentedUrl = false;
    public int feedCount;

    public string[] dates, ids, temp, air, soil, light;

    public ThingsSpeakFeedReader(int channel, int results)
	{
        channelID = channel;
        noResults = results;
	}

    public ThingsSpeakFeedReader(int channel, int results, DateTime begin, DateTime stop, int timespan)
    {
        extentedUrl = true;
        channelID = channel;
        noResults = results;
        start = begin;
        end = stop;
        timescale = timespan;
    }

    public void readChannelFeed()
    {

        XmlDataDocument xmldoc = new XmlDataDocument();
        XmlNodeList xmlnode;
        int i = 0;
        //string str = null;
        xmldoc.Load(formHTTPrequest());
        xmlnode = xmldoc.GetElementsByTagName("feed");
        feedCount = xmlnode.Count;

        dates = new string[xmlnode.Count];
        ids = new string[xmlnode.Count];
        temp = new string[xmlnode.Count];
        air = new string[xmlnode.Count];
        soil = new string[xmlnode.Count];
        light = new string[xmlnode.Count];

        for (i = 0; i <= xmlnode.Count - 1; i++)
        {
            dates[i] = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
            ids[i] = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
            temp[i] = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
            air[i] = xmlnode[i].ChildNodes.Item(3).InnerText.Trim();
            soil[i] = xmlnode[i].ChildNodes.Item(4).InnerText.Trim();
            light[i] = xmlnode[i].ChildNodes.Item(5).InnerText.Trim();
            // str += xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
        }
        //urll = feedCount.ToString();
    }

    private string formHTTPrequest()
    {
        string url;
        string baseUrl = "https://api.thingspeak.com/channels/" + this.channelID.ToString() + "/feeds.xml?results=" + this.noResults.ToString();
        string extUrl;
        if (extentedUrl)
        {
            extUrl = baseUrl + "&start=" + start.ToString("yyyy-MM-dd HH:mm:ss") + "&end=" + end.ToString("yyyy-MM-dd HH:mm:ss");
            url = extUrl;
        }
        else
        {
            url = baseUrl;
        }

        return url;
    }
}