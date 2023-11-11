namespace api_Delovyi_Linii.TemplateJsonClasses;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Address
{
    public string search { get; set; }

    public Address(string cityDerival)
    {
        search = cityDerival;
    }
}

public class Cargo
{
    public int weight { get; set; } = 0;
    public int height { get; set; } = 0;
    public int width { get; set; } = 0;
    public int length { get; set; } = 0;
    public double totalVolume { get; set; }
    public double totalWeight { get; set; }

    public Cargo(double mass, double volume)
    {
        totalWeight = mass;
        totalVolume = volume;
    }
}

public class Delivery
{
    public DeliveryType deliveryType { get; set; }
    public Derival derival { get; set; }

    public Delivery(string cityDerival)
    {
        derival = new Derival(cityDerival);
        deliveryType = new DeliveryType();
    }
}

public class DeliveryType
{
    public string type { get; set; } = "auto";
}

public class Derival
{
    public Address address { get; set; }
    public Time time { get; set; }

    public Derival(string cityDerival)
    {
        address = new Address(cityDerival);
        time = new Time();
    }
}

public class RequestGetDateDerival
{
    public string appkey { get; set; }
    public string sessionID { get; set; }
    public Delivery delivery { get; set; }
    public Cargo cargo { get; set; }

    public RequestGetDateDerival(string appkey, string sessionId, string cityDerival, double mass, double volume)
    {
        this.appkey = appkey;
        this.sessionID = sessionId;
        cargo = new Cargo(mass, volume);
        delivery = new Delivery(cityDerival);
    }
}

public class Time
{
    public bool exactTime { get; set; } = true;

}

