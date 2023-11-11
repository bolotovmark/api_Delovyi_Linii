using System.Threading.Channels;
using api_Delovyi_Linii;

var client = new ClientDelovyiLinii("+79026383938", "fb2GiEz5ztcsmnk", "0F74D344-4281-4A25-A545-8A5A48566D44");

Console.WriteLine(await client.CalculatePrice("Пермь, Профессора Дедюкина 18", 1, 0.1));

