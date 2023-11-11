namespace api_Delovyi_Linii.TemplateJsonClasses;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AddressCalculatePrice
{
    public string search { get; set; }

    public AddressCalculatePrice(string city)
    {
        search = city;
    }
}

public class ArrivalCalculatePrice
{
    public string variant { get; set; } = "address";
    public AddressCalculatePrice address { get; set; }
    public TimeCalculatePrice time { get; set; }

    public ArrivalCalculatePrice(string city)
    {
        address = new AddressCalculatePrice(city);
        time = new TimeCalculatePrice();
    }
}

public class CargoCalculatePrice
{
    public int length { get; set; } = 0;
    public int width { get; set; } = 0;
    public int height { get; set; } = 0;
    public double totalVolume { get; set; } = 0;
    public double totalWeight { get; set; }
    public double hazardClass { get; set; }

    public CargoCalculatePrice(double mass, double volume)
    {
        totalWeight = mass;
        totalVolume = volume;
    }
}

public class DeliveryCalculatePrice
{
    public DeliveryTypeCalculatePrice deliveryType { get; set; }
    public ArrivalCalculatePrice arrival { get; set; }
    public DerivalCalculatePrice derival { get; set; }

    public DeliveryCalculatePrice(string cityArrival, string cityDerival, string date)
    {
        deliveryType = new DeliveryTypeCalculatePrice();
        arrival = new ArrivalCalculatePrice(cityArrival);
        derival = new DerivalCalculatePrice(cityDerival, date);
    }
}

public class DeliveryTypeCalculatePrice
{
    public string type { get; set; } = "auto";
}

public class DerivalCalculatePrice
{
    public string produceDate { get; set; }
    public string variant { get; set; } = "address";
    public AddressCalculatePrice address { get; set; }
    public TimeCalculatePrice time { get; set; }

    public DerivalCalculatePrice(string cityDerival, string date)
    {
        produceDate = date;
        address = new AddressCalculatePrice(cityDerival);
        time = new TimeCalculatePrice();
    }
}

public class RequestCalculatePrice
{
    public string appkey { get; set; }
    public string sessionID { get; set; }
    public DeliveryCalculatePrice delivery { get; set; }
    public CargoCalculatePrice cargo { get; set; }

    public RequestCalculatePrice(string appkey, string sessionId, 
        string cityArrival, string cityDerival, string date, double mass, double volume)
    {
        this.appkey = appkey;
        this.sessionID = sessionId;
        delivery = new DeliveryCalculatePrice(cityArrival, cityDerival, date);
        cargo = new CargoCalculatePrice(mass, volume);
    }
}

public class TimeCalculatePrice
{
    public string worktimeStart { get; set; } = "08:00";
    public string worktimeEnd { get; set; } = "17:00";
}

