using ExcelDataReader;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using System.Reflection;

namespace MyWayApp23.Services;

public class UploadService
{
    private List<AssistenciasPRM> assistencias = new();
    public List<AssistenciasPRM>? Assistencias;

    public async Task<DataSet> ImportFileAsync(IBrowserFile stream)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        DataSet? result = new();

        using (var ms = new MemoryStream())
        {
            await stream.OpenReadStream().CopyToAsync(ms);

            using var reader = ExcelReaderFactory.CreateReader(ms);

            result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                // Gets or sets a value indicating whether to set the DataColumn.DataType 
                // property in a second pass.
                UseColumnDataType = true,

                // Gets or sets a callback to determine whether to include the current sheet
                // in the DataSet. Called once per sheet before ConfigureDataTable.
                //FilterSheet = (tableReader, sheetIndex) => true,

                // Gets or sets a callback to obtain configuration options for a DataTable. 
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    // Gets or sets a value indicating the prefix of generated column names.
                    EmptyColumnNamePrefix = "Column",

                    // Gets or sets a value indicating whether to use a row from the 
                    // data as column names.
                    UseHeaderRow = true,

                    // Gets or sets a callback to determine which row is the header row. 
                    // Only called when UseHeaderRow = true.
                    //ReadHeaderRow = (rowReader) =>
                    //{
                    //        // F.ex skip the first row and use the 2nd row as column headers:
                    //    rowReader.Read();
                    //},

                    // Gets or sets a callback to determine whether to include the 
                    // current row in the DataTable.
                    //FilterRow = (rowReader) =>
                    //{
                    //    return true;
                    //},

                    // Gets or sets a callback to determine whether to include the specific
                    // column in the DataTable. Called once per column after reading the 
                    // headers.
                    //FilterColumn = (rowReader, columnIndex) =>
                    //{
                    //    return true;
                    //}
                }
            });
        }
        DataTable dtt = result.Tables[0];
        assistencias = ConvertDataTable<AssistenciasPRM>(dtt);
        return result;
    }

    private static List<T> ConvertDataTable<T>(DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }
        return data;
    }
    private static T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }
}
