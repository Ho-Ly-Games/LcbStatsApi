using System;
using System.Text.Json.Serialization;

namespace LcboStatsApi
{
    public class LcboResultItem
    {
        [JsonPropertyName("data")]
        public Product Product { get; set; }
    }


    public class LcboResultList
    {
        [JsonPropertyName("data")]
        public Product[] Products { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("meta")]
        public Metadata Metadata { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("permanent_id")]
        public int? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Name { get; set; }

        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("subcategory")]
        public string? Subcategory { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("volume")]
        public decimal? Volume { get; set; }

        [JsonPropertyName("price_index")]
        public float? PriceIndex { get; set; }

        [JsonPropertyName("alcohol_content")]
        public decimal? AlcoholContent { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("rating")]
        public double? Rating { get; set; }

        [JsonPropertyName("reviews")]
        public int? Reviews { get; set; }

        [JsonPropertyName("out_of_stock")]
        public bool? OutOfStock { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("is_buyable")]
        public int? IsBuyable { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("first")]
        public string? First { get; set; }

        [JsonPropertyName("last")]
        public string? Last { get; set; }

        [JsonPropertyName("prev")]
        public string? Prev { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }

    public class Metadata
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        [JsonPropertyName("links")]
        public PageLinks[] Links { get; set; } = Array.Empty<PageLinks>();

        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class PageLinks
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("active")]
        public bool? Active { get; set; }
    }
}