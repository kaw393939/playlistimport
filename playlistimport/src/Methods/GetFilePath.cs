namespace playlistimport.Methods;


public class GetFilePath
{
    string? file;
        
    public GetFilePath(string? filePath)
    {
        file = string.IsNullOrEmpty(filePath) ? "ERROR: File not found" : filePath;
    }

    public string? DisplayFilePath()
    {
        return file;
    }
}