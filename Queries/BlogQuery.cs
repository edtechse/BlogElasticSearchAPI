namespace BlogElasticSearchService.Queries
{
    public static class BlogQuery
    {
        public static string AutoCompleteQuery(string text)
        {
            return @"{ ""size"":5,""query"" : { ""wildcard"" : { ""blogtitle.S"" : { ""value"" : ""*" + text + @"*"" } } }, ""_source"" : [""blogtitle.S""] }";
        }

        public static string SearchBlogQuery(string text, int page)
        {
           return  @"{  ""size"":10,""from"":" + page + @",""query"":{""bool"":{""must"":[{""match"": {""blogtext.S"" :""" + text + @"""}}]}},""_source"":[""blogid.S"",""blogauthor.S"",""blogtitle.S"",""blogtext.S"",""blogcreationdate.S"",""likescount.N"",""rating.N""]}";
        }

        public static string TrendingBlogQuery()
        {
            return @"{  ""size"":1,""query"":{""bool"":{""filter"":[{""range"": {""blogcreationdate.S"":{""gte"": ""now-1M/M"", ""lte"":""now+5M/M""}}}]}},""_source"":[""blogid.S""],""aggs"":{""Trendings"":{""terms"":{""field"":""blogtags.SS.keyword"",""order"":{""_count"":""desc""},""size"":10}}}}";
        }

        public static string PersonalizedFeedQuery(string tags)
        {
            return @"{  ""size"":10,""query"":{""bool"":{""must"":[{""match"": {""blogtags.SS"" :""" + tags + @"""}}]}},""sort"": [{""blogcreationdate.S"": {""order"": ""desc""}}],""_source"":[""blogid.S"",""blogauthor.S"",""blogtitle.S"",""blogtext.S"",""blogcreationdate.S"",""blogtags.SS"",""likescount.N"",""rating.N""]}";
        }
    }
}
