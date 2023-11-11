namespace api_Delovyi_Linii.TemplateJsonClasses;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Data
{
    public string? sessionID { get; set; }
}

public class Metadata
{
    public int? status { get; set; }
    public string? generated_at { get; set; }
}

public class ResponceAuth
{
    public Metadata metadata { get; set; }
    public Data data { get; set; }
}
