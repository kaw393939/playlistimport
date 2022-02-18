namespace Music;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
public class StringYearToDateConverter : DefaultTypeConverter
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