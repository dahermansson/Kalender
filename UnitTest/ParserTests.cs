using icalParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace UnitTest
{
  public class ParserTests
  {
    [Fact]
    public void MissingSplits()
    {
      var item = ItemBL.CreateItem("2016-03-15;;Repetition;Cozmoz;");
      Assert.Null(item);
    }
    [Fact]
    public void ToManySplits()
    {
      var item = ItemBL.CreateItem("2016-03-15;;Repetition;Cozmoz;;;");
      Assert.Null(item);
    }
    [Fact]
    public void Splits()
    {
      var item = ItemBL.CreateItem("2016-03-15;;Repetition;Cozmoz;;");
      Assert.NotNull(item);
    }
    [Fact]
    public void IsAllDay1()
    {
      var item = ItemBL.CreateItem("2016-03-15;;Repetition;Cozmoz;;");
      Assert.True(item.IsAllDay);
    }
    [Fact]
    public void IsAllDay2()
    {
      var item = ItemBL.CreateItem("2016-03-15;2016-03-15;Repetition;Cozmoz;;");
      Assert.True(item.IsAllDay);
    }
    [Fact]
    public void IsAllDays1()
    {
      var item = ItemBL.CreateItem("2016-03-15;2016-03-17;Repetition;Cozmoz;;");
      Assert.True(item.IsAllDay);
    }

    [Fact]
    public void IsAllDays2()
    {
      var item = ItemBL.CreateItem("2016-03-15 18:00;2016-03-17 16:30;Repetition;Cozmoz;;");
      Assert.True(item.IsAllDay);
    }
  }
}
