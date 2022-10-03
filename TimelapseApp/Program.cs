// See https://aka.ms/new-console-template for more information

var targetUrl = "";

try
{
    var httpClient = new HttpClient();
    var uri = new Uri(targetUrl);
    var stream = await httpClient.GetStreamAsync(uri);

    var timeOffset = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(8));
    var fileName = $"./{timeOffset:yyyyMMddHHmm}.jpeg";
    Console.WriteLine(fileName);
    await using var fs = new FileStream(fileName, FileMode.CreateNew);
    await stream.CopyToAsync(fs);
}
catch (Exception exception)
{
    Console.WriteLine(exception.ToString());
}