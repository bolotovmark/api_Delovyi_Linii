using api_Delovyi_Linii;

var client = new ClientDelovyiLinii("0F74D344-4281-4A25-A545-8A5A48566D44");

Console.WriteLine(await client.CalculatePrice("Пермь, Профессора Дедюкина 18", 12, 0.07));

//Console.WriteLine(await client.GetFirstDate("г. Чайковский, ул. Промышленная, 8/25", 1, 0.1)); 