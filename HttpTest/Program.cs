using System.Globalization;
using Net.Utilities.IO.Directory;
using Net.Utilities.IO.File;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/*var directoryPath1 = "C:\\Users\\xkz19\\Desktop\\20230117\\参数表单";
var directoryPath2 = "C:\\Users\\xkz19\\Desktop\\参数表单";
var isStart = true;
var fileList = new Queue<string>();
DirectoryHelper.FindAllFilePathByDirectory(ref isStart, fileList, directoryPath2,
    DateTime.MinValue);

foreach (var filePath in fileList.Where(s => FileHelper.GetFileNameExtension(s) is ".xls" or ".xlsx"))
{
    await using var fileStream = FileHelper.GetFileStream(filePath, false);
    using var client = new HttpClient();
    using var content =
        new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
    content.HeaderEncodingSelector = null;
    content.Add(new StreamContent(fileStream), "file", FileHelper.GetFileName(filePath));
    using var message = await client.PostAsync("http://localhost:8008/file/upload", content);
    var input = await message.Content.ReadAsStringAsync();
    var format = JToken.Parse(input).ToString(Formatting.Indented);
    FileHelper.WriteText(
        $"{FileHelper.GetDirectoryName(filePath)}\\{FileHelper.GetFileNameWithoutExtension(filePath)}.json", format);
    Console.WriteLine(format);
}*/


var directoryPath1 = "C:\\Users\\xkz19\\Desktop\\20230117\\点检表单";
var isStart = true;
var fileList = new Queue<string>();
DirectoryHelper.FindAllFilePathByDirectory(ref isStart, fileList, directoryPath1,
    DateTime.MinValue);

foreach (var filePath in fileList.Where(s => FileHelper.GetFileNameExtension(s) is ".xls" or ".xlsx"))
{
    await using var fileStream = FileHelper.GetFileStream(filePath, false);
    using var client = new HttpClient();
    using var content =
        new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
    content.HeaderEncodingSelector = null;
    content.Add(new StreamContent(fileStream), "file", FileHelper.GetFileName(filePath));
    using var message = await client.PostAsync("http://localhost:8008/file/uploadInspectionExcel", content);
    var input = await message.Content.ReadAsStringAsync();
    var format = JToken.Parse(input).ToString(Formatting.Indented);
    FileHelper.WriteText(
        $"{FileHelper.GetDirectoryName(filePath)}\\{FileHelper.GetFileNameWithoutExtension(filePath)}.json", format);
    Console.WriteLine(format);
}
