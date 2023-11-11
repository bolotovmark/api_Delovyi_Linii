namespace api_Delovyi_Linii.TemplateJsonClasses;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class RequestAuth
{
    public string appkey { get; set; }
    public string login { get; set; }
    public string password { get; set; }

    public RequestAuth(string appkey, string login, string password)
    {
        this.appkey = appkey;
        this.login = login;
        this.password = password;
    }
}

