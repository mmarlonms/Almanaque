namespace Acerto.MarvelHeros.Almanaque.MarvelApiAdapter.Clients
{
    public class MarvelHeroFull
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHtml { get; set; }
        public Data Data { get; set; }
        public string Etag { get; set; }
    }

    public class Data
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public string ResourceUri { get; set; }
        public Url[] Urls { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public Comics Comics { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
        public Series Series { get; set; }
    }

    public class Comics
    {
        public int Available { get; set; }
        public string Returned { get; set; }
        public string CollectionUri { get; set; }
        public ComicsItem[] Items { get; set; }
    }

    public class ComicsItem
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class Stories
    {
        public int Available { get; set; }
        public string Returned { get; set; }
        public string CollectionUri { get; set; }
        public StoriesItem[] Items { get; set; }
    }

    public class StoriesItem
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class SeriesItem
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class EventsItem
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Url
    {
        public string Type { get; set; }
        public string UrlUrl { get; set; }
    }

    public class Series
    {
        public int Available  { get; set; }
        public string CollectionURI { get; set; }
        public SeriesItem[] Items { get; set; }
    }

    public class Events
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public EventsItem[] Items { get; set; }
    }
}