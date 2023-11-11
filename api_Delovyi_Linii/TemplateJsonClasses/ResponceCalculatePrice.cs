namespace api_Delovyi_Linii.TemplateJsonClasses;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Arrival
    {
        public string terminal { get; set; }
        public double price { get; set; }
        public double servicePrice { get; set; }
        public bool contractPrice { get; set; }
        public List<object> premiumDetails { get; set; }
        public List<object> discountDetails { get; set; }
        public List<object> terminals { get; set; }
    }

    public class AvailableDeliveryTypes
    {
        public double auto { get; set; }
        public double express { get; set; }
        public double small { get; set; }
    }

    public class DataResCalculatePrice
    {
        public DerivalResCalculatePrice derival { get; set; }
        public Intercity intercity { get; set; }
        public Arrival arrival { get; set; }
        public double price { get; set; }
        public string priceMinimal { get; set; }
        public OrderDates orderDates { get; set; }
        public int deliveryTerm { get; set; }
        public double insurance { get; set; }
        public InsuranceComponents insuranceComponents { get; set; }
        public Notify notify { get; set; }
        public bool simpleShippingAvailable { get; set; }
        public AvailableDeliveryTypes availableDeliveryTypes { get; set; }
        public List<FoundAddressResCalculatePrice> foundAddresses { get; set; }
    }

    public class DerivalResCalculatePrice
    {
        public string terminal { get; set; }
        public double price { get; set; }
        public double servicePrice { get; set; }
        public bool contractPrice { get; set; }
        public List<object> premiumDetails { get; set; }
        public List<object> discountDetails { get; set; }
        public List<object> terminals { get; set; }
    }

    public class FoundAddressResCalculatePrice
    {
        public string source { get; set; }
        public string result { get; set; }
        public string field { get; set; }
    }

    public class InsuranceComponents
    {
        public double cargoInsurance { get; set; }
        public double termInsurance { get; set; }
        public bool contractPrice { get; set; }
    }

    public class Intercity
    {
        public double price { get; set; }
        public bool contractPrice { get; set; }
        public double premium { get; set; }
        public int discount { get; set; }
        public List<PremiumDetail> premiumDetails { get; set; }
        public List<object> discountDetails { get; set; }
    }

    public class MetadataResCalculatePrice
    {
        public int status { get; set; }
        public string generated_at { get; set; }
    }

    public class Notify
    {
        public double price { get; set; }
        public bool contractPrice { get; set; }
        public int premium { get; set; }
        public int discount { get; set; }
        public List<object> premiumDetails { get; set; }
        public List<object> discountDetails { get; set; }
    }

    public class OrderDates
    {
        public string pickup { get; set; }
        public object arrivalToOspSender { get; set; }
        public string derivalFromOspSender { get; set; }
        public string arrivalToOspReceiver { get; set; }
        public string derivalFromOspReceiver { get; set; }
    }

    public class PremiumDetail
    {
        public string name { get; set; }
        public double value { get; set; }
        public object date { get; set; }
        public bool announcement { get; set; }
        public bool @public { get; set; }
    }

    public class ResponceCalculatePrice
    {
        public MetadataResCalculatePrice metadata { get; set; }
        public DataResCalculatePrice data { get; set; }
    }

