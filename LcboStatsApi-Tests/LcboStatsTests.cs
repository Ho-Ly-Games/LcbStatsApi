namespace LcboStatsApi_Tests;

using LcboStatsApi;
using NUnit.Framework;
using System.Threading.Tasks;

public class Tests
{
    private LcboStatsClient _lcboClient;

    [SetUp]
    public void Setup()
    {
        // Create the client
        _lcboClient = new LcboStatsClient();
    }

    [Test]
    public async Task GetProductsAsync_ReturnsProducts_WhenRequestIsSuccessful()
    {
        // Act
        var result = await _lcboClient.GetProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(2, result.Products.Length);
        Assert.AreEqual("Product 1", result.Products[0].Name);
    }

    [Test]
    public async Task GetProductsAsync_ReturnsEmptyList_WhenRequestFails()
    {
        // Act
        var result = await _lcboClient.GetProductsAsync("Canadian Club Whisky");

        // Assert
        Assert.NotNull(result);
        Assert.IsEmpty(result.Products);
    }

    [Test]
    public async Task GetProductAsync_ReturnsProduct_WhenRequestIsSuccessful()
    {
        var json = """
                   {
                         "permanent_id": 463,
                         "title": "Canadian Club Whisky",
                         "brand": "Canadian Club",
                         "category": "Spirits",
                         "subcategory": "Whisky",
                         "price": 17.5,
                         "volume": 375,
                         "price_index": 0.11666666666667,
                         "alcohol_content": 40,
                         "country": "Canada",
                         "url": "https://www.lcbo.com/en/canadian-club-whisky-463",
                         "thumbnail_url": "https://aem.lcbo.com/content/dam/lcbo/products/0/0/0/4/000463.jpg.thumb.319.319.png",
                         "image_url": "https://aem.lcbo.com/content/dam/lcbo/products/0/0/0/4/000463.jpg.thumb.1280.1280.png",
                         "rating": 4.6,
                         "reviews": 283,
                         "out_of_stock": true,
                         "description": "The legend of Canadian Club began in 1858 and grew to become one of the world's most iconic whiskies. Pouring a medium gold you will find aromas of roasted almond, vanilla and pepper; with spicy vanilla, cornflakes and a faint nutty flavour on a medium weight palate with a long finish.",
                         "is_buyable": 1
                   }
                   """;

        // Arrange
        // var mockResponse = JsonSerializer.Deserialize<Product>(json);

        // Act
        var result = await _lcboClient.GetProductAsync("463");

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result?.Id, Is.EqualTo(463));
            Assert.That(result?.Name, Is.EqualTo("Canadian Club Whisky"));
        });
    }

    [Test]
    public async Task GetProductAsync_ReturnsNull_WhenRequestFails()
    {
        // Act
        var result = await _lcboClient.GetProductAsync("unknown");

        // Assert
        Assert.Null(result);
    }
}