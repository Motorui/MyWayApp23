using ExcelDataReader;
using Microsoft.AspNetCore.Components.Forms;

namespace MyWayApp23.Services;

public class ReadExcelService : IReadExcelService
{
    public async Task<DataTable> ReadExcelAsync(IBrowserFile stream)
    {
        System.Text.Encoding.RegisterProvider(
            System.Text.CodePagesEncodingProvider.Instance);

        DataSet? result = new();

        using (var ms = new MemoryStream())
        {
            await stream.OpenReadStream(30000000).CopyToAsync(ms);

            using var reader = ExcelReaderFactory.CreateReader(ms);

            result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                // Gets or sets a value indicating whether to set the DataColumn.DataType 
                // property in a second pass.
                UseColumnDataType = true,

                // Gets or sets a callback to obtain configuration options for a DataTable. 
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    // Gets or sets a value indicating the prefix of generated column names.
                    EmptyColumnNamePrefix = "Column",

                    // Gets or sets a value indicating whether to use a row from the 
                    // data as column names.
                    UseHeaderRow = true,
                }
            });
        }
        DataTable dt = result.Tables[0];
        return dt;
    }

}
