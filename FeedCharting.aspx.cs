using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.UI.DataVisualization.Charting;

public partial class FeedCharting : System.Web.UI.Page
{
    public string[] f_dates, f_ids, f_temp, f_air, f_soil, f_light;
    private int nodeCount, bThick, fbThick;

    public int channelID = 62720;
    public int resultsCnt = 200;
    int timeSpanCriteria;
    int daysForForecast;
    string period = "begining - end.";

    public FeedCharting()
    {
        ThingsSpeakFeedReader FeedReader = new ThingsSpeakFeedReader(channelID, resultsCnt);

        f_dates = FeedReader.dates;
        f_ids = FeedReader.ids;
        f_temp = FeedReader.temp;
        f_air = FeedReader.air;
        f_soil = FeedReader.soil;
        f_light = FeedReader.light;
        nodeCount = FeedReader.feedCount;
        bThick = 2;
        fbThick = 3;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Update();
        AddRecommendedLevels();
        AddAnalysisToCharting(0, 7);
        Label1.Text = nodeCount.ToString();
        Label2.Text = period;
    }

    public void VisualizeFeed()
    {
        CleanCharts(0);
        CleanCharts(1);
        CleanCharts(2);

        for (int i = 0; i <= nodeCount - 1; i++)
        {
            Chart1.Series[0].Points.AddXY(f_dates[i].Substring(11, 5), f_temp[i]);
            Chart2.Series[0].Points.AddXY(f_dates[i].Substring(11, 5), f_air[i]);
            Chart3.Series[0].Points.AddXY(f_dates[i].Substring(11, 5), f_soil[i]);
            Chart4.Series[0].Points.AddXY(f_dates[i].Substring(11, 5), f_light[i]);
        }
  
        Chart1.Series[0].BorderWidth = bThick;
        Chart2.Series[0].BorderWidth = bThick;
        Chart3.Series[0].BorderWidth = bThick;
        Chart4.Series[0].BorderWidth = bThick;

        Chart1.Series[1].BorderWidth = fbThick;
        Chart2.Series[1].BorderWidth = fbThick;
        Chart3.Series[1].BorderWidth = fbThick;
        Chart4.Series[1].BorderWidth = fbThick;

        Chart1.Series[2].BorderWidth = bThick;
        Chart2.Series[2].BorderWidth = bThick;
        Chart3.Series[2].BorderWidth = bThick;
        Chart4.Series[2].BorderWidth = bThick;

        if (CheckBox_rec.Checked)
        {
            AddRecommendedLevels();
        }
        else
        {
            CleanCharts(2);
        }
    }

    public void AddAnalysisToCharting(int type, int days)
    {
        CleanCharts(1);

        switch (type)
        {
            case 0:
                Chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear," + days + ", false, false", Chart1.Series[0], Chart1.Series[1]);
                Chart2.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear," + days + ", false, false", Chart2.Series[0], Chart2.Series[1]);
                Chart3.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear," + days + ", false, false", Chart3.Series[0], Chart3.Series[1]);
                Chart4.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear," + days + ", false, false", Chart4.Series[0], Chart4.Series[1]);
                break;
            case 1:
                Chart1.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart1.Series[0].Name + ":Y", Chart1.Series[1].Name + ":Y");
                Chart2.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart2.Series[0].Name + ":Y", Chart2.Series[1].Name + ":Y");
                Chart3.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart3.Series[0].Name + ":Y", Chart3.Series[1].Name + ":Y");
                Chart4.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart4.Series[0].Name + ":Y", Chart4.Series[1].Name + ":Y");
                break;
        }
        
    }
    protected void DropDownTimeSpan_SelectedIndexChanged(object sender, EventArgs e)
    {
        timeSpanCriteria = Int32.Parse(DropDownTimeSpan.SelectedItem.Value);
        Update();
        Label1.Text = nodeCount.ToString();
        Label2.Text = period;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        daysForForecast = Int32.Parse(DropDownList2.SelectedItem.Value);
 
            switch (DropDownList2.SelectedIndex)
            {
                case 0:
                    
                    AddAnalysisToCharting(0, daysForForecast);

                    break;
                case 1:

                    AddAnalysisToCharting(0, daysForForecast);

                    break;
                case 2:

                    AddAnalysisToCharting(0, daysForForecast);

                    break;
                case 3:

                    AddAnalysisToCharting(1, daysForForecast);

                    break;
            }
           // Label2.Text = DropDownList2.SelectedIndex.ToString();
            Label1.Text = daysForForecast.ToString();
        }


    private void Update()
    {
        timeSpanCriteria = Int32.Parse(DropDownTimeSpan.SelectedItem.Value);
        daysForForecast = Int32.Parse(DropDownList2.SelectedItem.Value);

        int userDefinedPeriod = 60;

        if (DropDownTimeSpan.SelectedIndex != 0)
        {
            switch (timeSpanCriteria)
            {
                case 1:
                    ThingsSpeakFeedReader FeedReader = new ThingsSpeakFeedReader(channelID, resultsCnt, DateTime.Today.AddDays(-1), DateTime.Today, 0);
                    FeedReader.readChannelFeed();
                    f_dates = FeedReader.dates;
                    f_air = FeedReader.air;
                    f_ids = FeedReader.ids;
                    f_temp = FeedReader.temp;
                    f_soil = FeedReader.soil;
                    f_light = FeedReader.light;
                    nodeCount = FeedReader.feedCount;
                    period = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + " - " + DateTime.Today.ToString("yyyy-MM-dd");
                    break;
                case 2:
                    ThingsSpeakFeedReader FeedReader1 = new ThingsSpeakFeedReader(channelID, resultsCnt, DateTime.Today.AddDays(-7), DateTime.Today, 0);
                    FeedReader1.readChannelFeed();
                    f_dates = FeedReader1.dates;
                    f_ids = FeedReader1.ids;
                    f_air = FeedReader1.air;
                    f_temp = FeedReader1.temp;
                    f_soil = FeedReader1.soil;
                    f_light = FeedReader1.light;
                    nodeCount = FeedReader1.feedCount;
                    period = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") + " - " + DateTime.Today.ToString("yyyy-MM-dd");
                    break;
                case 3:
                    ThingsSpeakFeedReader FeedReader2 = new ThingsSpeakFeedReader(channelID, resultsCnt, DateTime.Today.AddDays(-30), DateTime.Today, 0);
                    FeedReader2.readChannelFeed();
                    f_dates = FeedReader2.dates;
                    f_ids = FeedReader2.ids;
                    f_air = FeedReader2.air;
                    f_temp = FeedReader2.temp;
                    f_soil = FeedReader2.soil;
                    f_light = FeedReader2.light;
                    nodeCount = FeedReader2.feedCount;
                    period = DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd") + " - " + DateTime.Today.ToString("yyyy-MM-dd");
                    break;
                case 4:
                    ThingsSpeakFeedReader FeedReader4 = new ThingsSpeakFeedReader(channelID, resultsCnt, DateTime.Today.AddDays(userDefinedPeriod), DateTime.Today, 0);
                    f_dates = FeedReader4.dates;
                    f_ids = FeedReader4.ids;
                    f_air = FeedReader4.air;
                    f_temp = FeedReader4.temp;
                    f_soil = FeedReader4.soil;
                    f_light = FeedReader4.light;
                    nodeCount = FeedReader4.feedCount;
                    break;
            }
        }
        else
        {
            ThingsSpeakFeedReader FeedReader = new ThingsSpeakFeedReader(channelID, resultsCnt);
            FeedReader.readChannelFeed();
            f_dates = FeedReader.dates;
            f_ids = FeedReader.ids;
            f_air = FeedReader.air;
            f_temp = FeedReader.temp;
            f_soil = FeedReader.soil;
            f_light = FeedReader.light;
            nodeCount = FeedReader.feedCount;
            //url = FeedReader.urll;
        }
        VisualizeFeed();
    }
    protected void CheckBox_rec_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox_rec.Checked)
        {
            AddRecommendedLevels();
        }
        else
        {
            CleanCharts(2);
        }
    }

    private void AddRecommendedLevels()
    {
        int recommendedTemp = 22;
        int recommendedAir = 7;
        int recommendedSoil = 4;
        int recommendedlighting = 25;

        CleanCharts(2);

        for (int i = 0; i < nodeCount; i++)
        {
            Chart1.Series[2].Points.AddY(recommendedTemp);
            Chart2.Series[2].Points.AddY(recommendedAir);
            Chart3.Series[2].Points.AddY(recommendedSoil);
            Chart4.Series[2].Points.AddY(recommendedlighting);
        }
    }

    private void CleanCharts(int series)
    {
        Chart1.Series[series].Points.Clear();
        Chart2.Series[series].Points.Clear();
        Chart3.Series[series].Points.Clear();
        Chart4.Series[series].Points.Clear();
    }
            
}