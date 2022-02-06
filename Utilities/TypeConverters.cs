using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Utilities;

public class CustomIntConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (text != "")
        {
            return int.Parse(text);
        }
        else
        {
            return 0;
        }
    }
}
//converting for year
public class CustomDateYearConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (text != "")
        {
            var year = int.Parse(text);

            var date = new DateOnly(year, 1, 1);
            return date;
        }
        else
        {
            var date = new DateOnly(1, 1, 1);
            return date;
        }
    }
}
