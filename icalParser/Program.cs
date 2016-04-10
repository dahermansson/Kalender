using System.IO;

namespace icalParser
{
  class Program
  {
    static void Main(string[] args)
    {
      var bytes = ICalCreator.ICalCreator.CreateIcal();
      File.Create("live.ics").Write(bytes, 0, bytes.Length);
    }
    
  }
}
