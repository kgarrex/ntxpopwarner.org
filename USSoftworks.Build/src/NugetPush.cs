using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

public class NugetPush : Microsoft.Build.Utilities.Task
{
  [Required] public ITaskItem[] ServiceIndexes { get; set; } /// <value>A JSON document describing the entry point resources</value>
  [Required] public ITaskItem NupkgFile { get; set; }        /// <value>The .nupkg file being pushed</value>
  [Required] public string ApiKey { get; set; }              /// <value>The secure API key</value>
  public ITaskItem Certificate { get; set; }                 /// <value>The certificate (.cer) file used to sign a package</value>
  public string SessionId { get; set; }                      /// <value>An optional client session to identify HTTP requests</value>
  public int Version { get; set; }                           /// <value>The NuGet API version</value>
  public override bool Execute()
  {
    try
    {
      string nupkgFile = NupkgFile.ItemSpec;
      string nupkgFileName = $"{NupkgFile.GetMetadata("Filename")}.{NupkgFile.GetMetadata("Extension")}";
      if(!File.Exists(nupkgFile)) throw new FileNotFoundException();
      FileInfo fileInfo = new FileInfo(nupkgFile);
      Log.LogMessage(MessageImportance.High, $"Filename: {nupkgFileName}");

      FileStream stream = new FileStream(nupkgFile, FileMode.Open);
      MultipartFormDataContent form = new MultipartFormDataContent();
      using HttpContent content = new StreamContent(stream);
      content.Headers.ContentLength = fileInfo.Length;
      content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
      //content.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
      form.Add(content, "nupkg", nupkgFileName);
      using HttpClient client = new HttpClient();
      for(int i = 0; i < ServiceIndexes.Length; ++i)
      {
        var uriString = ServiceIndexes[i].ItemSpec;
        if(!Uri.IsWellFormedUriString(uriString, UriKind.Absolute)) throw new Exception();
        var uri = new Uri(uriString);
        var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Headers.Add("X-NuGet-ApiKey", ApiKey);
        request.Content = content;
        Log.LogMessage(MessageImportance.High, "Sending .nupkg to NuGet server...");
        System.Threading.Tasks.Task<HttpResponseMessage> task = client.SendAsync(request);
        task.Wait();
        HttpResponseMessage response = task.Result;
        response.EnsureSuccessStatusCode();
        Log.LogMessage(MessageImportance.High, "File sent!");
      }
    }
    catch(Exception ex)
    {
      Log.LogErrorFromException(ex);
    }
    return !Log.HasLoggedErrors;
  }
}
