namespace api_Delovyi_Linii.TemplateJsonClasses;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class DataResponceGetDateDerival
{
    public List<string> dates { get; set; }
    public List<FoundAddress> foundAddresses { get; set; }
}

public class FoundAddress
{
    public string field { get; set; }
    public string source { get; set; }
    public string result { get; set; }
}

public class MetadataResponceDataDerival
{
    public int status { get; set; }
    public string generated_at { get; set; }
}

public class ResponceGetDateDerival
{
    public MetadataResponceDataDerival metadata { get; set; }
    public DataResponceGetDateDerival data { get; set; }
}

