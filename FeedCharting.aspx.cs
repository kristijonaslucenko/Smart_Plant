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
    public string[] f_dates, f_ids, f_temp, f_air, f_soil, f_light, f_co2_1, f_co2_2, f_out_temp;
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
        f_co2_1 = FeedReader.co2_1;
        f_co2_2 = FeedReader.co2_2;
        f_out_temp = FeedReader.out_temp;
        nodeCount = FeedReader.feedCount;
        bThick = 2;
        fbThick = 1;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Update();
        AddRecommendedLevels();
        //AddAnalysisToCharting(0, 7);
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
            Chart5.Series[0].Points.AddXY(f_dates[i].Substring(11, 5), f_co2_1[i]);
            Chart6.Series[0].Points.AddXY(f_dates[i].Substring(11, 5), f_co2_2[i]);
            Chart7.Series[0].Points.AddXY(f_dates[i].Substring(11, 5), f_out_temp[i]);
        }
  
        Chart1.Series[0].BorderWidth = bThick;
        Chart2.Series[0].BorderWidth = bThick;
        Chart3.Series[0].BorderWidth = bThick;
        Chart4.Series[0].BorderWidth = bThick;
        Chart5.Series[0].BorderWidth = bThick;
        Chart6.Series[0].BorderWidth = bThick;
        Chart7.Series[0].BorderWidth = bThick;

        Chart1.Series[1].BorderWidth = 1;
        Chart2.Series[1].BorderWidth = 1;
        Chart3.Series[1].BorderWidth = 1;
        Chart4.Series[1].BorderWidth = 1;
        Chart5.Series[1].BorderWidth = 1;
        Chart6.Series[1].BorderWidth = 1;
        Chart7.Series[1].BorderWidth = 1;

        Chart1.Series[2].BorderWidth = bThick;
        Chart2.Series[2].BorderWidth = bThick;
        Chart3.Series[2].BorderWidth = bThick;
        Chart4.Series[2].BorderWidth = bThick;
        Chart5.Series[2].BorderWidth = bThick;
        Chart6.Series[2].BorderWidth = bThick;
        Chart7.Series[2].BorderWidth = bThick;

        Chart1.Series[3].BorderWidth = bThick;
        Chart3.Series[3].BorderWidth = bThick;
        Chart5.Series[3].BorderWidth = bThick;


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
                Chart5.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear," + days + ", false, false", Chart5.Series[0], Chart5.Series[1]);
                Chart6.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear," + days + ", false, false", Chart6.Series[0], Chart6.Series[1]);
                Chart7.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear," + days + ", false, false", Chart7.Series[0], Chart7.Series[1]);
                break;
            case 1:
                Chart1.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart1.Series[0].Name + ":Y", Chart1.Series[1].Name + ":Y");
                Chart2.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart2.Series[0].Name + ":Y", Chart2.Series[1].Name + ":Y");
                Chart3.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart3.Series[0].Name + ":Y", Chart3.Series[1].Name + ":Y");
                Chart4.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart4.Series[0].Name + ":Y", Chart4.Series[1].Name + ":Y");
                Chart5.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart5.Series[0].Name + ":Y", Chart5.Series[1].Name + ":Y");
                Chart6.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart6.Series[0].Name + ":Y", Chart6.Series[1].Name + ":Y");
                Chart7.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, days.ToString(), Chart7.Series[0].Name + ":Y", Chart7.Series[1].Name + ":Y");
                break;
            case 2:
                CleanCharts(1);
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
                    
                    AddAnalysisToCharting(2, daysForForecast);

                    break;
                case 1:

                    AddAnalysisToCharting(0, daysForForecast);

                    break;
                case 2:

                    AddAnalysisToCharting(0, daysForForecast);

                    break;
                case 3:

                    AddAnalysisToCharting(0, daysForForecast);

                    break;
                case 4:

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
                    f_co2_1 = FeedReader.co2_1;
                    f_co2_2 = FeedReader.co2_2;
                    f_out_temp = FeedReader.out_temp;
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
                    f_co2_1 = FeedReader1.co2_1;
                    f_co2_2 = FeedReader1.co2_2;
                    f_out_temp = FeedReader1.out_temp;
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
                    f_co2_1 = FeedReader2.co2_1;
                    f_co2_2 = FeedReader2.co2_2;
                    f_out_temp = FeedReader2.out_temp;
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
                    f_co2_1 = FeedReader4.co2_1;
                    f_co2_2 = FeedReader4.co2_2;
                    f_out_temp = FeedReader4.out_temp;
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
            f_co2_1 = FeedReader.co2_1;
            f_co2_2 = FeedReader.co2_2;
            f_out_temp = FeedReader.out_temp;
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
        int recommendedTemp = 26;
        int recommendedAir = 24;
        int recommendedSoil = 40;
        int recommendedlighting = 25;
        int recommendedco2_1 = 300;
        int recommendedco2_2_out = 250;
        int recommended_out_temp = 22;

        CleanCharts(2);

        for (int i = 0; i < nodeCount; i++)
        {
            Chart1.Series[2].Points.AddY(recommendedTemp);
            Chart2.Series[2].Points.AddY(recommendedAir);
            Chart3.Series[2].Points.AddY(recommendedSoil);
            Chart4.Series[2].Points.AddY(recommendedlighting);
            Chart5.Series[2].Points.AddY(recommendedco2_1);
            Chart6.Series[2].Points.AddY(recommended_out_temp);
            Chart7.Series[2].Points.AddY(recommendedco2_2_out);
        }
    }

    private void CleanCharts(int series)
    {
        Chart1.Series[series].Points.Clear();
        Chart2.Series[series].Points.Clear();
        Chart3.Series[series].Points.Clear();
        Chart4.Series[series].Points.Clear();
        Chart5.Series[series].Points.Clear();
        Chart6.Series[series].Points.Clear();
        Chart7.Series[series].Points.Clear();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //CleanCharts(3);

        for (int i = 0; i <= nodeCount - 1; i++)
        {
            Chart1.Series[3].Points.AddY(f_co2_2[i]);
            Chart3.Series[3].Points.AddY(f_air[i]);
            Chart5.Series[3].Points.AddY(f_out_temp[i]);
        }
    }
}