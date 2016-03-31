using System;
using System.Data;
using icalParser;
using Xunit;

namespace UnitTest
{
  public class EndDateParserTester
  {
    [Fact]
    public void StartDateNoEnd()
    {
      var item = ItemBL.CreateItem("2016-03-15;;Repetition;Cozmoz;;");
      Assert.Equal(item.StartDate, item.EndDate);
    }
    [Fact]
    public void StartDateAndTimeNoEnd()
    {
      var item = ItemBL.CreateItem("2016-03-15 18:00;;Repetition;Cozmoz;;");
      Assert.Equal(item.StartDate.AddHours(3), item.EndDate);
    }

    [Fact]
    public void StartDateTimeDuration()
    {
      var item = ItemBL.CreateItem("2016-03-15 18:00;2,5;Repetition;Cozmoz;;");
      Assert.Equal(item.StartDate.AddHours(2.5), item.EndDate);
    }

    [Fact]
    public void StartDateDuration()
    {
      var item = ItemBL.CreateItem("2016-03-15;2,5;Repetition;Cozmoz;;");
      Assert.Equal(item.StartDate, item.EndDate);
    }

    [Fact]
    public void StartDateEndDate()
    {
      var item = ItemBL.CreateItem("2016-03-15;2016-03-15;Repetition;Cozmoz;;");
      Assert.Equal(item.StartDate, item.EndDate);
    }

    [Fact]
    public void StartDateTimeEndDateTime()
    {
      var item = ItemBL.CreateItem("2016-03-15 18:00;2016-03-15 19:00;Repetition;Cozmoz;;");
      Assert.Equal(item.StartDate.AddHours(1), item.EndDate);
    }

    [Fact]
    public void DiffDatesStartDateEndDate()
    {
      var item = ItemBL.CreateItem("2016-03-15;2016-03-17;Repetition;Cozmoz;;");
      Assert.Equal(item.StartDate.AddDays(2), item.EndDate);
    }

  }

}

